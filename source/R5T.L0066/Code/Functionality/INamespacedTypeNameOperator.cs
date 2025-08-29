using System;
using System.Linq;

using R5T.T0132;
using R5T.T0143;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface INamespacedTypeNameOperator : IFunctionalityMarker,
        F10Y.L0000.INamespacedTypeNameOperator
    {
#pragma warning disable IDE1006 // Naming Styles

        [Ignore]
        public F10Y.L0000.INamespacedTypeNameOperator _F10Y_L0000 => F10Y.L0000.NamespacedTypeNameOperator.Instance;

#pragma warning restore IDE1006 // Naming Styles


        public string[] Get_NameParts(string namespacedTypeName)
        {
            var tokenSeparator = this.Get_TokenSeparator();

            var output = Instances.StringOperator.Split(
                tokenSeparator,
                namespacedTypeName);

            return output;
        }

        /// <summary>
        /// Handles generic type names.
        /// </summary>
        public string Get_NamespacedTypeName_FromFullName(string fullTypeName)
        {
            var parts = fullTypeName.Split(
                Instances.Characters.OpenBracket);

            var namespacedTypeName = parts.First();
            return namespacedTypeName;
        }

        /// <summary>
        /// Note: Can handle types in the global namespace (those where the namespaced type name is just the type name).
        /// </summary>
        public string Get_NamespaceName(string namespacedTypeName)
        {
            var tokenSeparatorChar = this.Get_TokenSeparator_Character();

            var lastTokenSeparatorIndex = namespacedTypeName.LastIndexOf(tokenSeparatorChar);
            if (Instances.IndexOperator.Is_Found(lastTokenSeparatorIndex))
            {
                var namespaceName = namespacedTypeName[..(lastTokenSeparatorIndex)];
                return namespaceName;
            }
            else
            {
                // There is no namespace name, just a type name, indicating the type is in the global namespace.
                return Instances.Strings.Empty;
            }
        }

        /// <summary>
        /// Note: Can handle types in the global namespace (those where the namespaced type name is just the type name).
        /// </summary>
        public string Get_TypeName(string namespacedTypeName)
        {
            var nameparts = this.Get_NameParts(namespacedTypeName);

            var typeName = nameparts.Last();
            return typeName;
        }
    }
}
