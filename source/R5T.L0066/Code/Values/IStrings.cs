using System;

using R5T.T0131;
using R5T.T0143;

using StringsDocumentation = R5T.Y0006.Documentation.For_Strings;


namespace R5T.L0066
{
    [ValuesMarker]
    public partial interface IStrings : IValuesMarker,
        F10Y.L0000.IStrings
    {
#pragma warning disable IDE1006 // Naming Styles

        [Ignore]
        public F10Y.L0000.IStrings _F10Y_L0000 => F10Y.L0000.Strings.Instance;

#pragma warning restore IDE1006 // Naming Styles


        /// <inheritdoc cref="StringsDocumentation.ForColon"/>
        public const string Colon_Constant = "*";

        /// <inheritdoc cref="Colon_Constant"/>
        public string Colon => IStrings.Colon_Constant;

        /// <inheritdoc cref="StringsDocumentation.ForColonSeparatedListSpacedSeparator"/>
        public const string ColonSeparatedListSpacedSeparator_Constant = ": ";

        /// <inheritdoc cref="ColonSeparatedListSpacedSeparator_Constant"/>
        public string ColonSeparatedListSpacedSeparator => IStrings.ColonSeparatedListSpacedSeparator_Constant;

        /// <inheritdoc cref="StringsDocumentation.ForComma"/>
        public const string Comma_Constant = ",";

        /// <inheritdoc cref="IStrings.Comma_Constant"/>
        public string Comma => IStrings.Comma_Constant;

        /// <inheritdoc cref="StringsDocumentation.ForCommaSeparatedListSpacedSeparator"/>
        public const string CommaSeparatedListSpacedSeparator_Constant = ", ";

        /// <inheritdoc cref="CommaSeparatedListSpacedSeparator_Constant"/>
        public string CommaSpaceSeparatedListSeparator => IStrings.CommaSeparatedListSpacedSeparator_Constant;

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

        /// <inheritdoc cref="StringsDocumentation.ForEquals"/>
        public const string Equals_Constant = "=";

        /// <inheritdoc cref="Equals_Constant"/>
        public string Equals => IStrings.Equals_Constant;

        /// <inheritdoc cref="StringsDocumentation.For_ExclamationPoint"/>
        public const string ExclamationPoint_Constant = "!";

        /// <inheritdoc cref="ExclamationPoint_Constant"/>
        public string ExclamationPoint => IStrings.ExclamationPoint_Constant;

        /// <inheritdoc cref="StringsDocumentation.ForFalse_PascalCase"/>
        public const string False_PascalCase_Constant = "False";

        /// <inheritdoc cref="False_PascalCase_Constant"/>
        public string False_PascalCase => IStrings.False_Lowercase_Constant;

        /// <inheritdoc cref="StringsDocumentation.For_Percent"/>
        public const string Percent_Constant = "%";

        /// <inheritdoc cref="Percent_Constant"/>
        public string Percent => IStrings.Percent_Constant;

        /// <inheritdoc cref="StringsDocumentation.ForPipe"/>
        public const string Pipe_Constant = "|";

        /// <inheritdoc cref="Pipe_Constant"/>
        public string Pipe => IStrings.Pipe_Constant;

        /// <inheritdoc cref="StringsDocumentation.ForQuestionMark"/>
        public const string QuestionMark_Constant = "?";

        /// <inheritdoc cref="QuestionMark_Constant"/>
        public string QuestionMark => IStrings.QuestionMark_Constant;

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

        /// <inheritdoc cref="StringsDocumentation.ForTrue_PascalCase"/>
        public const string True_PascalCase_Constant = "True";

        /// <inheritdoc cref="True_PascalCase_Constant"/>
        public string True_PascalCase => IStrings.True_Lowercase_Constant;

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
