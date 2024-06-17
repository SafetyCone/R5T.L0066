using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;

using R5T.T0132;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface IFileSystemOperator : IFunctionalityMarker
    {
#pragma warning disable IDE1006 // Naming Styles
        public Implementations.IFileSystemOperator _Implementations => Implementations.FileSystemOperator.Instance;
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
        public IEnumerable<string> Enumerate_ChildFilePaths_StringOutput(string directoryPath)
            => this.Enumerate_ChildFilePaths(directoryPath);

        /// <inheritdoc cref="Enumerate_ChildFilePaths(string)"/>
        public IEnumerable<FileInfo> Enumerate_ChildFilePaths_FileInfoOutput(string directoryPath)
        {
            var directory = Instances.DirectoryInfoOperator.From(directoryPath);

            var output = Instances.DirectoryInfoOperator.Enumerate_ChildFiles(directory);
            return output;
        }

        /// <inheritdoc cref="Enumerate_ChildFilePaths(string)"/>
        public IEnumerable<FileInfo> Enumerate_ChildFilePaths(DirectoryInfo directory)
            => Instances.DirectoryInfoOperator.Enumerate_ChildFiles(directory);

        /// <inheritdoc cref="Enumerate_ChildFilePaths(string)"/>
        public IEnumerable<string> Enumerate_ChildFilePaths_StringOutput(DirectoryInfo directory)
        {
            var directoryPath = Instances.DirectoryInfoOperator.Get_DirectoryPath(directory);

            var output = this.Enumerate_ChildFilePaths(directoryPath);
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
            var output = Directory.EnumerateDirectories(directoryPath, searchPattern, SearchOption.TopDirectoryOnly)
                // The system method has a bad habit of not directory-indicating directory paths.
                .Select(directoryPath => Instances.PathOperator.Ensure_IsDirectoryIndicated(directoryPath));

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
            => this.Enumerate_ChildDirectoryPaths(
                directoryPath,
                Instances.SearchPatterns.All);

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

        /// <summary>
        /// Enumerates child DLL files in the directory.
        /// </summary>
        public IEnumerable<string> Enumerate_ChildDllFiles(string directoryPath)
        {
            return Instances.FileSystemOperator.Enumerate_ChildFilePaths_ByFileExtension(
                directoryPath,
                Instances.FileExtensions.Dll);
        }

        /// <summary>
        /// Enumerates all child-of-child (grandchild) directory paths.
        /// </summary>=
        public IEnumerable<string> Enumerate_GrandchildDirectoryPaths(
            string directoryPath)
        {
            var childDirectoryPaths = this.Enumerate_ChildDirectoryPaths(
                directoryPath);

            var output = childDirectoryPaths
                .SelectMany(this.Enumerate_ChildDirectoryPaths)
                ;

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

        /// <summary>
        /// Obnoxiously, the .NET file system info objects do <strong>NOT</strong> provide any way to get the actual, case-sensitive, paths for files.
        /// 
        /// <para>NOTE! This is an expensive operation, involving many file-system searches. Use this method sparingly (for example, only for display of paths of interest instead of for bulk formatting of paths).</para>
        /// </summary>
        public string Get_ActualPath_ForFile(string path)
        {
            var pathParts = Instances.PathOperator.Get_PathParts(path);

            // Start with the drive.
            var driveName = pathParts.Get_First();
            var directoryNames = pathParts
                .Except_First()
                .Except_Last()
                .Now();
            var fileName = pathParts.Get_Last();

            var drives = DriveInfo.GetDrives();

            static DriveInfo Get_Drive(
                IEnumerable<DriveInfo> drives,
                string driveName)
            {
                foreach (var drive in drives)
                {
                    var nameMatches = Instances.StringOperator.Contains_IgnoreCase(
                        drive.Name,
                        driveName);

                    if(nameMatches)
                    {
                        return drive;
                    }
                }

                // Else, error.
                throw new Exception($"No drive found for '{driveName}'.");
            }

            var drive = Get_Drive(
                drives,
                driveName);

            var drivePath = drive.Name;

            var actualDirectory = Instances.DirectoryInfoOperator.From(drivePath);

            var enumerationOptions = new EnumerationOptions
            {
                // We want a case-insensitive match.
                MatchCasing = MatchCasing.CaseInsensitive,
            };

            foreach (var directoryName in directoryNames)
            {
                var directories = actualDirectory.GetDirectories(
                    directoryName,
                    enumerationOptions)
                    // Do not ask for a single, as there could be multiple on non-Windows (case-sensitive) systems.
                    ;

                var directoryCount = directories.Length;

                // Should never happen.
                if(directoryCount < 1)
                {
                    throw new Exception($"'{directoryName}': No directory found in:\n\t{actualDirectory.FullName}");
                }

                if(directoryCount < 2)
                {
                    actualDirectory = directories.Single();
                }
                else
                {
                    // Find the exact, case-sensitive match.
                    actualDirectory = directories
                        .Where(directory => directory.Name == directoryName)
                        .Single();
                }
            }

            // Now find the file.
            var files = actualDirectory.GetFiles(
                fileName,
                enumerationOptions);

            var fileCount = files.Length;

            // Should never happen.
            if (fileCount < 1)
            {
                throw new Exception($"{fileName}: No file found in:\n\t{actualDirectory.FullName}");
            }

            var file = fileCount < 2
                ? files.Single()
                : files
                    .Where(file => file.Name == fileName)
                    .Single()
                ;

            var output = file.FullName;
            return output;
        }

        public string[] Get_ChildDirectoryPaths(
            string directoryPath,
            string searchPattern)
        {
            var output = this.Get_Directories(
                directoryPath,
                searchPattern,
                SearchOption.TopDirectoryOnly);

            return output;
        }

        public string[] Get_ChildDirectoryPaths(
            string directoryPath)
        {
            var output = this.Get_Directories(
                directoryPath,
                Instances.SearchPatterns.All,
                SearchOption.TopDirectoryOnly);

            return output;
        }

        public string[] Get_ChildDllFiles(string directoryPath)
            => this.Enumerate_ChildDllFiles(directoryPath)
                .Now();

        /// <summary>
        /// Ensures that all returned directory paths are directory-indicated.
        /// </summary>
        public string[] Get_Directories(
            string path,
            string searchPattern,
            SearchOption searchOption)
        {
            var nonDirectoryIndicatedDirectoryPaths = Directory.GetDirectories(
                path,
                searchPattern,
                searchOption);

            var output = Instances.PathOperator.Ensure_AreDirectoryIndicated(nonDirectoryIndicatedDirectoryPaths)
                .Now();

            return output;
        }

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

        public DateTime Get_LastModifiedTime_ForFiles(
            string directoryPath,
            Func<DirectoryInfo, bool> descendantDirectoryRecursionPredicate)
        {
            var directory = Instances.DirectoryInfoOperator.From(directoryPath);

            var output = Instances.DirectoryInfoOperator.Get_LastModifiedTime_ForFiles(
                directory,
                descendantDirectoryRecursionPredicate);

            return output;
        }

        public DateTime Get_LastModifiedTime_ForFile(string filePath)
        {
            var file = Instances.FileInfoOperator.From(filePath);

            var output = Instances.FileInfoOperator.Get_LastModifiedTime(file);
            return output;
        }

        public DateTime Get_LastModifiedTime_ForDirectory(string filePath)
        {
            var directory = Instances.DirectoryInfoOperator.From(filePath);

            var output = Instances.DirectoryInfoOperator.Get_LastModifiedTime(directory);
            return output;
        }

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
