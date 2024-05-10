using System;
using System.Collections.Generic;
using System.IO;

using R5T.T0132;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface IFileSystemOperator : IFunctionalityMarker
    {
        /// <summary>
        /// Chooses <see cref="Copy_File_OverwriteAllowed(string, string)"/> as the default.
        /// </summary>
        public void Copy_File(
            string sourceFilePath,
            string destinationFilePath)
        {
            this.Copy_File_OverwriteAllowed(
                sourceFilePath,
                destinationFilePath);
        }

        public void Copy_File_OverwriteAllowed(
            string sourceFilePath,
            string destinationFilePath)
        {
            File.Copy(
                sourceFilePath,
                destinationFilePath,
                true);
        }

        public void Copy_File_OverwriteForbidden(
            string sourceFilePath,
            string destinationFilePath)
        {
            File.Copy(
                sourceFilePath,
                destinationFilePath,
                false);
        }

        /// <summary>
        /// Creates a directory idempotently (meaning there is no problem with issuing the command multiple times).
        /// </summary>
        /// <remarks>
        /// The system method <see cref="Directory.CreateDirectory(string)"/> does not throw an exception if you create a directory that already exists.
        /// However, it's hard to remember this fact, so this method name makes that fact explicit.
        /// </remarks>
        public void Create_Directory_Idempotent(string directoryPath)
        {
            // Does not throw an exception if a directory already exists.
            // See proof at: https://github.com/MinexAutomation/Public/blob/a8c302415b56fb8903c751436cbeef3eae8e1692/Source/Experiments/CSharp/ExaminingCSharp/ExaminingCSharp/Code/Experiments/IOExperiments.cs#L24
            Directory.CreateDirectory(directoryPath);
        }

        /// <summary>
        /// <inheritdoc cref="Create_Directory_Idempotent(string)" path="/summary"/>
        /// <para>
        /// Quality-of-life overload for <see cref="Create_Directory_Idempotent(string)"/>.
        /// </para>
        /// </summary>
        /// <inheritdoc cref="Create_Directory_Idempotent(string)" path="/remarks"/>
        public void Create_Directory_OkIfAlreadyExists(string directoryPath)
        {
            this.Create_Directory_Idempotent(directoryPath);
        }

        public void Delete_Directory_NonRobust(string directoryPath)
        {
            Directory.Delete(directoryPath, true);
        }

        /// <summary>
        /// Deletes a directory path.
        /// The <see cref="System.IO.Directory.Delete(string)"/> method throws a <see cref="System.IO.DirectoryNotFoundException"/> if attempting to delete a non-existent directory. This is annoying.
        /// All you really want is the directory to not exist, so this method simply takes care of checking if the directory exists.
        /// Also annoying, you need to specify the recursive option to delete a directory with anything in it. This method also takes care of specifying true for the recursive option.
        /// Even more annoying, even after specifying the recursive option, the system method will not delete read-only files. Thus this method disables read-only options on all files recursively.
        /// </summary>
        public void Delete_Directory_Robust(string directoryPath)
        {
            if (this.Exists_Directory(directoryPath))
            {
                this.DisableReadOnly(directoryPath);

                this.Delete_Directory_NonRobust(directoryPath);
            }
        }

        /// <summary>
        /// Non-idempotently deletes a directory.
        /// An exception is thrown if the directory does not exist.
        /// </summary>
        public void Delete_Directory_NonIdempotent(string directoryPath)
        {
            if (!this.Exists_Directory(directoryPath))
            {
                throw new DirectoryNotFoundException(directoryPath);
            }

            this.Delete_Directory_Robust(directoryPath);
        }

        public bool Delete_Directory_Idempotent(string directoryPath)
        {
            if (this.Exists_Directory(directoryPath))
            {
                this.Delete_Directory_Robust(directoryPath);

                return true;
            }
            else
            {
                return false;
            }
        }

        public void Delete_Directory_OkIfNotExists(string directoryPath)
        {
            this.Delete_Directory_Idempotent(directoryPath);
        }

        public void Delete_File_OkIfNotExists(string filePath)
        {
            var directoryForFileDirectoryPath = Instances.PathOperator.Get_ParentDirectoryPath_ForFile(filePath);

            var directoryExists = this.Exists_Directory(directoryForFileDirectoryPath);
            if (!directoryExists)
            {
                // No need to delete file if directory containing it does not exist!
                return;
            }

            File.Delete(filePath);
        }

        public void DisableReadOnly(string directoryPath)
        {
            var directoryInfo = new DirectoryInfo(directoryPath);

            this.DisableReadOnly(directoryInfo);
        }

        /// <summary>
        /// Remove the read-only attribute from all files.
        /// </summary>
        /// <remarks>
        /// Adapted from: https://stackoverflow.com/questions/1982209/cannot-programatically-delete-svn-working-copy
        /// </remarks>
        public void DisableReadOnly(DirectoryInfo directoryInfo)
        {
            foreach (var file in directoryInfo.GetFiles())
            {
                if (file.IsReadOnly)
                {
                    file.IsReadOnly = false;
                }
            }

            foreach (var subdirectory in directoryInfo.GetDirectories())
            {
                this.DisableReadOnly(subdirectory);
            }
        }

        public void Ensure_DirectoryExists(string directoryPath)
        {
            this.Create_Directory_OkIfAlreadyExists(directoryPath);
        }

        public void Ensure_DirectoryExists_ForFilePath(string filePath)
        {
            var directoryPath = PathOperator.Instance.Get_ParentDirectoryPath_ForFile(filePath);

            this.Create_Directory_OkIfAlreadyExists(directoryPath);
        }

        /// <summary>
        /// Enumerates child files in the directory (not including in any sub-directories).
        /// </summary>
        /// <remarks>
        /// Actually enumerates files as they come in (via <see cref="Directory.EnumerateFiles(string)"/>)
        /// as opposed to waiting to get all directories (as an array via <see cref="Directory.GetFiles(string)"/>).
        /// </remarks>
        public IEnumerable<string> Enumerate_ChildFilePaths(string directoryPath)
        {
            var output = Directory.EnumerateFiles(directoryPath);
            return output;
        }

        /// <inheritdoc cref="Enumerate_ChildFilePaths(string)"/>
        public IEnumerable<string> Enumerate_ChildFilePaths(
            string directoryPath,
            string searchPattern)
        {
            var output = Directory.EnumerateFiles(
                directoryPath,
                searchPattern,
                SearchOption.TopDirectoryOnly);

            return output;
        }

        /// <inheritdoc cref="Enumerate_ChildFilePaths(string)"/>
        public IEnumerable<string> Enumerate_ChildFilePaths_ByFileExtension(
            string directoryPath,
            string fileExtension)
        {
            var searchPattern = Instances.SearchPatternGenerator.Files_WithExtension(fileExtension);

            return this.Enumerate_ChildFilePaths(
                directoryPath,
                searchPattern);
        }

        /// <summary>
        /// Enumerates child files in the directory and any sub-directories.
        /// </summary>
        public IEnumerable<string> Enumerate_DescendantFilePaths(string directoryPath)
        {
            var output = Directory.EnumerateFiles(
                directoryPath,
                Instances.SearchPatterns.All,
                SearchOption.AllDirectories);

            return output;
        }

        /// <inheritdoc cref="Enumerate_ChildFilePaths(string)"/>
        public IEnumerable<string> Enumerate_DescendantFilePaths_ByFileExtension(
            string directoryPath,
            string fileExtension)
        {
            var searchPattern = Instances.SearchPatternGenerator.Files_WithExtension(fileExtension);

            return this.Enumerate_DescendantFilePaths(
                directoryPath,
                searchPattern);
        }

        /// <inheritdoc cref="Enumerate_DescendantFilePaths(string)"/>
        public IEnumerable<string> Enumerate_DescendantFilePaths(
            string directoryPath,
            string searchPattern)
        {
            var output = Directory.EnumerateFiles(
                directoryPath,
                searchPattern,
                SearchOption.AllDirectories);

            return output;
        }

        /// <inheritdoc cref="Enumerate_ChildXmlFiles"/>
        public IEnumerable<string> Enumerate_XmlFiles(string directoryPath)
        {
            return this.Enumerate_ChildXmlFiles(directoryPath);
        }

        /// <inheritdoc cref="Enumerate_ChildDllFiles"/>
        public IEnumerable<string> Enumerate_DllFiles(string directoryPath)
        {
            return this.Enumerate_ChildDllFiles(directoryPath);
        }

        public IEnumerable<string> Enumerate_ChildDirectoryPaths(
            string directoryPath,
            string searchPattern)
        {
            var output = Directory.EnumerateDirectories(directoryPath, searchPattern, SearchOption.TopDirectoryOnly);
            return output;
        }

        /// <summary>
        /// Enumerates all child directories of the directory.
        /// </summary>
        /// <remarks>
        /// Actually enumerates directories as they come in (via <see cref="Directory.EnumerateDirectories(string)"/>)
        /// as opposed to waiting to get all directories (as an array via <see cref="Directory.GetDirectories(string)"/>).
        /// </remarks>
        public IEnumerable<string> Enumerate_ChildDirectoryPaths(
            string directoryPath)
        {
            var output = Directory.EnumerateDirectories(
                directoryPath,
                Instances.SearchPatterns.All,
                SearchOption.TopDirectoryOnly);

            return output;
        }

        /// <summary>
        /// Enumerates child DLL files in the directory.
        /// </summary>
        public IEnumerable<string> Enumerate_ChildDllFiles(string directoryPath)
        {
            return Instances.FileSystemOperator.Enumerate_ChildFilePaths_ByFileExtension(
                directoryPath,
                Instances.FileExtensions.Dll);
        }

        /// <inheritdoc cref="Enumerate_ChildTextFiles"/>
        public IEnumerable<string> Enumerate_TextFiles(string directoryPath)
        {
            return this.Enumerate_ChildTextFiles(directoryPath);
        }

        /// <summary>
        /// Enumerates child text files in the directory.
        /// </summary>
        public IEnumerable<string> Enumerate_ChildTextFiles(string directoryPath)
        {
            return Instances.FileSystemOperator.Enumerate_ChildFilePaths_ByFileExtension(
                directoryPath,
                Instances.FileExtensions.Text);
        }

        /// <summary>
        /// Enumerates child XML files in the directory.
        /// </summary>
        public IEnumerable<string> Enumerate_ChildXmlFiles(string directoryPath)
        {
            return this.Enumerate_ChildFilePaths_ByFileExtension(
                directoryPath,
                Instances.FileExtensions.Xml);
        }

        /// <summary>
        /// Enumerates files in the directory (not including in any sub-directories).
        /// </summary>
        public IEnumerable<string> Enumerate_FilePaths(string directoryPath)
        {
            return this.Enumerate_ChildFilePaths(directoryPath);
        }

        /// <summary>
        /// Enumerates files in the directory (not including in any sub-directories).
        /// </summary>
        public IEnumerable<string> Enumerate_FilePaths_ByFileExtension(
            string directoryPath,
            string fileExtension)
        {
            return this.Enumerate_ChildFilePaths_ByFileExtension(
                directoryPath,
                fileExtension);
        }

        public bool Exists_Directory(string directoryPath)
        {
            var output = Directory.Exists(directoryPath);
            return output;
        }

        public bool Exists_File(string filePath)
        {
            var output = File.Exists(filePath);
            return output;
        }

        public string[] Get_ChildDirectoryPaths(
            string directoryPath,
            string searchPattern)
        {
            var output = Directory.GetDirectories(
                directoryPath,
                searchPattern,
                SearchOption.TopDirectoryOnly);

            return output;
        }

        public string[] Get_ChildDirectoryPaths(
            string directoryPath)
        {
            var output = Directory.GetDirectories(
                directoryPath,
                Instances.SearchPatterns.All,
                SearchOption.TopDirectoryOnly);

            return output;
        }

        public Func<string, IEnumerable<string>> Get_Enumerate_FilePaths_ByFileExtension(string fileExtension)
        {
            return directoryPath => this.Enumerate_ChildFilePaths_ByFileExtension(
                directoryPath,
                fileExtension);
        }

        /// <summary>
        /// Tests whether a file exists, and if it doesn't, throws a <see cref="FileNotFoundException"/>.
        /// </summary>
        public void Verify_Directory_Exists(string directoryPath)
        {
            var directoryExists = this.Exists_Directory(directoryPath);
            if (!directoryExists)
            {
                throw new DirectoryNotFoundException($"Directory did not exist:\n\t{directoryPath}");
            }
        }

        /// <summary>
        /// Tests whether a file exists, and if it does, throws an <see cref="Exception"/>.
        /// </summary>
        public void Verify_Directory_DoesNotExist(string directoryPath)
        {
            var directoryExists = this.Exists_Directory(directoryPath);
            if (directoryExists)
            {
                throw new Exception($"Directory exists:\n{directoryPath}");
            }
        }

        /// <summary>
        /// Tests whether a file exists, and if it doesn't, throws a <see cref="FileNotFoundException"/>.
        /// </summary>
        public void Verify_File_Exists(string filePath)
        {
            var fileExists = this.Exists_File(filePath);
            if (!fileExists)
            {
                throw new FileNotFoundException("File did not exist.", filePath);
            }
        }

        /// <summary>
        /// Tests whether a file exists, and if it does, throws an <see cref="Exception"/>.
        /// </summary>
        public void Verify_File_DoesNotExist(string filePath)
        {
            var fileExists = this.Exists_File(filePath);
            if (fileExists)
            {
                throw new Exception($"File exists:\n{filePath}");
            }
        }
    }
}
