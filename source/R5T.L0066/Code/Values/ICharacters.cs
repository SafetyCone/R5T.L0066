using System;

using R5T.T0131;

using CharactersDocumentation = R5T.Y0006.Documentation.ForCharacters;


namespace R5T.L0066
{
    [ValuesMarker]
    public partial interface ICharacters : IValuesMarker
    {
        /// <inheritdoc cref="CharactersDocumentation.ForBackslash"/>
        public const char Backslash_Constant = '\\';

        /// <inheritdoc cref="Backslash_Constant"/>
        public char Backslash => ICharacters.Backslash_Constant;

        /// <inheritdoc cref="CharactersDocumentation.ForCopyright"/>
        public const char Copyright_Constant = '©';

        /// <inheritdoc cref="Copyright_Constant"/>
        public char Copyright => ICharacters.Copyright_Constant;

        /// <inheritdoc cref="CharactersDocumentation.ForSlash"/>
        public const char Slash_Constant = '/';

        /// <inheritdoc cref="Slash_Constant"/>
        public char Slash => ICharacters.Slash_Constant;

        /// <inheritdoc cref="CharactersDocumentation.ForSemicolon"/>
        public const char Semicolon_Constant = ';';

        /// <inheritdoc cref="Semicolon_Constant"/>
        public char Semicolon => ICharacters.Semicolon_Constant;

        /// <inheritdoc cref="CharactersDocumentation.ForNewLine"/>
        public const char NewLine_Constant = '\n';

        /// <inheritdoc cref="NewLine_Constant"/>
        public char NewLine => ICharacters.NewLine_Constant;
    }
}
