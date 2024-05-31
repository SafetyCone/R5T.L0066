using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using R5T.T0132;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface IDirectoryInfoOperator : IFunctionalityMarker
    {
        /// <summary>
        /// Enumerates child files in the directory (not including in any sub-directories).
        /// </summary>
        /// <remarks>
        /// Actually enumerates files as they come in (via <see cref="Directory.EnumerateFiles(string)"/>)
        /// as opposed to waiting to get all directories (as an array via <see cref="Directory.GetFiles(string)"/>).
        /// </remarks>
        public IEnumerable<FileInfo> Enumerate_ChildFiles(DirectoryInfo directoryInfo)
        {
            var output = directoryInfo.EnumerateFiles();
            return output;
        }

        public IEnumerable<DirectoryInfo> Enumerate_ChildDirectories(DirectoryInfo directoryInfo)
        {
            var output = directoryInfo.EnumerateDirectories();
            return output;
        }

        public IEnumerable<FileInfo> Enumerate_Files(
            DirectoryInfo directoryInfo,
            Func<DirectoryInfo, bool> descendantDirectoryRecursionPredicate)
        {
            var childFiles = this.Enumerate_ChildFiles(directoryInfo);
            foreach (var fileInfo in childFiles)
            {
                yield return fileInfo;
            }

            var childDirectories = this.Enumerate_ChildDirectories(directoryInfo);
            foreach (var childDirectory in childDirectories)
            {
                var recurseIntoDirectory = descendantDirectoryRecursionPredicate(childDirectory);
                if (recurseIntoDirectory)
                {
                    var subFiles = this.Enumerate_Files(
                        childDirectory,
                        descendantDirectoryRecursionPredicate);

                    foreach (var subFile in subFiles)
                    {
                        yield return subFile;
                    }
                }
            }
        }

        public DirectoryInfo From(string directoryPath)
        {
            var output = new DirectoryInfo(directoryPath);
            return output;
        }

        public string Get_DirectoryName(DirectoryInfo directoryInfo)
            => Instances.FileSystemInfoOperator.Get_Name(directoryInfo); 

        /// <summary>
        /// Gets the directory path of the directory entry.
        /// </summary>
        /// <remarks>
        /// Returns the value from <see cref="FileSystemInfo.FullName"/> (this function resolves the ambiguity between "directory path" and "full name").
        /// </remarks>
        public string Get_DirectoryPath(DirectoryInfo directoryInfo)
            => Instances.FileSystemInfoOperator.Get_Path(directoryInfo);

        /// <summary>
        /// <inheritdoc cref="Get_LastModifiedFile(DirectoryInfo, Func{DirectoryInfo, bool})" path="/summary"/>
        /// <para>Throws an exception if the directory is empty.</para>
        /// </summary>
        public FileInfo Get_LastModifiedFile_ThrowIfEmpty(
            DirectoryInfo directoryInfo,
            Func<DirectoryInfo, bool> descendantDirectoryRecursionPredicate)
        {
            var output = this.Enumerate_Files(
                directoryInfo,
                descendantDirectoryRecursionPredicate)
                .Order_ByWriteTime_Descending()
                // Choose first instead of first-or-default to throw an exception if the directory is empty.
                .First();

            return output;
        }

        /// <summary>
        /// Gets the last file in the directory to be modified.
        /// </summary>
        /// <remarks>
        /// Chooses <see cref="Get_LastModifiedFile_ThrowIfEmpty(DirectoryInfo, Func{DirectoryInfo, bool})"/> as the default.
        /// </remarks>
        public FileInfo Get_LastModifiedFile(
            DirectoryInfo directoryInfo,
            Func<DirectoryInfo, bool> descendantDirectoryRecursionPredicate)
            => this.Get_LastModifiedFile_ThrowIfEmpty(
                directoryInfo,
                descendantDirectoryRecursionPredicate);

        public DateTime Get_LastModifiedTime_ForFiles_LocalTime(
            DirectoryInfo directoryInfo,
            Func<DirectoryInfo, bool> descendantDirectoryRecursionPredicate)
            => this.Get_LastModifiedFile(
                directoryInfo,
                descendantDirectoryRecursionPredicate)
                // Return the local time.
                .LastWriteTime;

        public DateTime Get_LastModifiedTime_ForFiles_UtcTime(
            DirectoryInfo directoryInfo,
            Func<DirectoryInfo, bool> descendantDirectoryRecursionPredicate)
            => this.Get_LastModifiedFile(
                directoryInfo,
                descendantDirectoryRecursionPredicate)
                // Return the UTC time.
                .LastWriteTimeUtc;

        /// <remarks>
        /// Chooses <see cref="Get_LastModifiedTime_ForFiles_LocalTime(DirectoryInfo, Func{DirectoryInfo, bool})"/> as the default.
        /// </remarks>
        public DateTime Get_LastModifiedTime_ForFiles(
            DirectoryInfo directoryInfo,
            Func<DirectoryInfo, bool> descendantDirectoryRecursionPredicate)
            => this.Get_LastModifiedTime_ForFiles_LocalTime(
                directoryInfo,
                descendantDirectoryRecursionPredicate);

        public DateTime Get_LastModifiedTime(DirectoryInfo directoryInfo)
            => Instances.FileSystemInfoOperator.Get_LastModifiedTime(directoryInfo);

        public DirectoryInfo Get_Parent(DirectoryInfo directoryInfo)
            => directoryInfo.Parent;

        public string[] Get_PathParts(DirectoryInfo directoryInfo)
        {
            // Returns directory path parts in reversed order.
            static IEnumerable<string> Internal_Reversed(DirectoryInfo directoryInfo)
            {
                while (directoryInfo != null)
                {
                    yield return directoryInfo.Name;

                    directoryInfo = directoryInfo.Parent;
                }
            }

            var output = Internal_Reversed(directoryInfo)
                .Reverse()
                .Now();

            return output;
        }

        public bool Has_Parent(DirectoryInfo directoryInfo)
        {
            var parent = this.Get_Parent(directoryInfo);

            var output = Instances.NullOperator.Is_NotNull(parent);
            return output;
        }

        public void Set_LastModifiedTime(
            DirectoryInfo directoryInfo,
            DateTime lastModifiedTime)
            => Instances.FileSystemInfoOperator.Set_LastModifiedTime(
                directoryInfo,
                lastModifiedTime);
    }
}
