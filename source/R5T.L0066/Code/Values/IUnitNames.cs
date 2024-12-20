using System;

using R5T.T0131;
using R5T.T0143;


namespace R5T.L0066
{
    [ValuesMarker]
    public partial interface IUnitNames : IValuesMarker
    {
#pragma warning disable IDE1006 // Naming Styles

        [Ignore]
        public Raw.IUnitNames _Raw => Raw.UnitNames.Instance;

#pragma warning restore IDE1006 // Naming Styles
    }
}
