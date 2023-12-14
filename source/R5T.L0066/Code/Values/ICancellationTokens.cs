using System;
using System.Threading;

using R5T.T0131;


namespace R5T.L0066
{
    [ValuesMarker]
    public partial interface ICancellationTokens : IValuesMarker
    {
        public CancellationToken None => CancellationToken.None;
    }
}
