using System;


namespace R5T.L0066
{
    public class DoubleOperator : IDoubleOperator
    {
        #region Infrastructure

        public static IDoubleOperator Instance { get; } = new DoubleOperator();


        private DoubleOperator()
        {
        }

        #endregion
    }
}
