using System;
using System.IO;

using F10Y.T0011;

using R5T.T0132;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface IFileSystemInfoOperator : IFunctionalityMarker,
        F10Y.L0000.IFileSystemInfoOperator
    {
#pragma warning disable IDE1006 // Naming Styles

        [Ignore]
        F10Y.L0000.IFileSystemInfoOperator _F10Y_L0000 => F10Y.L0000.FileSystemInfoOperator.Instance;

#pragma warning restore IDE1006 // Naming Styles


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
