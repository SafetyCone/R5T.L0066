using System;
using System.Text.RegularExpressions;

using R5T.T0132;

using RegularExpressionOptions = System.Text.RegularExpressions.RegexOptions;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface IRegexOperator : IFunctionalityMarker
    {
        public Regex Get_Regex(
            string pattern,
            RegularExpressionOptions options)
            => new Regex(
                pattern,
                options);

        public Regex Get_Regex_ConsiderCase(string pattern)
            => this.Get_Regex(
                pattern,
                Instances.RegexOptionSets.None);

        public Regex Get_Regex_IgnoreCase(string pattern)
            => this.Get_Regex(
                pattern,
                Instances.RegexOptionSets.IgnoreCase);

        /// <summary>
        /// Chooses <see cref="Get_Regex_ConsiderCase(string)"/> as the default.
        /// </summary>
        public Regex Get_Regex(string pattern)
            => this.Get_Regex_ConsiderCase(pattern);

        public Regex Get_Regex(
            string pattern,
            bool ignoreCase)
            => ignoreCase
            ? this.Get_Regex_IgnoreCase(pattern)
            : this.Get_Regex_ConsiderCase(pattern)
            ;

        public bool Is_Match(
            string @string,
            Regex regex)
            => regex.IsMatch(@string);

        public string Replace(
            string @string,
            Regex regex,
            string replacement)
        {
            var output = regex.Replace(
                @string,
                replacement);

            return output;
        }

        public string Replace(
            string @string,
            string regexPattern,
            string replacement)
        {
            var regex = this.Get_Regex(regexPattern);

            var output = this.Replace(
                @string,
                regex,
                replacement);

            return output;
        }
    }
}
