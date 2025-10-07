using System;

using R5T.T0131;
using R5T.T0143;


namespace R5T.L0066
{
    [ValuesMarker]
    public partial interface IUnitSymbols : IValuesMarker,
        F10Y.L0001.L000.IUnitSymbols
    {
#pragma warning disable IDE1006 // Naming Styles

        [Ignore]
        new Raw.IUnitSymbols _Raw => Raw.UnitSymbols.Instance;

#pragma warning restore IDE1006 // Naming Styles
    }
}
