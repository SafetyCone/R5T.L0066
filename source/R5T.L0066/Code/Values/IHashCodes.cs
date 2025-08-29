using System;

using R5T.T0131;
using R5T.T0143;


namespace R5T.L0066
{
    [ValuesMarker]
    public partial interface IHashCodes : IValuesMarker,
        F10Y.L0000.IHashCodes
    {
        [Ignore]
        public F10Y.L0000.IHashCodes _F10Y_L0000 => F10Y.L0000.HashCodes.Instance;
    }
}
