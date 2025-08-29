using System;
using System.IO;

using R5T.T0132;
using R5T.T0143;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface IFileStreamOperator : IFunctionalityMarker,
        F10Y.L0000.IFileStreamOperator
    {
#pragma warning disable IDE1006 // Naming Styles

        [Ignore]
        public F10Y.L0000.IFileStreamOperator _F10Y_L0000 => F10Y.L0000.FileStreamOperator.Instance;

#pragma warning restore IDE1006 // Naming Styles
    }
}
