using System;

using R5T.T0132;
using R5T.T0143;


namespace R5T.L0066.Implementations
{
    [FunctionalityMarker]
    public partial interface IFlagsOperator : IFunctionalityMarker,
        F10Y.L0000.Implementations.IFlagsOperator
    {
#pragma warning disable IDE1006 // Naming Styles

        [Ignore]
        public F10Y.L0000.Implementations.IFlagsOperator _F10Y_L0000 => F10Y.L0000.Implementations.FlagsOperator.Instance;

#pragma warning restore IDE1006 // Naming Styles
    }
}
