using System;
using System.Collections.Generic;

using R5T.T0132;
using R5T.T0143;


namespace R5T.L0066.Implementations
{
    [FunctionalityMarker]
    public partial interface IListOperator : IFunctionalityMarker,
        F10Y.L0000.Implementations.IListOperator
    {
#pragma warning disable IDE1006 // Naming Styles

        [Ignore]
        F10Y.L0000.Implementations.IListOperator _F10Y_L0000 => F10Y.L0000.Implementations.ListOperator.Instance;

#pragma warning restore IDE1006 // Naming Styles
    }
}
