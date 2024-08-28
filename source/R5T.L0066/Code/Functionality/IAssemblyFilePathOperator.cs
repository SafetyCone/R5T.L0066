using System;
using System.Collections.Generic;

using R5T.T0132;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface IAssemblyFilePathOperator : IFunctionalityMarker
    {
        /// <inheritdoc cref="Enumerate_AssemblyFilePaths_AssumeAllDlls(string)"/>
        public IEnumerable<string> Enumerate_AssemblyFilePaths(string directoryPath)
        {
            return this.Enumerate_AssemblyFilePaths_AssumeAllDlls(directoryPath);
        }

        /// <summary>
        /// Get all DLL assembly files in the directory assuming all DLL files are assembly files.
        /// </summary>
        public IEnumerable<string> Enumerate_AssemblyFilePaths_AssumeAllDlls(string directoryPath)
        {
            return Instances.FileSystemOperator.Enumerate_DllFiles(directoryPath);
        }

        /// <inheritdoc cref="IDocumentationFilePathOperator.Get_DocumentationFilePath_ForAssemblyFilePath(string)"/>
        public string Get_DocumentationFilePath_ForAssemblyFilePath(string assemblyFilePath)
            => Instances.DocumentationFilePathOperator.Get_DocumentationFilePath_ForAssemblyFilePath(assemblyFilePath);
    }
}
