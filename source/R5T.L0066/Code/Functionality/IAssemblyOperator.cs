using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using R5T.L0066.Extensions;
using R5T.T0132;
using R5T.T0143;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface IAssemblyOperator : IFunctionalityMarker,
        F10Y.L0000.IAssemblyOperator
    {
#pragma warning disable IDE1006 // Naming Styles

        [Ignore]
        public F10Y.L0000.IAssemblyOperator _F10Y_L0000 => F10Y.L0000.AssemblyOperator.Instance;

#pragma warning restore IDE1006 // Naming Styles


        public void ForTypes(
            Assembly assembly,
            Func<TypeInfo, bool> typeSelector,
            Action<TypeInfo> action)
        {
            var types = this.Select_Types(assembly, typeSelector);

            types.For_Each(typeInfo => action(typeInfo));
        }

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
