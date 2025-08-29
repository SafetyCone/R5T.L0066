using System;

using F10Y.T0011;

using R5T.T0132;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface IFileNameOperator : IFunctionalityMarker,
        F10Y.L0000.IFileNameOperator
    {
#pragma warning disable IDE1006 // Naming Styles

        [Ignore]
        public F10Y.L0000.IFileNameOperator _F10Y_L0000 => F10Y.L0000.FileNameOperator.Instance;

#pragma warning restore IDE1006 // Naming Styles
    }
}
