using System;


namespace R5T.L0066
{
    public class IntegerOperator : IIntegerOperator
    {
        #region Infrastructure

        public static IIntegerOperator Instance { get; } = new IntegerOperator();


        private IntegerOperator()
        {
        }

        #endregion
    }
}
