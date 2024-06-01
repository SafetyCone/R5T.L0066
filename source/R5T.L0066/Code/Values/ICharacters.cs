using System;

using R5T.T0131;

using CharactersDocumentation = R5T.Y0006.Documentation.ForCharacters;


namespace R5T.L0066
{
    [ValuesMarker]
    public partial interface ICharacters : IValuesMarker
    {
        /// <inheritdoc cref="CharactersDocumentation.ForAsterix"/>
        public const char Asterix_Constant = '*';

        /// <inheritdoc cref="Asterix_Constant"/>
        public char Asterix => ICharacters.Asterix_Constant;

        /// <inheritdoc cref="CharactersDocumentation.ForBackslash"/>
        public const char Backslash_Constant = '\\';

        /// <inheritdoc cref="Backslash_Constant"/>
        public char Backslash => ICharacters.Backslash_Constant;

        /// <inheritdoc cref="CharactersDocumentation.ForCarriageReturn"/>
        public const char CarriageReturn_Constant = '\r';

        /// <inheritdoc cref="CarriageReturn_Constant"/>
        public char CarriageReturn => ICharacters.CarriageReturn_Constant;

        /// <inheritdoc cref="CharactersDocumentation.ForColon"/>
        public const char Colon_Constant = ':';

        /// <inheritdoc cref="Colon_Constant"/>
        public char Colon => ICharacters.Colon_Constant;

        /// <inheritdoc cref="CharactersDocumentation.ForCopyright"/>
        public const char Copyright_Constant = '©';

        /// <inheritdoc cref="Copyright_Constant"/>
        public char Copyright => ICharacters.Copyright_Constant;

        /// <inheritdoc cref="CharactersDocumentation.ForEquals"/>
        public const char Equals_Constant = '=';

        /// <inheritdoc cref="Equals_Constant"/>
        public char Equals => ICharacters.Equals_Constant;

        /// <inheritdoc cref="CharactersDocumentation.For_Escape"/>
        public const char Escape_Constant = '\u001b'; // Hexadecimal for 27.

        /// <inheritdoc cref="Escape_Constant"/>
        public char Escape => ICharacters.Escape_Constant;

        /// <inheritdoc cref="CharactersDocumentation.ForNewLine"/>
        public const char NewLine_Constant = '\n';

        /// <inheritdoc cref="NewLine_Constant"/>
        public char NewLine => ICharacters.NewLine_Constant;

        /// <inheritdoc cref="CharactersDocumentation.ForPeriod"/>
        public const char Period_Constant = '.';

        /// <inheritdoc cref="Period_Constant"/>
        public char Period => ICharacters.Period_Constant;

        /// <inheritdoc cref="CharactersDocumentation.ForPipe"/>
        public const char Pipe_Constant = '|';

        /// <inheritdoc cref="Pipe_Constant"/>
        public char Pipe => ICharacters.Pipe_Constant;

        /// <inheritdoc cref="CharactersDocumentation.ForQuote"/>
        public const char Quote_Constant = '"';

        /// <inheritdoc cref="Quote_Constant"/>
        public char Quote => ICharacters.Quote_Constant;

        /// <inheritdoc cref="CharactersDocumentation.ForSlash"/>
        public const char Slash_Constant = '/';

        /// <inheritdoc cref="Slash_Constant"/>
        public char Slash => ICharacters.Slash_Constant;

        /// <inheritdoc cref="CharactersDocumentation.ForSemicolon"/>
        public const char Semicolon_Constant = ';';

        /// <inheritdoc cref="Semicolon_Constant"/>
        public char Semicolon => ICharacters.Semicolon_Constant;

        /// <inheritdoc cref="CharactersDocumentation.ForSpace"/>
        public const char Space_Constant = ' ';

        /// <inheritdoc cref="Space_Constant"/>
        public char Space => ICharacters.Space_Constant;

        /// <inheritdoc cref="CharactersDocumentation.For_Tab"/>
        public const char Tab_Constant = '\t';

        /// <inheritdoc cref="Tab_Constant"/>
        public char Tab => ICharacters.Tab_Constant;

        /// <inheritdoc cref="CharactersDocumentation.ForUnderscore"/>
        public const char Underscore_Constant = '_';

        /// <inheritdoc cref="Underscore_Constant"/>
        public char Underscore => ICharacters.Underscore_Constant;

#pragma warning disable IDE1006 // Naming Styles

        /// <inheritdoc cref="CharactersDocumentation.For_q"/>
        public const char q_Constant = 'q';

        /// <inheritdoc cref="q_Constant"/>
        public char q => ICharacters.q_Constant;

#pragma warning restore IDE1006 // Naming Styles
    }
}
