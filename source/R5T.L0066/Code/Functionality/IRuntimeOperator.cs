using System;
using System.Runtime.InteropServices;

using R5T.T0132;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface IRuntimeOperator : IFunctionalityMarker
    {
#pragma warning disable IDE1006 // Naming Styles
        public Implementations.IRuntimeOperator _Implementations => Implementations.RuntimeOperator.Instance;
#pragma warning restore IDE1006 // Naming Styles


        /// <summary>
        /// Gets the path of the currently loaded system assembly.
        /// </summary>
        public string Get_SystemAssemblyFilePath()
        {
            var systemAssembly = Instances.AssemblyOperator.Get_SystemAssembly();

            var output = Instances.AssemblyOperator.Get_FilePath(systemAssembly);
            return output;
        }



        /// <summary>
        /// Gets the runtime directory path.
        /// </summary>
        /// <inheritdoc cref="Implementations.IRuntimeOperator.Get_RuntimeDirectoryPath_ViaRuntimeEnvironment" path="/remarks"/>
        public string Get_RuntimeDirectoryPath()
            => _Implementations.Get_RuntimeDirectoryPath_ViaRuntimeEnvironment();
    }
}
