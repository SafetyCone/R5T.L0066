using System;


namespace R5T.L0066
{
    public class DirectoryInfoOperator : IDirectoryInfoOperator
    {
        #region Infrastructure

        public static IDirectoryInfoOperator Instance { get; } = new DirectoryInfoOperator();


        private DirectoryInfoOperator()
        {
        }

        #endregion
    }
}
