using System;

using R5T.T0131;


namespace R5T.L0066
{
    [ValuesMarker]
    public partial interface ITokenSeparators : IValuesMarker
    {
        /// <summary>
        /// <para><name>'+' (plus)</name></para>
        /// Separates tokens in a nested type name (parent type name, child type name) from each other.
        /// </summary>
        public const char NestedTypeNameTokenSeparator_Constant = '+';

        /// <inheritdoc cref="NestedTypeNameTokenSeparator_Constant"/>
        public char NestedTypeNameTokenSeparator => NestedTypeNameTokenSeparator_Constant;
    }
}
