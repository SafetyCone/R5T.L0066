using System;

using R5T.T0132;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface IAssemblyFileNameOperator : IFunctionalityMarker
    {
        public string Get_AssemblyFileName(string assemblyFileNameStem)
        {
            var output = Instances.FileNameOperator.Get_FileName(
                assemblyFileNameStem,
                Instances.FileExtensions.Dll);

            return output;
        }

        /// <summary>
        /// Get the assemby file name stem given an assembly name.
        /// </summary>
        public string Get_AssemblyFileNameStem(string assemblyName)
        {
            // The file name stem is just the assembly name.
            var assemblyFileNameStem = assemblyName;
            return assemblyFileNameStem;
        }

        public string Get_AssemblyName(string assemblyFileName)
        {
            return this.Get_AssemblyName_FromFileName(assemblyFileName);
        }

        public string Get_AssemblyName_FromFileNameStem(string assemblyFileNameStem)
        {
            // The assembly name is just the file name stem.
            var output = assemblyFileNameStem;
            return output;
        }

        public string Get_AssemblyName_FromFileName(string assemblyFileName)
        {
            var fileNameStem = Instances.FileNameOperator.Get_FileNameStem(assemblyFileName);

            var output = this.Get_AssemblyName_FromFileNameStem(fileNameStem);
            return output;
        }
    }
}
