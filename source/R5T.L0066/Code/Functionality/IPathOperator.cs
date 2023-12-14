using System;
using System.Linq;

using R5T.T0132;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface IPathOperator : IFunctionalityMarker
    {
#pragma warning disable IDE1006 // Naming Styles
        public Implementations.IPathOperator _Implementations => Implementations.PathOperator.Instance;
        public Unchecked.IPathOperator _Unchecked => Unchecked.PathOperator.Instance;
#pragma warning restore IDE1006 // Naming Styles


        public char Detect_DirectorySeparator(
            string path,
            char defaultDirectorySeparator)
        {
            var directorySeparators = Instances.DirectorySeparators.Both;

            var indexOfFirstDirectorySeparatorOrNotFound = Instances.StringOperator.Get_IndexOfAny_OrNotFound(
                path,
                directorySeparators);

            var directorySeparatorFound = Instances.StringOperator.Is_Found(indexOfFirstDirectorySeparatorOrNotFound);

            var output = directorySeparatorFound
                ? Instances.StringOperator.Get_Character(
                    path,
                    indexOfFirstDirectorySeparatorOrNotFound)
                : defaultDirectorySeparator
                ;

            return output;
        }

        public char Detect_DirectorySeparator(string path)
        {
            return this.Detect_DirectorySeparator(
                path,
                Instances.DirectorySeparators.Standard);
        }

        public string Ensure_DirectoryIndicated(
            string directoryPath,
            char defaultDirectorySeparator)
        {
            var isDirectoryIndicated = this.Is_DirectoryIndicated(directoryPath);
            if (isDirectoryIndicated)
            {
                return directoryPath;
            }

            // Else.
            var directorySeparator = this.Detect_DirectorySeparator(
                directoryPath,
                defaultDirectorySeparator);

            var output = _Unchecked.Make_DirectoryIndicated_Unchecked(
                directoryPath,
                directorySeparator);

            return output;
        }

        public string Ensure_DirectoryIndicated(string directoryPath)
        {
            return this.Ensure_DirectoryIndicated(
                directoryPath,
                Instances.DirectorySeparators.Standard);
        }

        /// <summary>
        /// Gets both directory separators.
        /// (<see cref="IDirectorySeparators.Both"/>)
        /// </summary>
        public char[] Get_DirectorySeparators()
        {
            return Instances.DirectorySeparators.Both;
        }

        /// <summary>
        /// Gets the (directory-indicated) path of the directory containing a specified file.
        /// </summary>
        /// <returns>The directory-indicated directory path of the file's parent directory.</returns>
        /// <remarks>
        /// Chooses the <see cref="Implementations.IPathOperator.Get_ParentDirectoryPath_ForFile_UsingFileInfo(string)"/> as the default implementation.
        /// </remarks>
        public string Get_ParentDirectoryPath_ForFile(string filePath)
        {
            var output = _Implementations.Get_ParentDirectoryPath_ForFile_UsingFileInfo(filePath);
            return output;
        }

        public string Get_RelativePath(
            string sourcePath,
            string destinationPath)
        {
            var sourcePathUri = Instances.UriOperator.From_Path(sourcePath);
            var destinationPathUri = Instances.UriOperator.From_Path(destinationPath);

            var relativeUri = Instances.UriOperator.Make_RelativeUri(
                sourcePathUri,
                destinationPathUri);

            var escapedRelativePath = Instances.UriOperator.To_String(relativeUri);

            var relativePath = Instances.UriOperator.UnescapeDataString(escapedRelativePath);
            return relativePath;
        }

        /// <summary>
        /// Is the path directory indicated (ends with one of the two directory separator characters).
        /// </summary>
        public bool Is_DirectoryIndicated(string directoryPath)
        {
            var lastCharacter = Instances.StringOperator.Get_LastCharacter(directoryPath);

            // Is directory separator.
            var output = this.Is_DirectorySeparator(lastCharacter);
            return output;
        }

        /// <summary>
        /// Is the character one of the two directory separators?
        /// (<see cref="IDirectorySeparators.Both"/>)
        /// </summary>
        public bool Is_DirectorySeparator(char character)
        {
            var directorySeparators = this.Get_DirectorySeparators();

            var output = directorySeparators.Contains(character);
            return output;
        }
    }
}
