using System;
using System.Reflection;

using R5T.T0132;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface IAssemblyOperator : IFunctionalityMarker
    {
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
    }
}
