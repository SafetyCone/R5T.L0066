using System;


namespace R5T.L0066
{
    public class ComparisonResults : IComparisonResults
    {
        #region Infrastructure

        public static IComparisonResults Instance { get; } = new ComparisonResults();


        private ComparisonResults()
        {
        }

        #endregion
    }
}
