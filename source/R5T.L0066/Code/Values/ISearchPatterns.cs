using System;

using R5T.T0131;
using R5T.T0143;


namespace R5T.L0066
{
    [ValuesMarker]
    public partial interface ISearchPatterns : IValuesMarker,
        F10Y.L0000.ISearchPatterns
    {
#pragma warning disable IDE1006 // Naming Styles

        [Ignore]
        public F10Y.L0000.ISearchPatterns _F10Y_L0000 => F10Y.L0000.SearchPatterns.Instance;

#pragma warning restore IDE1006 // Naming Styles
    }
}
