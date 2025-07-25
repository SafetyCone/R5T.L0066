using System;

using R5T.T0132;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface IBooleanOperator : IFunctionalityMarker
    {
        public bool From(string valueString)
        {
            var output = Boolean.Parse(valueString);
            return output;
        }

        /// <summary>
        /// Outputs either <inheritdoc cref="F10Y.L0000.IStrings.True_Lowercase" path="descendant::value"/> or <inheritdoc cref="F10Y.L0000.IStrings.False_Lowercase" path="descendant::value"/>.
        /// </summary>
        public string ToString_Lower(bool value)
        {
            var representation = value
                ? Instances.Strings.True_Lowercase
                : Instances.Strings.False_Lowercase
                ;

            return representation;
        }

        public string ToString_Upper(bool value)
        {
            var representation = value
                ? Instances.Strings.True_Uppercase
                : Instances.Strings.False_Uppercase
                ;

            return representation;
        }

        /// <summary>
        /// Pascal case matches the default <see cref="Boolean.ToString()"/> behavior.
        /// </summary>
        public string ToString_PascalCase(bool value)
        {
            /// Note: default <see cref="Boolean.ToString()"/> behavior produces the Pascal case values.
            var representation = value
                ? Instances.Strings.True_PascalCase
                : Instances.Strings.False_PascalCase
                ;

            return representation;
        }

        /// <summary>
        /// Chooses <see cref="ToString_PascalCase(bool)"/> as the default to match the <see cref="Boolean.ToString()"/> behavior.
        /// </summary>
        public string ToString(bool value)
        {
            /// Default <see cref="Boolean.ToString()"/> behavior produces the <see cref="IStrings.True_PascalCase"/> and <see cref="IStrings.False_PascalCase"/> values.
            var representation = this.ToString_PascalCase(value);
            return representation;
        }

        public string To_String_YesNo(bool value)
            => value
            ? Instances.Strings.Yes
            : Instances.Strings.No
            ;

        public string To_String_SuccessOrFailure(bool value)
            => value
            ? Instances.Strings.Success
            : Instances.Strings.Failure
            ;

        /// <summary>
        /// Toggles true to false, or false to true.
        /// </summary>
        public bool Toggle(bool value)
        {
            var output = !value;
            return output;
        }
    }
}
