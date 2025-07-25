using System;
using System.Collections.Generic;
using System.Linq;

using R5T.T0132;
using R5T.T0143;

using Glossary = R5T.Y0006.Glossary;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface ICharacterOperator : IFunctionalityMarker,
        F10Y.L0000.ICharacterOperator
    {
#pragma warning disable IDE1006 // Naming Styles

        [Ignore]
        public F10Y.L0000.IStringOperator _F10Y_L0000 => F10Y.L0000.StringOperator.Instance;

#pragma warning restore IDE1006 // Naming Styles

        public char Capitalize(char character)
        {
            var output = Char.ToUpperInvariant(character);
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
