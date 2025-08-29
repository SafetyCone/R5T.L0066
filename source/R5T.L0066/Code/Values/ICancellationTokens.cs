using System;
using System.Threading;

using F10Y.T0011;

using R5T.T0131;


namespace R5T.L0066
{
    [ValuesMarker]
    public partial interface ICancellationTokens : IValuesMarker,
        F10Y.L0000.ICancellationTokens
    {
#pragma warning disable IDE1006 // Naming Styles

        [Ignore]
        public F10Y.L0000.ICancellationTokens _F10Y_L0000 => F10Y.L0000.CancellationTokens.Instance;

#pragma warning restore IDE1006 // Naming Styles
    }
}
