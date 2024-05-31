using System;


namespace R5T.L0066
{
    public class EnvironmentVariableNames : IEnvironmentVariableNames
    {
        #region Infrastructure

        public static IEnvironmentVariableNames Instance { get; } = new EnvironmentVariableNames();


        private EnvironmentVariableNames()
        {
        }

        #endregion
    }
}
