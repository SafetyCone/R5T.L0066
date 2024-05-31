using System;
using System.IO;

using R5T.T0132;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface IFileSystemInfoOperator : IFunctionalityMarker
    {
        public DateTime Get_LastModifiedTime(FileSystemInfo fileSystemInfo)
            => fileSystemInfo.LastWriteTime;

        /// <summary>
        /// Gets the name of the file system entry (e.g. "temp.txt" in "C:\Temp\temp.txt" or "Temp" in "C:\Temp\").
        /// </summary>
        /// <remarks>
        /// Returns the value from <see cref="FileSystemInfo.Name"/> (this function resolves the ambiguity between "name" and the two properties "name" and "full name").
        /// This method might not be overkill, but there is still some 
        /// </remarks>
        public string Get_Name(FileSystemInfo fileSystemInfo)
            => fileSystemInfo.Name;

        /// <summary>
        /// Gets the path of the file system entry (e.g. "C:\Temp\temp.txt" in "C:\Temp\temp.txt" or "C:\Temp" in "C:\Temp\").
        /// </summary>
        /// <remarks>
        /// Returns the value from <see cref="FileSystemInfo.FullName"/> (this function resolves the ambiguity between "path" and "full name").
        /// </remarks>
        public string Get_Path(FileSystemInfo fileSystemInfo)
            => fileSystemInfo.FullName;

        public void Set_LastModifiedTime(
            FileSystemInfo fileSystemInfo,
            DateTime lastModifiedTime)
            => fileSystemInfo.LastWriteTime = lastModifiedTime;
    }
}
