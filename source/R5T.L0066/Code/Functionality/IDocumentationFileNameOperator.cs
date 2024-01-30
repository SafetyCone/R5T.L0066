using System;

using R5T.T0132;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface IDocumentationFileNameOperator : IFunctionalityMarker
    {
        /// <summary>
        /// Returns the XML documentation file name given the assembly name.
        /// </summary>
        public string Get_AssemblyDocumentationFileName_FromAssemblyName(string assemblyName)
        {
            // Just append the "xml" file extension to the assembly name.
            var assemblyFileNameStem = Instances.AssemblyFileNameOperator.Get_AssemblyFileNameStem(assemblyName);

            var assemblyDocumentationFileName = Instances.FileNameOperator.Get_FileName(
                assemblyFileNameStem,
                Instances.FileExtensions.Xml);

            return assemblyDocumentationFileName;
        }

        public string Get_AssemblyDocumentationFileName_FromAssemblyFileName(string assemblyFileName)
        {
            var assemblyName = Instances.AssemblyFileNameOperator.Get_AssemblyName(assemblyFileName);

            var output = this.Get_AssemblyDocumentationFileName_FromAssemblyName(assemblyName);
            return output;
        }
    }
}
