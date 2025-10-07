using System;
using System.Collections.Generic;

using F10Y.T0011;

using R5T.T0132;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface IMachineNameOperator : IFunctionalityMarker,
        F10Y.L0000.IMachineNameOperator
    {
#pragma warning disable IDE1006 // Naming Styles

        [Ignore]
        F10Y.L0000.IMachineNameOperator _F10Y_L0000 => F10Y.L0000.MachineNameOperator.Instance;

#pragma warning restore IDE1006 // Naming Styles
    }
}
