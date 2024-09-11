using System;
using System.Collections.Generic;
using System.Linq;

using R5T.T0132;

using Glossary = R5T.Y0006.Glossary;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface ICharacterOperator : IFunctionalityMarker
    {
        public char Capitalize(char character)
        {
            var output = Char.ToUpperInvariant(character);
            return output;
        }

        /// <summary>
        /// <inheritdoc cref="Y0006.Glossary.ForCharacterClasses.Whitespace" path="/definition"/>
        /// </summary>
        public bool Is_Whitespace(char character)
        {
            var output = Char.IsWhiteSpace(character);
            return output;
        }

        /// <inheritdoc cref="Is_Whitespace(char)"/>
        public bool Is_NotWhitespace(char character)
        {
            var isWhitespace = this.Is_Whitespace(character);

            var output = !isWhitespace;
            return output;
        }

        /// <summary>
        /// <inheritdoc cref="Glossary.ForCharacterClasses.Digit" path="/definition"/>
        /// </summary>
        public bool Is_Digit(char character)
        {
            // Use is-digit instead of is-number since is-number checks for fractions and Roman numerals as well.
            var output = Char.IsDigit(character);
            return output;
        }

        public string Join_ToString(IEnumerable<char> characters)
             => this.Join_ToString(characters.Now());

        public string Join_ToString(params char[] characters)
        {
            var output = new string(characters);
            return output;
        }

        /// <summary>
        /// Chooses the invariant lowering operation as default.
        /// </summary>
        public char ToLower(char character)
        {
            var output = Char.ToLowerInvariant(character);
            return output;
        }

        /// <summary>
        /// Chooses the invariant uppering operation as default.
        /// </summary>
        public char ToUpper(char character)
        {
            var output = Char.ToUpperInvariant(character);
            return output;
        }
    }
}
