using System;


namespace R5T.L0066
{
    public class TimeSpanOperator : ITimeSpanOperator
    {
        #region Infrastructure

        public static ITimeSpanOperator Instance { get; } = new TimeSpanOperator();


        private TimeSpanOperator()
        {
        }

        #endregion
    }
}
