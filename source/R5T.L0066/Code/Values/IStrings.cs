using System;

using R5T.T0131;

using StringsDocumentation = R5T.Y0006.Documentation.ForStrings;


namespace R5T.L0066
{
    [ValuesMarker]
    public partial interface IStrings : IValuesMarker
    {
        /// <inheritdoc cref="StringsDocumentation.ForCommaSeparatedListSpacedSeparator"/>
        public const string CommaSeparatedListSpacedSeparator_Constant = ", ";

        /// <inheritdoc cref="CommaSeparatedListSpacedSeparator_Constant"/>
        public string CommaSeparatedListSpacedSeparator => IStrings.CommaSeparatedListSpacedSeparator_Constant;

        /// <inheritdoc cref="ICharacters.Copyright_Constant"/>
        public const string Copyright_Constant = "©";

        /// <inheritdoc cref="IStrings.Copyright_Constant"/>
        public string Copyright => IStrings.Copyright_Constant;

        /// <inheritdoc cref="StringsDocumentation.ForDoubleSpaces"/>
        public const string DoubleSpaces_Constant = "  ";

        /// <inheritdoc cref="DoubleSpaces_Constant"/>
        public string DoubleSpaces => IStrings.DoubleSpaces_Constant;

        /// <inheritdoc cref="StringsDocumentation.ForEmpty_Constant"/>
        public const string Empty_Constant = "";

        /// <inheritdoc cref="StringsDocumentation.ForEmpty"/>
        public string Empty => IStrings.Empty_Constant;

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
