using System;


namespace R5T.L0066
{
    public class ComparisonOperator : IComparisonOperator
    {
        #region Infrastructure

        public static IComparisonOperator Instance { get; } = new ComparisonOperator();


        private ComparisonOperator()
        {
        }

        #endregion
    }
}
