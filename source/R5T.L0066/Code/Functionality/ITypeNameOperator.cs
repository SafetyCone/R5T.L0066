using System;

using R5T.T0132;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface ITypeNameOperator : IFunctionalityMarker,
        F10Y.L0000.ITypeNameOperator
    {
        public string Get_AttributeNameFromAttributeTypeName(
            string attributeTypeName)
        {
            var hasAttributeTypeNameSuffix = this.Has_AttributeTypeNameSuffix(attributeTypeName);
            if (hasAttributeTypeNameSuffix)
            {
                var output = this.Get_NonAttributeSuffixedTypeName(attributeTypeName);
                return output;
            }
            else
            {
                throw new ArgumentException($"Attribute type name '{attributeTypeName}' did not have attribute suffix.");
            }
        }

        public string Get_NonAttributeSuffixedTypeName(string attributeSuffixedTypeName)
        {
            var output = Instances.StringOperator.Except_Ending(
                attributeSuffixedTypeName,
                Instances.TypeNameAffixes.AttributeSuffix);

            return output;
        }

        public new string Get_TypeNameOf<T>(T instance)
        {
            var output = Instances.TypeOperator.Get_TypeNameOf(instance);
            return output;
        }

        /// <summary>
        /// Quality-of-life overload for <see cref="Is_AttributeSuffixedTypeName(string)"/>.
        /// </summary>
        public bool Has_AttributeTypeNameSuffix(string typeName)
        {
            var output = this.Is_AttributeSuffixedTypeName(typeName);
            return output;
        }

        public bool Is_AttributeSuffixedTypeName(string typeName)
        {
            var output = Instances.StringOperator.EndsWith(
                typeName,
                Instances.TypeNameAffixes.AttributeSuffix);

            return output;
        }
    }
}
