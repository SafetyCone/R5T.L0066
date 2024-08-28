using System;
using System.Collections.Generic;
using System.Linq;

using R5T.T0132;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface IDocumentationFilePathOperator : IFunctionalityMarker
    {
        /// <summary>
        /// Get all XML documentation files in the executable directory assuming all XML files are documentation files.
        /// </summary>
        public IEnumerable<string> Enumerate_DocumentationFilePaths_AssumeAllXmls(
            string directoryPath)
        {
            return Instances.FileSystemOperator.Enumerate_XmlFiles(directoryPath);
        }

        /// <summary>
        /// Get all XML documentation files in the executable directory assuming all XML files are documentation files.
        /// </summary>
        public IEnumerable<string> Enumerate_DocumentationFilePaths_AssemblyPaired_ForDirectory(
            string directoryPath)
        {
            var assemblyFilePaths = Instances.AssemblyFilePathOperator.Enumerate_AssemblyFilePaths(directoryPath);

            var allXmlFilePaths = this.Enumerate_DocumentationFilePaths_AssumeAllXmls(directoryPath);

            // Now which of the XML file paths are paired with an assembly file path?
            var exepectedAssemblyDocumentationFilePaths = assemblyFilePaths
                .Select(assemblyFilePath => Instances.DocumentationFilePathOperator.Get_DocumentationFilePath_ForAssemblyFilePath(
                    assemblyFilePath))
                ;

            var pairedDocumentationFilePaths = allXmlFilePaths
                .Intersect(exepectedAssemblyDocumentationFilePaths)
                ;

            return pairedDocumentationFilePaths;
        }

        /// <summary>
        /// Get all XML documentation files in the executable directory assuming all XML files are documentation files.
        /// </summary>
        public IEnumerable<string> Enumerate_DocumentationFilePaths_AssemblyPaired(
            string assemblyFilePath)
        {
            var assemblyDirectoryPath = Instances.PathOperator.Get_ParentDirectoryPath_ForFile(assemblyFilePath);

            var output = this.Enumerate_DocumentationFilePaths_AssemblyPaired_ForDirectory(assemblyDirectoryPath);
            return output;
        }

        /// <inheritdoc cref="Enumerate_DocumentationFilePaths_AssemblyPaired(string)"/>
        public string[] Get_DocumentationFilePaths_AssemblyPaired(
            string directoryPath)
        {
            var output = this.Enumerate_DocumentationFilePaths_AssemblyPaired(directoryPath)
                .Now();

            return output;
        }

        /// <inheritdoc cref="Enumerate_DocumentationFilePaths_AssemblyPaired_ForDirectory(string)"/>
        public string[] Get_DocumentationFilePaths_AssemblyPaired_ForDirectory(
            string directoryPath)
        {
            var output = this.Enumerate_DocumentationFilePaths_AssemblyPaired_ForDirectory(directoryPath)
                .Now();

            return output;
        }

        public string Get_DocumentationFilePath_ForAssemblyFilePath(string assemblyFilePath)
        {
            var assemblyFileName = Instances.PathOperator.Get_FileName(assemblyFilePath);
            var assemblyDirectoryPath = Instances.PathOperator.Get_ParentDirectoryPath_ForFile(assemblyFilePath);

            var documentationFileName = Instances.DocumentationFileNameOperator.Get_AssemblyDocumentationFileName_FromAssemblyFileName(
                assemblyFileName);

            var documentationFilePath = Instances.PathOperator.Get_Path(
                assemblyDirectoryPath,
                documentationFileName);

            return documentationFilePath;
        }
    }
}
