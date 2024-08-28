using System;
using System.Text.RegularExpressions;

using R5T.T0131;


namespace R5T.L0066.Raw
{
    [ValuesMarker]
    public partial interface IRegexOptionSets : IValuesMarker
    {
        /// <summary>
        /// <para><value><see cref="RegexOptions.None"/></value></para>
        /// </summary>
        public RegexOptions N_001 => RegexOptions.None;

        /// <summary>
        /// <para><value><see cref="RegexOptions.IgnoreCase"/></value></para>
        /// </summary>
        public RegexOptions N_002 => RegexOptions.IgnoreCase;

        /// <summary>
        /// <para><value><see cref="RegexOptions.IgnoreCase"/> | <see cref="RegexOptions.CultureInvariant"/></value></para>
        /// </summary>
        public RegexOptions N_003 =>
            RegexOptions.IgnoreCase
            | RegexOptions.CultureInvariant
            ;
    }
}
