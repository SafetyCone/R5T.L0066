using System;


namespace R5T.L0066
{
    public class RegexOptionSets : IRegexOptionSets
    {
        #region Infrastructure

        public static IRegexOptionSets Instance { get; } = new RegexOptionSets();


        private RegexOptionSets()
        {
        }

        #endregion
    }
}


namespace R5T.L0066.Raw
{
    public class RegexOptionSets : IRegexOptionSets
    {
        #region Infrastructure

        public static IRegexOptionSets Instance { get; } = new RegexOptionSets();


        private RegexOptionSets()
        {
        }

        #endregion
    }
}
