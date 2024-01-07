using System;


namespace R5T.L0066
{
    public class FunctionOperator : IFunctionOperator
    {
        #region Infrastructure

        public static IFunctionOperator Instance { get; } = new FunctionOperator();


        private FunctionOperator()
        {
        }

        #endregion
    }
}
