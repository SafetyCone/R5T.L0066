using System;

using R5T.T0131;
using R5T.T0143;


namespace R5T.L0066
{
    [ValuesMarker]
    public partial interface IPredicates : IValuesMarker,
        F10Y.L0000.IPredicates
    {
#pragma warning disable IDE1006 // Naming Styles

        [Ignore]
        public F10Y.L0000.IPredicates _F10Y_L0000 => F10Y.L0000.Predicates.Instance;

#pragma warning restore IDE1006 // Naming Styles
    }


    [ValuesMarker]
    public partial interface IPredicates<T> : IValuesMarker,
        F10Y.L0000.IPredicates<T>
    {
#pragma warning disable IDE1006 // Naming Styles

        [Ignore]
        public F10Y.L0000.IPredicates<T> _F10Y_L0000 => F10Y.L0000.Predicates<T>.Instance;

#pragma warning restore IDE1006 // Naming Styles
    }
}
