using System;


namespace R5T.L0066
{
    public class DateTimeOffsetOperator : IDateTimeOffsetOperator
    {
        #region Infrastructure

        public static IDateTimeOffsetOperator Instance { get; } = new DateTimeOffsetOperator();


        private DateTimeOffsetOperator()
        {
        }

        #endregion
    }
}
