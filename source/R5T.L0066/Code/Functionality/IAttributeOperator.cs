using System;
using System.Reflection;

using R5T.T0132;
using R5T.T0143;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface IAttributeOperator : IFunctionalityMarker,
        F10Y.L0000.IAttributeOperator
    {
#pragma warning disable IDE1006 // Naming Styles

        [Ignore]
        public F10Y.L0000.IAttributeOperator _F10Y_L0000 => F10Y.L0000.AttributeOperator.Instance;

#pragma warning restore IDE1006 // Naming Styles
    }
}
