using System;
using System.Linq;

using R5T.T0132;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface INamespacedTypeNameOperator : IFunctionalityMarker
    {
        public string Combine(params string[] tokens)
        {
            if (tokens.Length < 1)
            {
                return Instances.Strings.Empty;
            }

            if (tokens.Length < 2)
            {
                return tokens.First();
            }

            var tokenSeparator = this.Get_TokenSeparator();

            var output = Instances.StringOperator.Join(
                tokenSeparator,
                tokens);

            return output;
        }

        public string[] Get_NameParts(string namespacedTypeName)
        {
            var tokenSeparator = this.Get_TokenSeparator();

            var output = Instances.StringOperator.Split(
                tokenSeparator,
                namespacedTypeName);

            return output;
        }

        public string Get_NamespacedTypeName(
            string namespaceName,
            string typeName)
        {
            if (Instances.StringOperator.Is_NullOrEmpty(namespaceName))
            {
                return typeName;
            }

            var namespacedTypeName = this.Combine(namespaceName, typeName);
            return namespacedTypeName;
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

        public string Get_TokenSeparator_String()
        {
            var output = Instances.Strings.Period;
            return output;
        }

        public char Get_TokenSeparator_Character()
        {
            var output = Instances.Characters.Period;
            return output;
        }

        /// <summary>
        /// Chooses character as the default token separator type.
        /// </summary>
        public char Get_TokenSeparator()
        {
            var output = this.Get_TokenSeparator_Character();
            return output;
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
