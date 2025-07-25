using System;
using System.IO;

using R5T.T0132;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface IFileStreamOperator : IFunctionalityMarker
    {
        /// <summary>
        /// Eases construction of a new <see cref="FileStream"/> with a best-practice implementation of handling the overwrite parameter.
        /// </summary>
        public FileStream Open_Write(
            string filePath,
            bool overwrite = IValues.Overwrite_Default_Constant)
        {
            Instances.FileSystemOperator.Ensure_DirectoryExists_ForFilePath(filePath);

            var fileMode = Instances.FileModeOperator.Get_FileMode(overwrite);

            var fileStream = new FileStream(
                filePath,
                fileMode,
                FileAccess.Write,
                // Allow other processes to read the file.
                FileShare.Read);

            return fileStream;
        }

        public FileStream Open_Read(string filePath)
        {
            var fileStream = new FileStream(
                filePath,
                FileMode.Open,
                FileAccess.Read,
                // Allow other processes to read the file.
                FileShare.Read);

            return fileStream;
        }
    }
}
