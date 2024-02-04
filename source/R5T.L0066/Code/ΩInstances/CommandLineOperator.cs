using System;


namespace R5T.L0066
{
    public class CommandLineOperator : ICommandLineOperator
    {
        #region Infrastructure

        public static ICommandLineOperator Instance { get; } = new CommandLineOperator();


        private CommandLineOperator()
        {
        }

        #endregion
    }
}
