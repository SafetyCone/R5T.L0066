using System;

using R5T.T0131;
using R5T.T0143;


namespace R5T.L0066
{
    [ValuesMarker]
    public partial interface IVersions : IValuesMarker,
        F10Y.L0000.IVersions
    {
#pragma warning disable IDE1006 // Naming Styles

        [Ignore]
        new Raw.IVersions _Raw => Raw.Versions.Instance;

#pragma warning restore IDE1006 // Naming Styles
    }
}
