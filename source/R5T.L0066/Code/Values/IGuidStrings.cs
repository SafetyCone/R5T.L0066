using System;

using R5T.T0131;
using R5T.T0143;


namespace R5T.L0066
{
    [ValuesMarker]
    public partial interface IGuidStrings : IValuesMarker
    {
#pragma warning disable IDE1006 // Naming Styles

        [Ignore]
        public Raw.IGuidStrings _Raw => Raw.GuidStrings.Instance;

#pragma warning restore IDE1006 // Naming Styles


        /// <inheritdoc cref="Raw.IGuidStrings._00000000_0000_0000_0000_000000000000"/>
        public string Default => _Raw._00000000_0000_0000_0000_000000000000;
    }
}
