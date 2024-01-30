using System;


namespace R5T.L0066
{
    public class StackOperator : IStackOperator
    {
        #region Infrastructure

        public static IStackOperator Instance { get; } = new StackOperator();


        private StackOperator()
        {
        }

        #endregion
    }
}
