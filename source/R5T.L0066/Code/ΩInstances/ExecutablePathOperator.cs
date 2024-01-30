using System;


namespace R5T.L0066
{
    public class ExecutablePathOperator : IExecutablePathOperator
    {
        #region Infrastructure

        public static IExecutablePathOperator Instance { get; } = new ExecutablePathOperator();


        private ExecutablePathOperator()
        {
        }

        #endregion
    }
}


namespace R5T.L0066.Implementations
{
    public class ExecutablePathOperator : IExecutablePathOperator
    {
        #region Infrastructure

        public static IExecutablePathOperator Instance { get; } = new ExecutablePathOperator();


        private ExecutablePathOperator()
        {
        }

        #endregion
    }
}
