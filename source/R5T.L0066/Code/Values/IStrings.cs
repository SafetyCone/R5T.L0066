using System;

using R5T.T0131;

using StringsDocumentation = R5T.Y0006.Documentation.For_Strings;


namespace R5T.L0066
{
    [ValuesMarker]
    public partial interface IStrings : IValuesMarker
    {
        #region Capital Letters

        /// <inheritdoc cref="StringsDocumentation.For_A"/>
        public const string A_Constant = "A";

        /// <inheritdoc cref="A_Constant"/>
        public string A => IStrings.A_Constant;

        /// <inheritdoc cref="StringsDocumentation.For_B"/>
        public const string B_Constant = "B";

        /// <inheritdoc cref="B_Constant"/>
        public string B => IStrings.B_Constant;

        /// <inheritdoc cref="StringsDocumentation.For_C"/>
        public const string C_Constant = "C";

        /// <inheritdoc cref="C_Constant"/>
        public string C => IStrings.C_Constant;

        /// <inheritdoc cref="StringsDocumentation.For_D"/>
        public const string D_Constant = "D";

        /// <inheritdoc cref="D_Constant"/>
        public string D => IStrings.D_Constant;

        /// <inheritdoc cref="StringsDocumentation.For_E"/>
        public const string E_Constant = "E";

        /// <inheritdoc cref="E_Constant"/>
        public string E => IStrings.E_Constant;

        #endregion

        /// <inheritdoc cref="StringsDocumentation.ForAsterix"/>
        public const string Asterix_Constant = "*";

        /// <inheritdoc cref="Asterix_Constant"/>
        public string Asterix => IStrings.Asterix_Constant;

        /// <inheritdoc cref="StringsDocumentation.ForComma"/>
        public const string Comma_Constant = ",";

        /// <inheritdoc cref="IStrings.Comma_Constant"/>
        public string Comma => IStrings.Comma_Constant;

        /// <inheritdoc cref="StringsDocumentation.ForCommaSeparatedListSpacedSeparator"/>
        public const string CommaSeparatedListSpacedSeparator_Constant = ", ";

        /// <inheritdoc cref="CommaSeparatedListSpacedSeparator_Constant"/>
        public string CommaSpaceSeparatedListSeparator => IStrings.CommaSeparatedListSpacedSeparator_Constant;

        /// <inheritdoc cref="ICharacters.Copyright_Constant"/>
        public const string Copyright_Constant = "©";

        /// <inheritdoc cref="IStrings.Copyright_Constant"/>
        public string Copyright => IStrings.Copyright_Constant;

        /// <inheritdoc cref="StringsDocumentation.ForDoubleDash"/>
        public const string DoubleDash_Constant = "--";

        /// <inheritdoc cref="DoubleDash_Constant"/>
        public string DoubleDash => IStrings.DoubleDash_Constant;

        /// <inheritdoc cref="StringsDocumentation.ForDoubleDot"/>
        public const string DoubleDot_Constant = "..";

        /// <inheritdoc cref="DoubleDot_Constant"/>
        public string DoubleDot => IStrings.DoubleDot_Constant;

        /// <inheritdoc cref="StringsDocumentation.ForDoubleSpaces"/>
        public const string DoubleSpaces_Constant = "  ";

        /// <inheritdoc cref="DoubleSpaces_Constant"/>
        public string DoubleSpaces => IStrings.DoubleSpaces_Constant;

        /// <inheritdoc cref="StringsDocumentation.For_Ellipsis"/>
        public const string Ellipsis_Constant = "...";

        /// <inheritdoc cref="Ellipsis_Constant"/>
        public string Ellipsis => IStrings.Ellipsis_Constant;

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

        /// <inheritdoc cref="StringsDocumentation.ForHyphen"/>
        public const string Hyphen_Constant = "-";

        /// <inheritdoc cref="Hyphen_Constant"/>
        public string Hyphen => IStrings.Hyphen_Constant;

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

        /// <inheritdoc cref="StringsDocumentation.For_Percent"/>
        public const string Percent_Constant = "%";

        /// <inheritdoc cref="Percent_Constant"/>
        public string Percent => IStrings.Percent_Constant;

        /// <inheritdoc cref="StringsDocumentation.For_Period"/>
        public const string Period_Constant = ".";

        /// <inheritdoc cref="Period_Constant"/>
        public string Period => IStrings.Period_Constant;

        /// <inheritdoc cref="StringsDocumentation.ForPipe"/>
        public const string Pipe_Constant = "|";

        /// <inheritdoc cref="Pipe_Constant"/>
        public string Pipe => IStrings.Pipe_Constant;

        /// <inheritdoc cref="StringsDocumentation.ForQuestionMark"/>
        public const string QuestionMark_Constant = "?";

        /// <inheritdoc cref="QuestionMark_Constant"/>
        public string QuestionMark => IStrings.QuestionMark_Constant;

        /// <inheritdoc cref="StringsDocumentation.ForQuote"/>
        public const string Quote_Constant = "\"";

        /// <inheritdoc cref="Quote_Constant"/>
        public string Quote => IStrings.Quote_Constant;

        /// <inheritdoc cref="StringsDocumentation.ForSpace"/>
        public const string Space_Constant = " ";

        /// <inheritdoc cref="Space_Constant"/>
        public string Space => IStrings.Space_Constant;

        /// <inheritdoc cref="StringsDocumentation.ForSlash"/>
        public const string Semicolon_Constant = ";";

        /// <inheritdoc cref="Semicolon_Constant"/>
        public string Semicolon => IStrings.Semicolon_Constant;

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

        /// <summary>
        /// <para><value>yes</value></para>
        /// </summary>
        public string Yes_Lowercase => "yes";

        /// <summary>
        /// <para><value>Yes</value></para>
        /// </summary>
        public string Yes_PascalCase => "Yes";

        /// <summary>
        /// <para><value>YES</value></para>
        /// </summary>
        public string Yes_UpperCase => "YES";

        /// <summary>
        /// Chooses <see cref="Yes_UpperCase"/> as the default.
        /// </summary>
        public string Yes => this.Yes_UpperCase;

        /// <summary>
        /// <para><value>no</value></para>
        /// </summary>
        public string No_Lowercase => "no";

        /// <summary>
        /// <para><value>No</value></para>
        /// </summary>
        public string No_PascalCase => "No";

        /// <summary>
        /// <para><value>NO</value></para>
        /// </summary>
        public string No_UpperCase => "NO";

        /// <summary>
        /// Chooses <see cref="No_UpperCase"/> as the default.
        /// </summary>
        public string No => this.No_UpperCase;

        /// <summary>
        /// <para><value>SUCCESS</value></para>
        /// </summary>
        public string Success => "SUCCESS";

        /// <summary>
        /// <para><value>FAILURE</value></para>
        /// </summary>
        public string Failure => "FAILURE";
    }
}
