using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using R5T.L0066.Extensions;
using R5T.T0132;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface IAssemblyOperator : IFunctionalityMarker
    {
        public IEnumerable<MemberInfo> Enumerate_Members(Assembly assembly)
        {
            var output = this.Enumerate_Types(assembly)
                .SelectMany(typeInfo => Instances.EnumerableOperator.Empty<MemberInfo>()
                    .Append(typeInfo)
                    .Append(
                        Instances.TypeInfoOperator.Get_MemberInfos(typeInfo)
                    )
                )
                ;

            return output;
        }

        /// <summary>
        /// Returns <see cref="Assembly.DefinedTypes"/>.
        /// </summary>
        public IEnumerable<TypeInfo> Enumerate_Types(Assembly assembly)
        {
            return assembly.DefinedTypes;
        }

        public void ForTypes(
            Assembly assembly,
            Func<TypeInfo, bool> typeSelector,
            Action<TypeInfo> action)
        {
            var types = this.Select_Types(assembly, typeSelector);

            types.For_Each(typeInfo => action(typeInfo));
        }

        /// <summary>
        /// Returns the entry-point .NET assembly.
        /// </summary>
        /// <remarks>
        /// Returns the result of <see cref="Assembly.GetEntryAssembly"/>.
        /// </remarks>
        public Assembly Get_EntryPointAssembly()
        {
            var output = Assembly.GetEntryAssembly();
            return output;
        }

        /// <summary>
        /// Get the path of the file containing the assembly.
        /// </summary>
        /// <remarks>
        /// Returns the <see cref="Assembly.Location"/> value.
        /// </remarks>
        public string Get_FilePath(Assembly assembly)
            => assembly.Location;

        /// <summary>
        /// Returns the .NET system assembly.
        /// </summary>
        /// <remarks>
        /// Returns the currently loaded assembly containing the <see cref="string"/> type.
        /// </remarks>
        public Assembly Get_SystemAssembly()
        {
            var output = typeof(string).Assembly;
            return output;
        }

        public IEnumerable<TypeInfo> Select_Types(
            Assembly assembly,
            Func<TypeInfo, bool> typeSelector)
        {
            var output = assembly.DefinedTypes
                .Where(typeSelector)
                ;

            return output;
        }
    }
}
