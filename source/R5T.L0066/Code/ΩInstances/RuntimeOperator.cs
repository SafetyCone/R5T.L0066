using System;


namespace R5T.L0066
{
    public class RuntimeOperator : IRuntimeOperator
    {
        #region Infrastructure

        public static IRuntimeOperator Instance { get; } = new RuntimeOperator();


        private RuntimeOperator()
        {
        }

        #endregion
    }
}


namespace R5T.L0066.Implementations
{
    public class RuntimeOperator : IRuntimeOperator
    {
        #region Infrastructure

        public static IRuntimeOperator Instance { get; } = new RuntimeOperator();


        private RuntimeOperator()
        {
        }

        #endregion
    }
}