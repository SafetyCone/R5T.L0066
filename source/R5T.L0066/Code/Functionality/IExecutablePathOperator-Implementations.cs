using System;
using System.Collections.Generic;
using System.Diagnostics;
using R5T.T0132;


namespace R5T.L0066.Implementations
{
    [FunctionalityMarker]
    public partial interface IExecutablePathOperator : IFunctionalityMarker
    {
        /// <summary>
		/// Get the current executable's path location from the first argument of the command-line incantation used to start the current process.
		/// </summary>
        public string Get_ExecutableFilePath_ViaCommandLineArgument()
        {
            var output = Instances.CommandLineArgumentsOperator.Get_ExecutableFilePath();
            return output;
        }

        /// <summary>
		/// Get the current executable's path location from the file path of the entry-point assembly for the current process.
		/// </summary>
        public string Get_ExecutableFilePath_ViaEntryAssemblyLocation()
        {
            var output = Instances.EnvironmentOperator.Get_EntryPointAssemblyFilePath();
            return output;
        }

        /// <summary>
        /// Enumerates all XML files in the directory containing the currently executing executable,
        /// and assumes those XML files are documentation files.
        /// (This might not be a good assumption.)
        /// </summary>
        public IEnumerable<string> Enumerate_AssemblyDocumentationFilePaths_AssumeAllXmls()
        {
            var executableDirectoryPath = Instances.ExecutablePathOperator.Get_ExecutableDirectoryPath();

            var output = Instances.FileSystemOperator.Enumerate_XmlFiles(executableDirectoryPath);
            return output;
        }

        /// <summary>
        /// Note! Do not use this method as the process operation is expensive (see <see href="https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/quality-rules/ca1839"/>).
        /// Use the newer (in .NET 6) System.Environment.ProcessPath instead.
		/// Get the current executable's path location as the path of the main-module (<see cref="Process.MainModule"/>) of the current process (<see cref="Process.GetCurrentProcess()"/>).
		/// </summary>
        [Obsolete("Use the newer (in .NET 6) System.Environment.ProcessPath since this operation is expensive.")]
        public string Get_ExecutableFilePath_ViaCurrentProcessMainModule()
        {
            // Need to dispose of the process!
            using var currentProcess = Process.GetCurrentProcess();

            var output = currentProcess.MainModule.FileName;
            return output;
        }
    }
}
