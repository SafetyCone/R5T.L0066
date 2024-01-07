using System;


namespace R5T.L0066
{
    public class FileOperator : IFileOperator
    {
        #region Infrastructure

        public static IFileOperator Instance { get; } = new FileOperator();


        private FileOperator()
        {
        }

        #endregion
    }
}
