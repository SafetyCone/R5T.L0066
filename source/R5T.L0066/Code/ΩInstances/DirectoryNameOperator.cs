using System;


namespace R5T.L0066
{
    public class DirectoryNameOperator : IDirectoryNameOperator
    {
        #region Infrastructure

        public static IDirectoryNameOperator Instance { get; } = new DirectoryNameOperator();


        private DirectoryNameOperator()
        {
        }

        #endregion
    }
}
