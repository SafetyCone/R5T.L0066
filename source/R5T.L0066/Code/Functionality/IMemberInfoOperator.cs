using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using R5T.T0132;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface IMemberInfoOperator : IFunctionalityMarker
    {
        /// <summary>
        /// Note: the <see cref="CustomAttributeData"/> type returned by <see cref="MemberInfo.CustomAttributes"/> is more useful than
        /// the <see cref="Attribute"/> type returned by <see cref="CustomAttributeExtensions.GetCustomAttributes(MemberInfo)"/>.
        /// </summary>
        public IEnumerable<CustomAttributeData> Get_Attributes(MemberInfo memberInfo)
        {
            var output = memberInfo.CustomAttributes;
            return output;
        }

        /// <summary>
        /// Returns the result of <see cref="MemberInfo.DeclaringType"/>.
        /// </summary>
        public Type Get_DeclaringType(MemberInfo memberInfo)
            => memberInfo.DeclaringType;

        public bool Has_AttributeOfType(
            MemberInfo memberInfo,
            string attributeNamespacedTypeName,
            out CustomAttributeData attribute_OrDefault)
        {
            attribute_OrDefault = this.Get_Attributes(memberInfo)
                .Where(Instances.AttributeOperator.Get_AttributeTypeNamespacedTypeName_Is(attributeNamespacedTypeName))
                // Choose first even though there might be multiple since this function is more like "Any()".
                .FirstOrDefault();

            var output = Instances.DefaultOperator.Is_NotDefault(attribute_OrDefault);
            return output;
        }

        public bool Has_AttributeOfType(
            MemberInfo memberInfo,
            string attributeNamespacedTypeName)
            => this.Has_AttributeOfType(
                memberInfo,
                attributeNamespacedTypeName,
                out _);

        public bool Has_DeclaringType(
            MemberInfo memberInfo,
            out Type declaringType)
        {
            declaringType = this.Get_DeclaringType(memberInfo);

            var output = Instances.DefaultOperator.Is_NotDefault(declaringType);
            return output;
        }

        public bool Has_DeclaringType(MemberInfo memberInfo)
            => this.Has_DeclaringType(
                memberInfo,
                out _);

        /// <summary>
        /// Simply evaluates the given member for whether it has the obsolete attribute.
        /// <para>Does <strong>not</strong> evaluate whether the member is within an obsolete type (for non-type members), or nested within an obsolete type (for type members).</para>
        /// </summary>
        public bool Is_Obsolete_Simple(MemberInfo memberInfo)
        {
            var hasObsoleteAttribute = this.Has_AttributeOfType(
                memberInfo,
                Instances.NamespacedTypeNames.System_ObsoleteAttribute,
                out _);

            return hasObsoleteAttribute;
        }

        /// <summary>
        /// Evaluates whether the given member is obsolete, or is declared in a type that is obsolete.
        /// <para>Does <strong>not</strong> evaluate whether the member is within an obsolete type (for non-type members), or nested within an obsolete type (for type members).</para>
        /// </summary>
        public bool Is_Obsolete_OrInObsoleteDeclaringType(MemberInfo memberInfo)
        {
            var isObsolete_Simple = this.Is_Obsolete_Simple(memberInfo);
            if(isObsolete_Simple)
            {
                return true;
            }

            // Else, if the 
            var hasDeclaringType = this.Has_DeclaringType(
                memberInfo,
                out var declaringType);

            if(hasDeclaringType)
            {
                var isObsolete_DeclaringType = this.Is_Obsolete_Simple(declaringType);
                if(isObsolete_DeclaringType)
                {
                    return true;
                }
            }

            // Else, not obsolete.
            return false;
        }

        /// <summary>
        /// Chooses <see cref="Is_Obsolete_Simple(MemberInfo)"/> as the default.
        /// <para><inheritdoc cref="Is_Obsolete_Simple(MemberInfo)" path="/summary"/></para>
        /// </summary>
        public bool Is_Obsolete(MemberInfo memberInfo)
        {
            var hasObsoleteAttribute = this.Has_AttributeOfType(
                memberInfo,
                Instances.NamespacedTypeNames.System_ObsoleteAttribute,
                out _);

            return hasObsoleteAttribute;
        }

        public bool Is_Public(MethodInfo methodInfo)
            => methodInfo.IsPublic;

        public bool Is_TypeInfo(
            MemberInfo memberInfo,
            out TypeInfo typeInfo_OrNull)
        {
            typeInfo_OrNull = memberInfo as TypeInfo;

            var output = Instances.NullOperator.Is_NotNull(typeInfo_OrNull);
            return output;
        }

        public bool Is_TypeInfo(MemberInfo memberInfo)
            => this.Is_TypeInfo(
                memberInfo,
                out _);

        public bool Is_TypeInfo_CheckMemberType(MemberInfo memberInfo)
            => memberInfo.MemberType == MemberTypes.TypeInfo;

        public void Verify_IsTypeInfo(MemberInfo memberInfo)
        {
            var isTypeInfo = this.Is_TypeInfo(memberInfo);

            if(!isTypeInfo)
            {
                throw new Exception($"MemberInfo was not a TypeInfo; found: {memberInfo}");
            }
        }
    }
}
