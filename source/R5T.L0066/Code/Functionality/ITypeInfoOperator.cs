using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using R5T.T0132;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface ITypeInfoOperator : IFunctionalityMarker
    {
        public void Foreach_MemberInfo(
            TypeInfo typeInfo,
            Action<MemberInfo> action)
        {
            var memberInfos = this.Get_MemberInfos(typeInfo);

            foreach (var memberInfo in memberInfos)
            {
                action(memberInfo);
            }
        }

        /// <summary>
        /// Note: does not include nested types (as those are provided by the declared types of an assembly).
        /// </summary>
        /// <remarks>
        /// Similar to <see cref="TypeInfo.DeclaredMembers"/>, but I have no idea what members that returns.
        /// </remarks>
        public IEnumerable<MemberInfo> Get_MemberInfos(TypeInfo typeInfo)
        {
            var output = Instances.EnumerableOperator.Empty<MemberInfo>()
                .Append(typeInfo.DeclaredConstructors)
                .Append(typeInfo.DeclaredMethods)
                .Append(typeInfo.DeclaredEvents)
                .Append(typeInfo.DeclaredFields)
                .Append(typeInfo.DeclaredProperties)
                // Do not include nested types.
                ;

            return output;
        }

        public bool Has_AttributeOfType(
            Type type,
            string attributeTypeNamespacedTypeName,
            out CustomAttributeData attribute_OrDefault)
            => Instances.MemberInfoOperator.Has_AttributeOfType(
                type,
                attributeTypeNamespacedTypeName,
                out attribute_OrDefault);
    }
}
