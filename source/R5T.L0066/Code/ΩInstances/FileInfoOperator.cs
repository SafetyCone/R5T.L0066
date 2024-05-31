using System;


namespace R5T.L0066
{
    public class FileInfoOperator : IFileInfoOperator
    {
        #region Infrastructure

        public static IFileInfoOperator Instance { get; } = new FileInfoOperator();


        private FileInfoOperator()
        {
        }

        #endregion
    }
}
