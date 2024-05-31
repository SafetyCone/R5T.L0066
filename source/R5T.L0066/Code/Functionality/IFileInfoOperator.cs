using System;
using System.IO;

using R5T.T0132;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface IFileInfoOperator : IFunctionalityMarker
    {
        public FileInfo From(string filePath)
            => new FileInfo(filePath);

        /// <summary>
        /// Gets the directory path of the file entry.
        /// </summary>
        /// <remarks>
        /// Returns the value from <see cref="FileSystemInfo.FullName"/> (this function resolves the ambiguity between "file path" and "full name").
        /// </remarks>
        public string Get_FilePath(FileInfo fileInfo)
            => Instances.FileSystemInfoOperator.Get_Path(fileInfo);

        public DateTime Get_LastModifiedTime(FileInfo fileInfo)
            => Instances.FileSystemInfoOperator.Get_LastModifiedTime(fileInfo);

        public DirectoryInfo Get_ParentDirectory(FileInfo fileInfo)
            => fileInfo.Directory;

        public void Set_LastModifiedTime(
            FileInfo fileInfo,
            DateTime lastModifiedTime)
            => Instances.FileSystemInfoOperator.Set_LastModifiedTime(
                fileInfo,
                lastModifiedTime);
    }
}
