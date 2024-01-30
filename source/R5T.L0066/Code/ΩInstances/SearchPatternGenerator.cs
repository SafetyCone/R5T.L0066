using System;


namespace R5T.L0066
{
    public class SearchPatternGenerator : ISearchPatternGenerator
    {
        #region Infrastructure

        public static ISearchPatternGenerator Instance { get; } = new SearchPatternGenerator();


        private SearchPatternGenerator()
        {
        }

        #endregion
    }
}
