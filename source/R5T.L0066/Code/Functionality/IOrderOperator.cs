using System;
using System.Collections.Generic;
using System.Linq;

using R5T.T0132;
using R5T.T0143;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface IOrderOperator : IFunctionalityMarker,
        F10Y.L0000.IOrderOperator
    {
#pragma warning disable IDE1006 // Naming Styles

        [Ignore]
        F10Y.L0000.IOrderOperator _F10Y_L0000 => F10Y.L0000.OrderOperator.Instance;

#pragma warning restore IDE1006 // Naming Styles
    }
}
