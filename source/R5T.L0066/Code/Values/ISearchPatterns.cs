using System;

using R5T.T0131;


namespace R5T.L0066
{
    [ValuesMarker]
    public partial interface ISearchPatterns : IValuesMarker
    {
        public string All => Instances.Strings.Asterix;
    }
}
