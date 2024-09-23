using System;
using System.Text.RegularExpressions;

using R5T.T0131;
using R5T.T0143;


namespace R5T.L0066
{
    [ValuesMarker]
    public partial interface IRegexOptionSets : IValuesMarker
    {
#pragma warning disable IDE1006 // Naming Styles

        [Ignore]
        public Raw.IRegexOptionSets _Raw => Raw.RegexOptionSets.Instance;

#pragma warning restore IDE1006 // Naming Styles

        /// <inheritdoc cref="Raw.IRegexOptionSets.N_001"/>
        public RegexOptions None => _Raw.N_001;

        /// <inheritdoc cref="Raw.IRegexOptionSets.N_003"/>
        public RegexOptions IgnoreCase => _Raw.N_003;
    }
}
