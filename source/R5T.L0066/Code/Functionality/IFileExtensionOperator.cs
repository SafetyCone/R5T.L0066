using System;

using R5T.T0132;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface IFileExtensionOperator : IFunctionalityMarker
    {
        /// <summary>
        /// Quality-of-life overload for <see cref="IFileNameOperator.Get_FileName(string, string)"/>.
        /// </summary>
        public string Add_FileExtension(string fileNameStem, string fileExtension)
        {
            var output = Instances.FileNameOperator.Get_FileName(fileNameStem, fileExtension);
            return output;
        }

        public string Get_FileExtension(string fileName)
        {
            var fileExtensionSeparator = Instances.FileExtensionOperator.Get_FileExtensionSeparator();

            var tokens = Instances.StringOperator.Split(
                fileExtensionSeparator,
                fileName,
                // Windows file names cannot end with a file extension separator (a period) or a space, but non-Windows file names can. In that case we want the empty or spaced file extension.
                // So keep empty file extensions, and do not trim file extensions.
                StringSplitOptions.None);

            // File extension is the last token.
            var fileExtension = Instances.ArrayOperator.Get_Last(tokens);
            return fileExtension;
        }

        /// <summary>
        /// <inheritdoc cref="Get_FileExtensionSeparator_Character"/>
        /// Chooses <see cref="Get_FileExtensionSeparator_Character"/> as the default.
        /// </summary>
        public char Get_FileExtensionSeparator()
        {
            var output = this.Get_FileExtensionSeparator_Character();
            return output;
        }

        /// <summary>
        /// Gets the file extension separator character.
        /// <para><inheritdoc cref="ICharacters.Period" path="descendant::name"/></para>
        /// </summary>
        public char Get_FileExtensionSeparator_Character()
        {
            var output = Instances.Characters.Period;
            return output;
        }

        /// <summary>
        /// Gets the file extension separator character.
        /// <para><inheritdoc cref="IStrings.Period" path="descendant::name"/></para>
        /// </summary>
        public char Get_FileExtensionSeparator_String()
        {
            var output = Instances.Characters.Period;
            return output;
        }

        public string Get_FileName(string fileNameStem, string fileExtension)
        {
            var output = Instances.FileNameOperator.Get_FileName(fileNameStem, fileExtension);
            return output;
        }

        public string Get_FileNameStem(string fileName)
        {
            var output = Instances.FileNameOperator.Get_FileNameStem(fileName);
            return output;
        }

        /// <summary>
		/// Quality-of-life alias for <see cref="IPathOperator.Has_FileExtension(string, string)"/>.
		/// </summary>
		public bool Has_FileExtension(
            string filePath,
            string fileExtension)
        {
            var output = Instances.PathOperator.Has_FileExtension(
                filePath,
                fileExtension);

            return output;
        }
    }
}
