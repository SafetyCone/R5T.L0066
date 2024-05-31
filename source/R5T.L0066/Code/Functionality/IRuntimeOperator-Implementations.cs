using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

using R5T.T0132;


namespace R5T.L0066.Implementations
{
    [FunctionalityMarker]
    public partial interface IRuntimeOperator : IFunctionalityMarker
    {
        /// <inheritdoc cref="L0066.IRuntimeOperator.Get_RuntimeDirectoryPath" path="/summary"/>
        /// <remarks>
        /// Returns the result of <see cref="RuntimeEnvironment.GetRuntimeDirectory"/>,
        /// and ensures the result is directory-indicated.
        /// </remarks>
        public string Get_RuntimeDirectoryPath_ViaRuntimeEnvironment()
        {
            var runtimeDirectoryPath = RuntimeEnvironment.GetRuntimeDirectory();

            var output = Instances.PathOperator.Ensure_IsDirectoryIndicated(runtimeDirectoryPath);
            return output;
        }

        /// <inheritdoc cref="L0066.IRuntimeOperator.Get_RuntimeDirectoryPath" path="/summary"/>
        /// <remarks>
        /// Returns the parent directory of <see cref="L0066.IRuntimeOperator.Get_SystemAssemblyFilePath"/>.
        /// </remarks>
        public string Get_RuntimeDirectoryPath_ViaSystemAssembly()
        {
            var systemAssemblyFilePath = Instances.RuntimeOperator.Get_SystemAssemblyFilePath();

            var output = Instances.PathOperator.Get_ParentDirectoryPath_ForFile(systemAssemblyFilePath);
            return output;
        }

        /// <inheritdoc cref="L0066.IRuntimeOperator.Get_RuntimeDirectoryPath" path="/summary"/>
        /// <remarks>
        /// Returns the parent directory of <see cref="AppContext.BaseDirectory"/>.
        /// </remarks>
        public string Get_RuntimeDirectoryPath_ViaAppContextBaseDirectory()
        {
            var output = AppContext.BaseDirectory;
            return output;
        }

        /// <inheritdoc cref="L0066.IRuntimeOperator.Get_RuntimeDirectoryPath" path="/summary"/>
        /// <remarks>
        /// Returns the parent directory of the first command line argument (which is the executable file path).
        /// </remarks>
        public string Get_RuntimeDirectoryPath_ViaFirstCommandLineArgument()
        {
            var firstCommandLineArgument = Instances.CommandLineArgumentsOperator.Get_FirstCommandLineArgument();

            var output = Instances.PathOperator.Get_ParentDirectoryPath_ForFile(firstCommandLineArgument);
            return output;
        }

        /// <inheritdoc cref="L0066.IRuntimeOperator.Get_RuntimeDirectoryPath" path="/summary"/>
        /// <remarks>
        /// Returns the parent directory of the entry point assembly.
        /// </remarks>
        public string Get_RuntimeDirectoryPath_ViaEntryPointAssembly()
        {
            var entryPointAssemblyFilePath = Instances.EnvironmentOperator.Get_EntryPointAssemblyFilePath();

            var output = Instances.PathOperator.Get_ParentDirectoryPath_ForFile(entryPointAssemblyFilePath);
            return output;
        }

        /// <inheritdoc cref="L0066.IRuntimeOperator.Get_RuntimeDirectoryPath" path="/summary"/>
        /// <remarks>
        /// Returns the parent directory path of the file containing the main-module (<see cref="Process.MainModule"/>) of the current process (<see cref="Process.GetCurrentProcess()"/>).
        /// </remarks>
        public string Get_RuntimeDirectoryPath_ViaCurrentProcessMainModule()
        {
            // Need to dispose of the process!
            using var currentProcess = Process.GetCurrentProcess();

            var currentProcessMainModuleFilePath = currentProcess.MainModule.FileName;

            var output = Instances.PathOperator.Get_ParentDirectoryPath_ForFile(currentProcessMainModuleFilePath);
            return output;
        }
    }
}
