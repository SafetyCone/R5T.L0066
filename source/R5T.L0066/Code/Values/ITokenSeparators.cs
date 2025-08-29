using System;

using R5T.T0131;
using R5T.T0143;


namespace R5T.L0066
{
    [ValuesMarker]
    public partial interface ITokenSeparators : IValuesMarker,
        F10Y.L0000.ITokenSeparators
    {
#pragma warning disable IDE1006 // Naming Styles

        [Ignore]
        public F10Y.L0000.ITokenSeparators _F10Y_L0000 => F10Y.L0000.TokenSeparators.Instance;

#pragma warning restore IDE1006 // Naming Styles
    }
}
