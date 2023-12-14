using System;

using R5T.T0132;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface ICharacterOperator : IFunctionalityMarker
    {
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
    }
}
