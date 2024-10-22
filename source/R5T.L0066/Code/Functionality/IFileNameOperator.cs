using System;

using R5T.T0132;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface IFileNameOperator : IFunctionalityMarker
    {
        public string Append_ToFileNameStem(
            string fileName,
            string appendix)
        {
            var fileNameStem = Instances.FileNameOperator.Get_FileNameStem(fileName);
            var fileExtension = Instances.FileNameOperator.Get_FileExtension(fileName);

            var newFileNameStem = fileNameStem + appendix;

            var newFileName = Instances.FileNameOperator.Get_FileName(
                newFileNameStem,
                fileExtension);

            return newFileName;
        }

        /// <summary>
        /// Quality-of-life overload for <see cref="Get_FileName(string, string)"/>.
        /// </summary>
        public string Append_FileExtension(
            string fileNameStem,
            string fileExtension)
            => this.Get_FileName(
                fileNameStem,
                fileExtension);

        public string Get_FileExtension(string fileName)
        {
            var output = Instances.FileExtensionOperator.Get_FileExtension(fileName);
            return output;
        }

        /// <summary>
        /// Provided a file name stem and file extension, get the resulting file name.
        /// </summary>
        public string Get_FileName(
            string fileNameStem,
            string fileExtension)
        {
            var fileExtensionSeparator = Instances.FileExtensionOperator.Get_FileExtensionSeparator();

            var output = $"{fileNameStem}{fileExtensionSeparator}{fileExtension}";
            return output;
        }

        /// <summary>
        /// If the filename has no file extension separator, the whole file name is returned.
        /// </summary>
        public string Get_FileNameStem(string fileName)
        {
            var fileExtensionSeparator = Instances.FileExtensionOperator.Get_FileExtensionSeparator_Character();

            var indexOrNotFound = Instances.StringOperator.Get_LastIndexOf_OrNotFound(
                fileExtensionSeparator,
                fileName);

            var isFound = Instances.IndexOperator.Is_Found(indexOrNotFound);
            if (!isFound)
            {
                return fileName;
            }

            // Else.
            var output = Instances.StringOperator.Get_Substring_Upto_Exclusive(
                indexOrNotFound,
                fileName);

            return output;
        }
    }
}
