using System;


namespace R5T.L0066
{
    public class DecimalOperator : IDecimalOperator
    {
        #region Infrastructure

        public static IDecimalOperator Instance { get; } = new DecimalOperator();


        private DecimalOperator()
        {
        }

        #endregion
    }
}
