using System;


namespace R5T.L0066
{
    public class ExecutableNames : IExecutableNames
    {
        #region Infrastructure

        public static IExecutableNames Instance { get; } = new ExecutableNames();


        private ExecutableNames()
        {
        }

        #endregion
    }
}
