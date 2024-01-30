using System;
using System.Collections.Generic;

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
		/// Get the current executable's path location from the first argument of the command-line incantation used to start the current process.
		/// </summary>
        public string Get_ExecutableFilePath_ViaEntryAssemblyLocation()
        {
            var output = Instances.CommandLineArgumentsOperator.Get_ExecutableFilePath();
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
    }
}
