using System;

using R5T.T0131;

using StringsDocumentation = R5T.Y0006.Documentation.ForStrings;


namespace R5T.L0066
{
    [ValuesMarker]
    public partial interface IStrings : IValuesMarker
    {
        /// <inheritdoc cref="StringsDocumentation.ForAsterix"/>
        public const string Asterix_Constant = "*";

        /// <inheritdoc cref="Asterix_Constant"/>
        public string Asterix => IStrings.Asterix_Constant;

        /// <inheritdoc cref="StringsDocumentation.ForCommaSeparatedListSpacedSeparator"/>
        public const string CommaSeparatedListSpacedSeparator_Constant = ", ";

        /// <inheritdoc cref="CommaSeparatedListSpacedSeparator_Constant"/>
        public string CommaSpaceSeparatedListSeparator => IStrings.CommaSeparatedListSpacedSeparator_Constant;

        /// <inheritdoc cref="ICharacters.Copyright_Constant"/>
        public const string Copyright_Constant = "©";

        /// <inheritdoc cref="IStrings.Copyright_Constant"/>
        public string Copyright => IStrings.Copyright_Constant;

        /// <inheritdoc cref="StringsDocumentation.ForDoubleDot"/>
        public const string DoubleDot_Constant = "..";

        /// <inheritdoc cref="DoubleDot_Constant"/>
        public string DoubleDot => IStrings.DoubleDot_Constant;

        /// <inheritdoc cref="StringsDocumentation.ForDoubleSpaces"/>
        public const string DoubleSpaces_Constant = "  ";

        /// <inheritdoc cref="DoubleSpaces_Constant"/>
        public string DoubleSpaces => IStrings.DoubleSpaces_Constant;

        /// <inheritdoc cref="StringsDocumentation.ForEmpty_Constant"/>
        public const string Empty_Constant = "";

        /// <inheritdoc cref="StringsDocumentation.ForEmpty"/>
        public string Empty => IStrings.Empty_Constant;

        /// <inheritdoc cref="StringsDocumentation.ForEquals"/>
        public const string Equals_Constant = "=";

        /// <inheritdoc cref="Equals_Constant"/>
        public string Equals => IStrings.Equals_Constant;

        /// <inheritdoc cref="StringsDocumentation.ForFalse_Lowercase"/>
        public const string False_Lowercase_Constant = "false";

        /// <inheritdoc cref="False_Lowercase_Constant"/>
        public string False_Lowercase => IStrings.False_Lowercase_Constant;

        /// <inheritdoc cref="StringsDocumentation.ForFalse_PascalCase"/>
        public const string False_PascalCase_Constant = "False";

        /// <inheritdoc cref="False_PascalCase_Constant"/>
        public string False_PascalCase => IStrings.False_Lowercase_Constant;

        /// <inheritdoc cref="StringsDocumentation.ForFalse_Uppercase"/>
        public const string False_Uppercase_Constant = "FALSE";

        /// <inheritdoc cref="False_Uppercase_Constant"/>
        public string False_Uppercase => IStrings.False_Uppercase_Constant;

        /// <inheritdoc cref="StringsDocumentation.ForNewLine"/>
        public const string NewLine_Constant = "\n";

        /// <inheritdoc cref="NewLine_Constant"/>
        public string NewLine => IStrings.NewLine_Constant;

        /// <inheritdoc cref="IStringOperator.Get_NewLine_ForEnvironment"/>
        public string NewLine_ForEnvironment => Instances.StringOperator.Get_NewLine_ForEnvironment();

        /// <inheritdoc cref="StringsDocumentation.ForNewLine_Windows"/>
        public const string NewLine_Windows_Constant = "\r\n";

        /// <inheritdoc cref="NewLine_Windows_Constant"/>
        public string NewLine_Windows => IStrings.NewLine_Windows_Constant;

        /// <inheritdoc cref="NewLine_Constant"/>
        public const string NewLine_NonWindows_Constant = IStrings.NewLine_Constant;

        /// <inheritdoc cref="NewLine_NonWindows_Constant"/>
        public string NewLine_NonWindows => IStrings.NewLine_NonWindows_Constant;

        /// <inheritdoc cref="StringsDocumentation.ForPeriod"/>
        public const string Period_Constant = ".";

        /// <inheritdoc cref="Period_Constant"/>
        public string Period => IStrings.Period_Constant;

        /// <inheritdoc cref="StringsDocumentation.ForPipe"/>
        public const string Pipe_Constant = "|";

        /// <inheritdoc cref="Pipe_Constant"/>
        public string Pipe => IStrings.Pipe_Constant;

        /// <inheritdoc cref="StringsDocumentation.ForQuote"/>
        public const string Quote_Constant = "\"";

        /// <inheritdoc cref="Quote_Constant"/>
        public string Quote => IStrings.Quote_Constant;

        /// <inheritdoc cref="StringsDocumentation.ForSpace"/>
        public const string Space_Constant = " ";

        /// <inheritdoc cref="Space_Constant"/>
        public string Space => IStrings.Space_Constant;

        /// <inheritdoc cref="StringsDocumentation.ForSlash"/>
        public const string Slash_Constant = "/";

        /// <inheritdoc cref="Slash_Constant"/>
        public string Slash => IStrings.Slash_Constant;

        /// <inheritdoc cref="StringsDocumentation.ForTab"/>
        public const string Tab_Constant = "\t";

        /// <inheritdoc cref="Tab_Constant"/>
        public string Tab => IStrings.Tab_Constant;

        /// <inheritdoc cref="StringsDocumentation.ForTab_AsFourSpaces"/>
        public const string Tab_AsFourSpaces_Constant = "    ";

        /// <inheritdoc cref="Tab_AsFourSpaces_Constant"/>
        public string Tab_AsFourSpaces => IStrings.Tab_AsFourSpaces_Constant;

        /// <inheritdoc cref="Tab_AsFourSpaces_Constant"/>
        public const string Tab_AsSpaces_Constant = IStrings.Tab_AsFourSpaces_Constant;

        /// <inheritdoc cref="Tab_AsSpaces_Constant"/>
        public string Tab_AsSpaces => IStrings.Tab_AsSpaces_Constant;

        /// <inheritdoc cref="StringsDocumentation.ForTripleSlashes"/>
        public const string Triple_Slashes_Constant = "///";

        /// <inheritdoc cref="Triple_Slashes_Constant"/>
        public string Triple_Slashes => IStrings.Triple_Slashes_Constant;


        /// <inheritdoc cref="StringsDocumentation.ForTrue_Lowercase"/>
        public const string True_Lowercase_Constant = "true";

        /// <inheritdoc cref="True_Lowercase_Constant"/>
        public string True_Lowercase => IStrings.True_Lowercase_Constant;

        /// <inheritdoc cref="StringsDocumentation.ForTrue_PascalCase"/>
        public const string True_PascalCase_Constant = "True";

        /// <inheritdoc cref="True_PascalCase_Constant"/>
        public string True_PascalCase => IStrings.True_Lowercase_Constant;

        /// <inheritdoc cref="StringsDocumentation.ForTrue_Uppercase"/>
        public const string True_Uppercase_Constant = "TRUE";

        /// <inheritdoc cref="True_Uppercase_Constant"/>
        public string True_Uppercase => IStrings.True_Uppercase_Constant;

        /// <summary>
        /// Chooses <see cref="True_PascalCase"/> as the default.
        /// </summary>
        public string True => this.True_PascalCase;
    }
}
