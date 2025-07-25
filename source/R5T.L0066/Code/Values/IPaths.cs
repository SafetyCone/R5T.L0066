using System;

using R5T.T0131;


namespace R5T.L0066
{
    [ValuesMarker]
    public partial interface IPaths : IValuesMarker
    {
        /// <summary>
        /// <inheritdoc cref="F10Y.L0000.IStrings.Empty" path="/summary"/>
        /// The empty path.
        /// </summary>
        public string EmptyPath => Instances.Strings.Empty;
    }
}
