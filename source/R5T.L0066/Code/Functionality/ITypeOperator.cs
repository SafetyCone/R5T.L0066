using System;
using System.Reflection;
using R5T.T0132;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface ITypeOperator : IFunctionalityMarker
    {
        /// <summary>
        /// Note, includes the generic parameter count. Example: ExampleClass01`1.
        /// <para>Gets the <see cref="System.Reflection.MemberInfo.Name"/> of the type.</para>
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

        public bool Is_NestedType(Type type)
        {
            var output = Instances.NullOperator.Is_NotNull(type.DeclaringType);
            return output;
        }
    }
}
