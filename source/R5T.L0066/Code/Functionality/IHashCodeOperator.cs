using System;

using R5T.T0132;
using R5T.T0143;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface IHashCodeOperator : IFunctionalityMarker,
        F10Y.L0000.IHashCodeOperator
    {
#pragma warning disable IDE1006 // Naming Styles

        [Ignore]
        public F10Y.L0000.IHashCodeOperator _F10Y_L0000 => F10Y.L0000.HashCodeOperator.Instance;

#pragma warning restore IDE1006 // Naming Styles
    }
}
