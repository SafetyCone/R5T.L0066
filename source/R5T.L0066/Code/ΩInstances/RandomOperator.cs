using System;


namespace R5T.L0066
{
    public class RandomOperator : IRandomOperator
    {
        #region Infrastructure

        public static IRandomOperator Instance { get; } = new RandomOperator();


        private RandomOperator()
        {
        }

        #endregion
    }
}
