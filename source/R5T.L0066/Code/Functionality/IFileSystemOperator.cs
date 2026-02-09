using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using R5T.T0132;
using R5T.T0143;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface IFileSystemOperator : IFunctionalityMarker,
        F10Y.L0001.L000.IFileSystemOperator
    {
#pragma warning disable IDE1006 // Naming Styles

        [Ignore]
        public Implementations.IFileSystemOperator _Implementations => Implementations.FileSystemOperator.Instance;


        [Ignore]
        public F10Y.L0001.L000.IFileSystemOperator _F10Y_L0001_L000 => F10Y.L0001.L000.FileSystemOperator.Instance;

#pragma warning restore IDE1006 // Naming Styles


        public void Clear_Directory_Idempotent(
            string directoryPath)
        {
            this.Delete_Directory_Idempotent(
                directoryPath);

            this.Create_Directory_Idempotent(
                directoryPath);
        }

        /// <summary>
        /// Chooses <see cref="Clear_Directory_Idempotent(string)"/> as the default.
        /// </summary>
        public void Clear_Directory(
            string directoryPath)
            => this.Clear_Directory_Idempotent(directoryPath);

        /// <summary>
        /// Copies a directory.
        /// </summary>
        /// <remarks>
        /// It is BONKERS that C# does not have a built-in implementation of copying directories. Wut?!?
        /// </remarks>
        public void Copy_Directory(
            string sourceDirectoryPath,
            string destinationDirectoryPath,
            bool recursive = true)
        {
            /// Adapted from: https://docs.microsoft.com/en-us/dotnet/standard/io/how-to-copy-directories

            // Get information about the source directory
            var directory = new DirectoryInfo(sourceDirectoryPath);

            // Check if the source directory exists
            if (!directory.Exists)
            {
                throw new DirectoryNotFoundException($"Source directory not found: {directory.FullName}");
            }

            // Cache directories before we start copying.
            DirectoryInfo[] subDirectories = directory.GetDirectories();

            // Create the destination directory
            Directory.CreateDirectory(destinationDirectoryPath);

            // Get the files in the source directory and copy to the destination directory
            foreach (FileInfo file in directory.GetFiles())
            {
                string targetFilePath = Path.Combine(destinationDirectoryPath, file.Name);

                file.CopyTo(targetFilePath);
            }

            // If recursive and copying subdirectories, recursively call this method
            if (recursive)
            {
                foreach (DirectoryInfo subDirectory in subDirectories)
                {
                    string newDestinationDirectoryPath = Path.Combine(destinationDirectoryPath, subDirectory.Name);

                    this.Copy_Directory(subDirectory.FullName, newDestinationDirectoryPath, true);
                }
            }
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

        public void Copy_File_OverwriteForbidden(
            string sourceFilePath,
            string destinationFilePath)
        {
            File.Copy(
                sourceFilePath,
                destinationFilePath,
                false);
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

        /// <inheritdoc cref="F10Y.L0000.IFileSystemOperator.Enumerate_ChildFilePaths(string)"/>
        public IEnumerable<string> Enumerate_ChildFilePaths_StringOutput(string directoryPath)
            => this.Enumerate_ChildFilePaths(directoryPath);

        /// <inheritdoc cref="F10Y.L0000.IFileSystemOperator.Enumerate_ChildFilePaths(string)"/>
        public IEnumerable<FileInfo> Enumerate_ChildFilePaths_FileInfoOutput(string directoryPath)
        {
            var directory = Instances.DirectoryInfoOperator.From(directoryPath);

            var output = Instances.DirectoryInfoOperator.Enumerate_ChildFiles(directory);
            return output;
        }

        /// <inheritdoc cref="F10Y.L0000.IFileSystemOperator.Enumerate_ChildFilePaths(string)"/>
        public IEnumerable<FileInfo> Enumerate_ChildFilePaths(DirectoryInfo directory)
            => Instances.DirectoryInfoOperator.Enumerate_ChildFiles(directory);

        /// <inheritdoc cref="F10Y.L0000.IFileSystemOperator.Enumerate_ChildFilePaths(string)"/>
        public IEnumerable<string> Enumerate_ChildFilePaths_StringOutput(DirectoryInfo directory)
        {
            var directoryPath = Instances.DirectoryInfoOperator.Get_DirectoryPath(directory);

            var output = this.Enumerate_ChildFilePaths(directoryPath);
            return output;
        }

        public IEnumerable<FileInfo> Enumerate_Files(
            DirectoryInfo directory,
            Func<DirectoryInfo, bool> descendantDirectoryRecursionPredicate)
            => Instances.DirectoryInfoOperator.Enumerate_Files(
                directory,
                descendantDirectoryRecursionPredicate);

        public IEnumerable<FileInfo> Enumerate_Files_FileInfoOutput(
            string directoryPath,
            Func<DirectoryInfo, bool> descendantDirectoryRecursionPredicate)
        {
            var directory = Instances.DirectoryInfoOperator.From(directoryPath);

            var output = Instances.DirectoryInfoOperator.Enumerate_Files(
                directory,
                descendantDirectoryRecursionPredicate);

            return output;
        }

        public IEnumerable<string> Enumerate_ChildAndGrandchildFilePaths_ByFileExtension(
            string fileExtension,
            string directoryPath)
        {
            var childDirectoryPaths = Instances.FileSystemOperator.Enumerate_ChildDirectoryPaths(directoryPath);

            var directoryPathsToSearch = childDirectoryPaths
                .Prepend(directoryPath);

            var output = this.Enumerate_ChildFilePaths_ByFileExtension(
                fileExtension,
                directoryPathsToSearch);

            return output;
        }

        public IEnumerable<string> Enumerate_ChildFilePaths_ByFileExtension(
            string fileExtension,
            IEnumerable<string> directoryPaths)
        {
            var searchPattern = Instances.SearchPatternGenerator.Files_WithExtension(fileExtension);

            var output = directoryPaths
                .SelectMany(directoryPath => this.Enumerate_ChildFilePaths(
                    directoryPath,
                    searchPattern));

            return output;
        }

        public IEnumerable<string> Enumerate_ChildFilePaths_ByFileExtension(
            string fileExtension,
            params string[] directoryPaths)
            => this.Enumerate_ChildFilePaths_ByFileExtension(
                fileExtension,
                directoryPaths.AsEnumerable());

        public IEnumerable<string> Enumerate_DescendantDirectoryPaths(
            string directoryPath,
            string searchPattern)
        {
            var output = Directory.EnumerateDirectories(directoryPath, searchPattern, SearchOption.AllDirectories)
                // The system method has a bad habit of not directory-indicating directory paths.
                .Select(directoryPath => Instances.PathOperator.Ensure_IsDirectoryIndicated(directoryPath));

            return output;
        }

        public IEnumerable<string> Enumerate_DescendantDirectoryPaths(string directoryPath)
            => this.Enumerate_DescendantDirectoryPaths(
                directoryPath,
                Instances.SearchPatterns.All);

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

        /// <inheritdoc cref="F10Y.L0000.IFileSystemOperator.Enumerate_ChildFilePaths(string)"/>
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

        /// <summary>
        /// Enumerates all child and child-of-child (grandchild) directory paths.
        /// </summary>=
        public IEnumerable<string> Enumerate_ChildAndGrandchildDirectoryPaths(
            string directoryPath)
        {
            var childDirectoryPaths = this.Enumerate_ChildDirectoryPaths(
                directoryPath);

            var grandchildDirectoryPaths = childDirectoryPaths
                .SelectMany(this.Enumerate_ChildDirectoryPaths)
                ;

            var output = childDirectoryPaths
                .Append(grandchildDirectoryPaths)
                ;

            return output;
        }

        public IEnumerable<string> Enumerate_ChildDirectoryPaths_ExcludingHidden(
            string directoryPath)
        {
            var enumerationOptions = new EnumerationOptions
            {
                AttributesToSkip = FileAttributes.Hidden,
            };

            var output = Directory.EnumerateDirectories(
                directoryPath,
                Instances.SearchPatterns.All,
                enumerationOptions);

            return output;
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

        public string[] Get_ChildDllFiles(string directoryPath)
            => this.Enumerate_ChildDllFiles(directoryPath)
                .ToArray();

        public string[] Get_ChildXmlFiles(string directoryPath)
            => this.Enumerate_ChildXmlFiles(directoryPath)
                .ToArray();

        public Func<string, IEnumerable<string>> Get_Enumerate_FilePaths_ByFileExtension(string fileExtension)
        {
            return directoryPath => this.Enumerate_ChildFilePaths_ByFileExtension(
                directoryPath,
                fileExtension);
        }

        public FileInfo Get_LastModifiedFile_FileInfoOutput(
            string directoryPath,
            Func<DirectoryInfo, bool> descendantDirectoryRecursionPredicate)
        {
            var directory = Instances.DirectoryInfoOperator.From(directoryPath);

            var output = Instances.DirectoryInfoOperator.Get_LastModifiedFile(
                directory,
                descendantDirectoryRecursionPredicate);

            return output;
        }

        public string Get_LastModifiedFile_FilePathOutput(
            string directoryPath,
            Func<DirectoryInfo, bool> descendantDirectoryRecursionPredicate)
        {
            var file = this.Get_LastModifiedFile_FileInfoOutput(
                directoryPath,
                descendantDirectoryRecursionPredicate);

            var output = Instances.FileInfoOperator.Get_FilePath(file);
            return output;
        }

        /// <summary>
        /// Chooses <see cref="Get_LastModifiedFile_FilePathOutput(string, Func{DirectoryInfo, bool})"/> as the default.
        /// </summary>
        public string Get_LastModifiedFile(
            string directoryPath,
            Func<DirectoryInfo, bool> descendantDirectoryRecursionPredicate)
            => this.Get_LastModifiedFile_FilePathOutput(
                directoryPath,
                descendantDirectoryRecursionPredicate);

        public string Get_LastModifiedFile(string directoryPath)
            => this.Get_LastModifiedFile_FilePathOutput(
                directoryPath,
                Instances.PredicateProvider.Get_True<DirectoryInfo>());

        /// <summary>
        /// Moves a directory from one location to another.
        /// </summary>
        /// <remarks>
        /// Note: unlike the system command, this command can handle moving a directory to a location within the old directory. (This is a move contents operation.)
        /// </remarks>
        public void Move_Directory(
            string sourceDirectoryPath,
            string destinationDirectoryPath)
        {
            var destinationIsWithinSource = Instances.PathOperator.Is_Within_Directory(
                sourceDirectoryPath,
                destinationDirectoryPath);

            if(destinationIsWithinSource)
            {
                // Need to copy contents since move command will not work.
                this.Move_DirectoryContents(
                    sourceDirectoryPath,
                    destinationDirectoryPath);
            }
            else
            {
                // Can do a regular move.
                _Implementations.Move_Directory_ViaSystemCommand(
                    sourceDirectoryPath,
                    destinationDirectoryPath);
            }
        }

        /// <summary>
        /// Moves the contents of a directory to a different directory.
        /// </summary>
        /// <remarks>
        /// What do you do if you want to move a directory to a location within the old directory?
        /// This is really more of a move-contents operation.
        /// </remarks>
        public void Move_DirectoryContents(
            string sourceDirectoryPath,
            string destinationDirectoryPath)
        {
            // Ensure the destination exists.
            this.Ensure_DirectoryExists(destinationDirectoryPath);

            // Copy all files.
            var sourceChildFilePaths = this.Enumerate_ChildFilePaths(sourceDirectoryPath);
            foreach (var sourceChildFilePath in sourceChildFilePaths)
            {
                var destinationFilePath = Instances.PathOperator.Get_DestinationFilePath(
                    sourceChildFilePath,
                    destinationDirectoryPath);

                this.Move_File(
                    sourceChildFilePath,
                    destinationFilePath);
            }

            // Copy all directories.
            var sourceChildDirectoryPaths = this.Enumerate_ChildDirectoryPaths(sourceDirectoryPath);
            foreach (var sourceChildDirectoryPath in sourceChildDirectoryPaths)
            {
                // If the current source child directory path contains the destination directory path, do not move it.
                var sourceChildDirectoryIsWithinDestination = Instances.PathOperator.Is_Within_Directory(
                    destinationDirectoryPath,
                    sourceChildDirectoryPath);

                if(sourceChildDirectoryIsWithinDestination)
                {
                    continue;
                }

                var destinationChildDirectoryPath = Instances.PathOperator.Get_DestinationDirectoryPath(
                    sourceChildDirectoryPath,
                    destinationDirectoryPath);

                _Implementations.Move_Directory_ViaSystemCommand(
                    sourceChildDirectoryPath,
                    destinationChildDirectoryPath);
            }
        }

        public void Move_File(
            string sourceFilePath,
            string destinationFilePath)
        {
            File.Move(
                sourceFilePath,
                destinationFilePath);
        }

        public void Set_LastModifiedTime_ForDirectory(
            string directoryPath,
            DateTime lastModifiedTime)
        {
            var directory = Instances.DirectoryInfoOperator.From(directoryPath);

            Instances.DirectoryInfoOperator.Set_LastModifiedTime(
                directory,
                lastModifiedTime);
        }

        public void Set_LastModifiedTime_ForFile(
            string filePath,
            DateTime lastModifiedTime)
        {
            var file = Instances.FileInfoOperator.From(filePath);

            Instances.FileInfoOperator.Set_LastModifiedTime(
                file,
                lastModifiedTime);
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
        /// Implements the OS command-line where.exe functionality of finding executable files on the system path.
        /// </summary>
        public string[] Where(string searchText)
        {
            var systemPaths = Instances.EnvironmentOperator.Get_PathDirectories();

            var results = new List<string>();

            foreach (var directoryPath in systemPaths)
            {
                var directoryPathExists = Instances.FileSystemOperator.Exists_Directory(directoryPath);

                if (!directoryPathExists)
                {
                    continue;
                }

                var filePaths = Instances.FileSystemOperator.Enumerate_ChildFilePaths_ByFileExtension(
                    directoryPath,
                    Instances.FileExtensions.Executable);

                foreach (var filePath in filePaths)
                {
                    var fileNameStem = Instances.PathOperator.Get_FileNameStem(filePath);

                    var fileNameStemIs = Instances.StringOperator.Equals_CaseInsensitive(
                        fileNameStem,
                        searchText);

                    if (fileNameStemIs)
                    {
                        var actualFilePath = Instances.FileSystemOperator.Get_ActualPath_ForFile(filePath);

                        results.Add(actualFilePath);
                    }
                }
            }

            var output = results.ToArray();
            return output;
        }
    }
}
