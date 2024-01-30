using System;
using System.Collections.Generic;
using System.Linq;

using R5T.T0132;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface IExecutablePathOperator : IFunctionalityMarker
    {
#pragma warning disable IDE1006 // Naming Styles
        private static Implementations.IExecutablePathOperator _Implementations => Implementations.ExecutablePathOperator.Instance;
#pragma warning restore IDE1006 // Naming Styles


        /// <summary>
        /// Gets the path location of the executable via the default method, <see cref="Implementations.IExecutablePathOperator.Get_ExecutableFilePath_ViaCommandLineArgument"/>.
        /// </summary>
        /// <remarks>
        /// There are multiple ways to get the location of the executable, and depending on context (unit test, debugging in Visual Studio, or production) different locations are returned.
        /// The command line argument is chosen as the default since this is the way the program is actually run by the operating system.
        /// </remarks>
        public string Get_ExecutableFilePath()
        {
            var output = _Implementations.Get_ExecutableFilePath_ViaCommandLineArgument();
            return output;
        }

        /// <summary>
		/// Gets the (directory-indicated) path of the directory containing the currently executing executable file.
		/// </summary>
		/// <returns>The directory-indicated directory path of the directory containing the executable file.</returns>
        public string Get_ExecutableDirectoryPath()
        {
            var executableFilePath = this.Get_ExecutableFilePath();

            var output = this.Get_ExecutableDirectoryPath(executableFilePath);
            return output;
        }

        /// <summary>
        /// Given the path of an executable file, get the (directory-indicated) path of the parent directory containing the executable file.
        /// </summary>
        public string Get_ExecutableDirectoryPath(string executableFilePath)
        {
            var executableDirectoryPath = Instances.PathOperator.Get_ParentDirectoryPath_ForFile(executableFilePath);
            return executableDirectoryPath;
        }

        /// <summary>
		/// Gets the path of a file given the executable directory-relative path of the file.
		/// </summary>
        public string Get_Path_ExecutableDirectoryRelative(string path_ExecutableDirectoryRelative)
        {
            var executableDirectoryPath = this.Get_ExecutableDirectoryPath();

            var output = Instances.PathOperator.Get_Path(
                executableDirectoryPath,
                path_ExecutableDirectoryRelative);

            return output;
        }

        /// <summary>
		/// Gets the file path for an assembly in the same directory as the current executable.
		/// </summary>
		public string Get_AssemblyFilePath(string assemblyName)
        {
            var assemblyFileName = Instances.AssemblyFileNameOperator.Get_AssemblyFileName(
                assemblyName);

            var assemblyFilePath = this.Get_Path_ExecutableDirectoryRelative(
                assemblyFileName);

            return assemblyFilePath;
        }

        /// <summary>
        /// Enumerates all assembly file paths in the directory containing the currently executing executable.
        /// </summary>
        public IEnumerable<string> Enumerate_AssemblyFilePaths()
        {
            var executableDirectoryPath = this.Get_ExecutableDirectoryPath();

            var output = Instances.FileSystemOperator.Enumerate_DllFiles(executableDirectoryPath);
            return output;
        }

        /// <summary>
        /// Gets all assembly file paths in the directory containing the currently executing executable.
        /// </summary>
        public string[] Get_AssemblyFilePaths()
        {
            var output = this.Enumerate_AssemblyFilePaths()
                .Now();

            return output;
        }

        public IEnumerable<string> Enumerate_AssemblyDocumentationFilePaths()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the file path for the XML documentation file of an assembly in the same directory as the current executable.
        /// </summary>
        public string Get_AssemblyDocumentationFilePath(string assemblyName)
        {
            var assemblyDocumentationFileName = Instances.DocumentationFileNameOperator.Get_AssemblyDocumentationFileName_FromAssemblyName(
                assemblyName);

            var assemblyDocumentationFilePath = this.Get_Path_ExecutableDirectoryRelative(
                assemblyDocumentationFileName);

            return assemblyDocumentationFilePath;
        }
    }
}
