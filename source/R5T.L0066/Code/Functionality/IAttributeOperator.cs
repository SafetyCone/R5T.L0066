using System;
using System.Reflection;

using R5T.T0132;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface IAttributeOperator : IFunctionalityMarker
    {
        public Func<CustomAttributeData, bool> Get_AttributeTypeNamespacedTypeName_Is(string attributeTypeNamespacedTypeName)
        {
            bool Internal(CustomAttributeData attribute)
            {
                var output = this.Is_TypeNamespacedTypeName(
                    attribute,
                    attributeTypeNamespacedTypeName);

                return output;
            }

            return Internal;
        }

        public string Get_TypeNamespacedTypeName(CustomAttributeData attribute)
        {
            var output = Instances.TypeOperator.Get_NamespacedTypeName(attribute.AttributeType);
            return output;
        }

        public bool Is_TypeNamespacedTypeName(
            CustomAttributeData attribute,
            string attributeTypeNamespacedTypeName)
        {
            var namespacedTypeName = this.Get_TypeNamespacedTypeName(attribute);

            var output = namespacedTypeName == attributeTypeNamespacedTypeName;
            return output;
        }
    }
}
