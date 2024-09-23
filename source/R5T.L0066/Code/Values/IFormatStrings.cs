using System;

using R5T.T0131;
using R5T.T0143;


namespace R5T.L0066
{
    [ValuesMarker]
    public partial interface IFormatStrings : IValuesMarker
    {
#pragma warning disable IDE1006 // Naming Styles

        [Ignore]
        public Raw.IFormatStrings _Raw => Raw.FormatStrings.Instance;

#pragma warning restore IDE1006 // Naming Styles


        /// <inheritdoc cref="Raw.IFormatStrings.F4"/>
        public string FourDecimalPlaces => _Raw.F4;
    }
}
