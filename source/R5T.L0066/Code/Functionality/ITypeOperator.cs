using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using R5T.T0132;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface ITypeOperator : IFunctionalityMarker
    {
        /// <summary>
        /// Enumerates only the interfaces 
        /// </summary>
        /// <remarks>
        /// Source: <see href="https://stackoverflow.com/a/1613936/10658484"/>
        /// </remarks>
        public IEnumerable<Type> Enumerate_Interfaces_DirectlyImplementedOnly(Type type)
        {
            var interfaces = this.Enumerate_Interfaces(type);

            var hasBaseType = this.Has_BaseType(type);
            if (hasBaseType)
            {
                var interfaces_ForBaseType = type.BaseType.GetInterfaces();

                var output = interfaces.Except(interfaces_ForBaseType);
                return output;
            }
            else
            {
                var output = interfaces;
                return output;
            }
        }

        public IEnumerable<Type> Enumerate_Interfaces(Type type)
            => this.Get_Interfaces(type);

        public bool Equals(Type a, Type b)
            => a == b;

        public Type[] Get_Interfaces(Type type)
            => type.GetInterfaces();

        public Type[] Get_Interfaces_DirectlyImplementedOnly(Type type)
            => this.Enumerate_Interfaces_DirectlyImplementedOnly(type)
                .Now();

        /// <summary>
        /// Note, includes the generic parameter count. Example: ExampleClass01`1.
        /// <para>Gets the <see cref="MemberInfo.Name"/> of the type.</para>
        /// </summary>
        public string Get_Name(Type type)
            => type.Name;

        /// <inheritdoc cref="Get_NameOf(Type)"/>
        public string Get_NameOf<T>()
        {
            var type = this.Get_TypeOf<T>();

            var output = this.Get_NameOf(type);
            return output;
        }

        /// <summary>
        /// Quality-of-life overload for <see cref="Get_Name(Type)"/>.
        /// Returns <see cref="MemberInfo.Name"/> of the type.
        /// </summary>
        public string Get_NameOf(Type type)
            => this.Get_Name(type);

        public string Get_NamespaceName(Type type)
            => type.Namespace;

        /// <summary>
        /// Includes the generic parameter count (example: R5T.T0140.ExampleClass01`1),
        /// and handles nested types (example: R5T.T0225.T000.NestedType_001_Parent+NestedType_001_Child).
        /// <para>This replicates the behavior of <see cref="Type.FullName"/>.</para>
        /// </summary>
        /// <remarks>
        /// Can handle nested types, using the nested type name separator used by <see cref="Type.FullName"/> (which is <see cref="ITokenSeparators.NestedTypeNameTokenSeparator"/>).
        /// </remarks>
        public string Get_NamespacedTypeName(Type type)
        {
            var isNestedType = this.Is_NestedType(type);
            if (isNestedType)
            {
                var parentNamespacedTypeName = this.Get_NamespacedTypeName(type.DeclaringType);

                var basicTypeName = this.Get_Name(type);

                var output = $"{parentNamespacedTypeName}{Instances.TokenSeparators.NestedTypeNameTokenSeparator}{basicTypeName}";
                return output;
            }
            else
            {
                var namespaceName = this.Get_NamespaceName(type);
                var typeName = this.Get_Name(type);

                var namespacedTypeName = Instances.NamespacedTypeNameOperator.Get_NamespacedTypeName(
                    namespaceName,
                    typeName);

                return namespacedTypeName;
            }
        }

        /// <summary>
		/// Quality-of-life overload for <see cref="ITypeOperator.Get_NamespacedTypeName(Type)"/>.
		/// </summary>
		public string GetNamespacedTypeName_ForType(Type type)
        {
            return this.Get_NamespacedTypeName(type);
        }

        /// <summary>
		/// Quality-of-life overload for <see cref="ITypeOperator.Get_NamespacedTypeName(Type)"/>.
		/// </summary>
		public string GetNamespacedTypeName_ForTypeInfo(TypeInfo typeInfo)
        {
            return this.Get_NamespacedTypeName(typeInfo);
        }

        public string Get_NamespacedTypeName<T>()
        {
            var typeOfT = typeof(T);

            var output = this.Get_NamespacedTypeName(typeOfT);
            return output;
        }

        public string Get_NamespacedTypeNameOf<T>(T value)
        {
            var typeOfValue = this.Get_TypeOf(value);

            var output = this.Get_NamespacedTypeName(typeOfValue);
            return output;
        }

        /// <summary>
        /// Returns the <inheritdoc cref="Documentation.TypeNameMeansFullyQualifiedTypeName" path="/summary"/> of the type.
        /// </summary>
        public string Get_TypeName(Type type)
        {
            // The full name corresponds to our concept of type name.
            var typeName = type.FullName;
            return typeName;
        }

        /// <inheritdoc cref="Get_TypeName(Type)"/>
        public string Get_TypeNameOf<T>()
        {
            var type = this.Get_TypeOf<T>();

            // The full name corresponds to our concept of type name.
            var typeName = this.Get_TypeName(type);
            return typeName;
        }

        /// <inheritdoc cref="Get_TypeName(Type)"/>
        public string Get_TypeNameOf<T>(T value)
        {
            var type = this.Get_TypeOf(value);

            // The full name corresponds to our concept of type name.
            var typeName = this.Get_TypeName(type);
            return typeName;
        }

        /// <summary>
		/// Gets the type of the <typeparamref name="T"/>.
		/// Note: same as the typeof() operator.
		/// </summary>
		public Type Get_TypeOf<T>()
        {
            var output = typeof(T);
            return output;
        }

        public Type Get_TypeOf<T>(T instance)
        {
            var output = instance.GetType();
            return output;
        }

        public bool Has_AttributeOfType(
            Type type,
            string attributeTypeNamespacedTypeName,
            out CustomAttributeData attribute_OrDefault)
            => Instances.TypeInfoOperator.Has_AttributeOfType(
                type,
                attributeTypeNamespacedTypeName,
                out attribute_OrDefault);

        public bool Has_BaseType(Type type)
        {
            var hasBaseType = type.BaseType is object;
            return hasBaseType;
        }

        public bool Implements_InterfaceOfType_DirectOnly(
            Type type,
            string interfaceTypeName)
        {
            var output = this.Enumerate_Interfaces_DirectlyImplementedOnly(type)
                .Where(type_Interface => this.Is_NamespacedTypeName(
                    type_Interface,
                    interfaceTypeName)
                )
                .Any();

            return output;
        }

        public bool Is_NestedType(Type type)
        {
            var output = Instances.NullOperator.Is_NotNull(type.DeclaringType);
            return output;
        }

        public bool Is_NamespacedTypeName(
            Type type,
            string namespacedTypeName)
        {
            var type_NamespacedTypeName = this.GetNamespacedTypeName_ForType(type);

            var output = type_NamespacedTypeName == namespacedTypeName;
            return output;
        }

        /// <summary>
        /// Chooses <see cref="TypeCheckDeterminesEquality_Instance{T}(T, T, out bool)"/> as the default.
        /// </summary>
        /// <remarks>
        /// <inheritdoc cref="Documentation.TypeCheckDeterminesEquality" path="/summary"/>
        /// </remarks>
        public bool TypeCheckDeterminesEquality<T>(T a, T b, out bool typesAreEqual)
        {
            var output = this.TypeCheckDeterminesEquality_Instance(a, b, out typesAreEqual);
            return output;
        }

        /// <summary>
        /// Use the type returned by the <see cref="object.GetType"/> method of each instance to determine type by equality.
        /// </summary>
        /// <remarks>
        /// <inheritdoc cref="Documentation.TypeCheckDeterminesEquality" path="/summary"/>
        /// </remarks>
        public bool TypeCheckDeterminesEquality_Instance<T>(T a, T b, out bool typesAreEqual)
        {
            var typeA = a.GetType();
            var typeB = b.GetType();

            typesAreEqual = typeA == typeB;

            var typeDeterminesEquality = !typesAreEqual;
            return typeDeterminesEquality;
        }

        /// <summary>
        /// Use the type returned by the <see cref="object.GetType"/> method of each instance to determine type by equality.
        /// </summary>
        /// <remarks>
        /// <inheritdoc cref="Documentation.TypeCheckDeterminesEquality" path="/summary"/>
        /// </remarks>
        public bool TypeCheckDeterminesEquality_Instance<T1, T2>(
            T1 a,
            T2 b,
            Func<T1, T1, bool> if_TypesAreEqual)
        {
            var typeA = a.GetType();
            var typeB = b.GetType();

            var typesAreEqual = typeA == typeB;
            if(!typesAreEqual)
            {
                return false;
            }
            else
            {
                // Should always be true.
                if(b is T1 b_asT1)
                {
                    var output = if_TypesAreEqual(a, b_asT1);
                    return output;
                }
                else
                {
                    throw new Exception();
                }
            }
        }
    }
}
