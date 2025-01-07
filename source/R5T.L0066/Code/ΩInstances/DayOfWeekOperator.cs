using System;


namespace R5T.L0066
{
    public class DayOfWeekOperator : IDayOfWeekOperator
    {
        #region Infrastructure

        public static IDayOfWeekOperator Instance { get; } = new DayOfWeekOperator();


        private DayOfWeekOperator()
        {
        }

        #endregion
    }
}
