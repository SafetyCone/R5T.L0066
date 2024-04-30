using System;


namespace R5T.L0066
{
    public class DateOperator : IDateOperator
    {
        #region Infrastructure

        public static IDateOperator Instance { get; } = new DateOperator();


        private DateOperator()
        {
        }

        #endregion
    }
}
