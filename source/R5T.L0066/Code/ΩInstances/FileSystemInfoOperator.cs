using System;


namespace R5T.L0066
{
    public class FileSystemInfoOperator : IFileSystemInfoOperator
    {
        #region Infrastructure

        public static IFileSystemInfoOperator Instance { get; } = new FileSystemInfoOperator();


        private FileSystemInfoOperator()
        {
        }

        #endregion
    }
}
