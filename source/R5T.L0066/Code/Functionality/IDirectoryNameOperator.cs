using System;

using R5T.T0132;
using R5T.T0143;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface IDirectoryNameOperator : IFunctionalityMarker,
        F10Y.L0000.IDirectoryNameOperator
    {
#pragma warning disable IDE1006 // Naming Styles

        [Ignore]
        F10Y.L0000.IDirectoryNameOperator _F10Y_L0000 => F10Y.L0000.DirectoryNameOperator.Instance;

#pragma warning restore IDE1006 // Naming Styles


        /// <summary>
        /// Quality-of-life overload for <see cref="F10Y.L0000.IDirectoryNameOperator.Ensure_IsValidDirectoryName(string)"/>
        /// </summary>
        public string Convert_ToDirectoryName(string name)
        {
            var output = this.Ensure_IsValidDirectoryName(name);
            return output;
        }

        public string Get_DatedDirectoryName(DateTime date)
        {
            var yyyymmdd = Instances.DateOperator.ToString_YYYYMMDD(date);

            // Any YYYYMMDD is already a valid directory name.
            return yyyymmdd;
        }

        public string Get_DateTimedDirectoryName(DateTime dateTime)
        {
            var yyyymmdd_hhmmss = Instances.DateTimeOperator.ToString_YYYYMMDD_HHMMSS(dateTime);

            // Any yyyymmdd_hhmmss is already a valid directory name.
            return yyyymmdd_hhmmss;
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

        /// <summary>
        /// Chooses <see cref="Is_ValidWindowsDirectoryName(string)"/> as the default.
        /// </summary>
        public bool Is_ValidDirectoryName(string directoryName)
            => this.Is_ValidWindowsDirectoryName(directoryName);

        public bool Is_ValidWindowsDirectoryName(string directoryName)
        {
            var invalidCharacters = Instances.PathOperator.Get_InvalidFileNameCharacters();

            var hasInvalidCharacter = Instances.StringOperator.ContainsAny(
                directoryName,
                invalidCharacters);

            if (hasInvalidCharacter)
            {
                return false;
            }

            var trimmedDirectoryName = Instances.StringOperator.Trim_End(
                directoryName,
                Instances.Characters.Space,
                Instances.Characters.Period);

            var endsWithInvalidCharacters = trimmedDirectoryName != directoryName;
            if (endsWithInvalidCharacters)
            {
                return false;
            }

            // Else
            return true;
        }

        /// <summary>
        /// Chooses <see cref="Verify_IsValidWindowsDirectoryName(string)"/> as the default.
        /// </summary>
        public void Verify_IsValidDirectoryName(string directoryName)
            => this.Verify_IsValidWindowsDirectoryName(directoryName);

        public void Verify_IsValidWindowsDirectoryName(string directoryName)
        {
            var isValid = this.Is_ValidWindowsDirectoryName(directoryName);
            if(!isValid)
            {
                throw new Exception($"\"{directoryName}\": Invalid Windows directory name");
            }
        }
    }
}
