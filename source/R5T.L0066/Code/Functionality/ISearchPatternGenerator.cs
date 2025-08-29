using System;

using R5T.T0132;
using R5T.T0143;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface ISearchPatternGenerator : IFunctionalityMarker,
        F10Y.L0000.ISearchPatternOperator
    {
#pragma warning disable IDE1006 // Naming Styles

        [Ignore]
        public F10Y.L0000.ISearchPatternOperator _F10Y_L0000_SearchPatternOperator => F10Y.L0000.SearchPatternOperator.Instance;

#pragma warning restore IDE1006 // Naming Styles
    }
}
