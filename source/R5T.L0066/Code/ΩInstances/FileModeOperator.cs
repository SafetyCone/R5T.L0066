using System;


namespace R5T.L0066
{
    public class FileModeOperator : IFileModeOperator
    {
        #region Infrastructure

        public static IFileModeOperator Instance { get; } = new FileModeOperator();


        private FileModeOperator()
        {
        }

        #endregion
    }
}
