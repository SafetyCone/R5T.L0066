using System;

using R5T.T0132;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface IDirectoryNameOperator : IFunctionalityMarker
    {
        /// <summary>
        /// Quality-of-life overload for <see cref="Ensure_IsValidDirectoryName(string)"/>
        /// </summary>
        public string Convert_ToDirectoryName(string name)
        {
            var output = this.Ensure_IsValidDirectoryName(name);
            return output;
        }

        /// <summary>
        /// Converts a possible directory name into a string capable of being a Windows directory name.
        /// </summary>
        /// <returns>
        /// Whether the name was changed, and the directory name as an out parameter.
        /// </returns>
        /// <remarks>
        /// See <see href="https://learn.microsoft.com/en-us/windows/win32/fileio/naming-a-file#naming-conventions"/>.
        /// </remarks>
        public bool Ensure_IsValidWindowsDirectoryName(
            string possibleDirectoryName,
            out string directoryName)
        {
            directoryName = possibleDirectoryName;

            // Replace all invalid characters with '_'.
            var invalidCharacters = Instances.PathOperator.Get_InvalidFileNameCharacters();

            directoryName = Instances.StringOperator.Replace(
                directoryName,
                Instances.Characters.Underscore,
                invalidCharacters);

            // Trim the ending of any spaces (' ') or periods ('.').
            directoryName = directoryName.TrimEnd(
                Instances.Characters.Space,
                Instances.Characters.Period);

            var isChanged = possibleDirectoryName != directoryName;
            
            return isChanged;
        }

        /// <summary>
        /// Chooses <see cref="Ensure_IsValidWindowsDirectoryName(string, out string)"/> as the default.
        /// </summary>
        public bool Ensure_IsValidDirectoryName(
            string possibleDirectoryName,
            out string directoryName)
        {
            return this.Ensure_IsValidWindowsDirectoryName(
                possibleDirectoryName,
                out directoryName);
        }

        public string Ensure_IsValidDirectoryName(string possibleDirectoryName)
        {
            // Ignore whether there was a change.
            this.Ensure_IsValidDirectoryName(
                possibleDirectoryName,
                out var output);

            return output;
        }

        /// <summary>
		/// <para>Returns true if the directory name is *not* the <see cref="IDirectoryNames.CurrentDirectory"/> or <see cref="IDirectoryNames.ParentDirectory"/> name.</para>
		/// <para><inheritdoc cref="Is_ActualDirectoryName(string)" path="/useful-when"/></para>
		/// </summary>
		/// <useful-when>This method is useful in the many situations where the <see cref="IDirectoryNames.CurrentDirectory"/> and <see cref="IDirectoryNames.ParentDirectory"/> names appear (such as low-level directory listings).</useful-when>
		public bool Is_ActualDirectoryName(string directoryName)
        {
            var output = true
                && directoryName != Instances.DirectoryNames.CurrentDirectory
                && directoryName != Instances.DirectoryNames.ParentDirectory
                ;

            return output;
        }

        public bool Is_CurrentDirectoryName(string directoryName)
        {
            var output = directoryName == Instances.DirectoryNames.CurrentDirectory;
            return output;
        }

        public bool Is_CurrentOrParentDirectoryName(string directoryName)
        {
            var output = false
                || this.Is_CurrentDirectoryName(directoryName)
                || this.Is_ParentDirectoryName(directoryName)
                ;

            return output;
        }

        public bool Is_ParentDirectoryName(string directoryName)
        {
            var output = directoryName == Instances.DirectoryNames.ParentDirectory;
            return output;
        }

        /// <summary>
        /// Quality-of-life overload of <see cref="Is_CurrentOrParentDirectoryName(string)"/>.
        /// </summary>
        public bool Is_RelativeDirectoryName(string directoryName)
        {
            var output = this.Is_CurrentOrParentDirectoryName(directoryName);
            return output;
        }
    }
}
