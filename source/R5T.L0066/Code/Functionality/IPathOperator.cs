using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using R5T.T0132;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface IPathOperator : IFunctionalityMarker
    {
#pragma warning disable IDE1006 // Naming Styles
        public Checked.IPathOperator _Checked => Checked.PathOperator.Instance;
        public Implementations.IPathOperator _Implementations => Implementations.PathOperator.Instance;
        public Internal.IPathOperator _Internal => Internal.PathOperator.Instance;
#pragma warning restore IDE1006 // Naming Styles


        /// <summary>
		/// Finds the first directory separator in the path (or errors if none is found).
		/// </summary>
		/// <exception cref="InvalidOperationException">Thrown if no directory separator is found anywhere in the path.</exception>
		public char Detect_DirectorySeparator_OrException(string path)
        {
            var hasDirectorySeparator = this.Has_FirstDirectorySeparator(
                path,
                out var firstDirectorySeparator);

            if (!hasDirectorySeparator)
            {
                throw new InvalidOperationException($"No directory separator found in path:\n{path}");
            }

            return firstDirectorySeparator;
        }

        /// <summary>
        /// Returns the standard directory separator (<see cref="IDirectorySeparators.Standard"/>) if no directory separator is found.
        /// </summary>
        /// <if_no_directory_separator_found>
        /// If no directory separator is found, the standard directory separator (<see cref="IDirectorySeparators.Standard"/>) is used.
        /// </if_no_directory_separator_found>
        public char Detect_DirectorySeparator_OrStandard(
            string pathSegment)
        {
            return this.Detect_DirectorySeparator(
                pathSegment,
                Instances.DirectorySeparators.Standard);
        }

        /// <summary>
        /// Returns the environment-specifid directory separator (<see cref="IDirectorySeparators.Environment"/>) if no directory separator is found in the path.
        /// </summary>
        public char Detect_DirectorySeparator_OrEnvironment(
            string pathSegment)
        {
            return this.Detect_DirectorySeparator(
                pathSegment,
                Instances.DirectorySeparators.Environment);
        }

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

        public char Detect_DirectorySeparator(
            string prefixPath,
            string suffixPath)
        {
            var prefixHasDirectorySeparator = this.Has_FirstDirectorySeparator(
                prefixPath,
                out var prefixDirectorySeparator);

            if (prefixHasDirectorySeparator)
            {
                return prefixDirectorySeparator;
            }

            var suffixHasDirectorySeparator = this.Has_FirstDirectorySeparator(
                suffixPath,
                out var suffixDirectorySeparator);

            if (suffixHasDirectorySeparator)
            {
                return suffixDirectorySeparator;
            }

            // Else, use the current platform's directory separator.
            var output = Instances.DirectorySeparatorOperator.Get_CurrentPlatformDirectorySeparator();
            return output;
        }

        /// <summary>
        /// Chooses <see cref="Detect_DirectorySeparator_OrStandard(string)"/> as the default.
        /// </summary>
        /// <remarks>
        /// <inheritdoc cref="Detect_DirectorySeparator_OrStandard(string)" path="descendant::if_no_directory_separator_found"/>
        /// </remarks>
        public char Detect_DirectorySeparator(string path)
        {
            return this.Detect_DirectorySeparator_OrStandard(path);
        }

        public bool Is_DirectoryName_OfDirectoryPath(
            string directoryPath,
            string directoryName)
        {
            var directoryNameFound = this.Get_DirectoryName_OfDirectoryPath(directoryPath);

            var output = directoryName == directoryNameFound;
            return output;
        }

        /// <summary>
		/// Returns all path parts, even empty path parts.
		/// </summary>
		public string[] Get_PathParts_All(string path)
        {
            var directorySeparators = Instances.DirectorySeparators.Both;

            // Split path on directory separators, keeping empty entries, and not trimming any spaces.
            var pathParts = path.Split(directorySeparators, StringSplitOptions.None);
            return pathParts;
        }

        public string[] Get_PathParts_NonEmpty(string path)
        {
            var directorySeparators = Instances.DirectorySeparators.Both;

            // Split path on directory separators, removing empty entries.
            var pathParts = path.Split(directorySeparators, StringSplitOptions.RemoveEmptyEntries);
            return pathParts;
        }

        /// <summary>
        /// Chooses <see cref="Get_PathParts_NonEmpty(string)"/> as the default.
        /// </summary>
        public string[] Get_PathParts(string path)
        {
            var output = this.Get_PathParts_NonEmpty(path);
            return output;
        }

        public string Get_DirectoryPath(
            string baseDirectoryPath,
            string directoryName)
        {
            var directorySeparator = this.Detect_DirectorySeparator(baseDirectoryPath);

            var nonDirectoryIndicatedBaseDirectoryPath = this.Ensure_IsNotDirectoryIndicated(baseDirectoryPath);
            var directoryName_NotRootIndicated = this.Ensure_IsNotRootIndicated(directoryName);

            var combined = this.Combine_PathParts(
                nonDirectoryIndicatedBaseDirectoryPath,
                directoryName_NotRootIndicated,
                directorySeparator);

            var combined_UsingDirectorySeparator = this.Ensure_UsesDirectorySeparator(
                combined,
                directorySeparator);

            var output = this.Ensure_IsDirectoryIndicated_UsingSeparator(
                combined_UsingDirectorySeparator,
                directorySeparator);

            return output;
        }

        public string Get_DirectoryPath_Resolved(
            string baseDirectoryPath,
            string directoryName)
        {
            var directoryPath_PossiblyUnresolved = this.Get_DirectoryPath(
                baseDirectoryPath,
                directoryName);

            var directoryPath = this.Resolve_Path(directoryPath_PossiblyUnresolved);
            return directoryPath;
        }

        public string Get_DirectoryPath(
            string parentDirectoryPath,
            IEnumerable<string> directoryNames)
        {
            var directoryPath = parentDirectoryPath;

            foreach (var directoryName in directoryNames)
            {
                directoryPath = this.Get_DirectoryPath(directoryPath, directoryName);
            }

            var output = this.Ensure_IsDirectoryIndicated(directoryPath);
            return output;
        }

        public string Get_DirectoryPath(
            string parentDirectoryPath,
            params string[] directoryNames)
        {
            var output = this.Get_DirectoryPath(
                parentDirectoryPath,
                directoryNames.AsEnumerable());

            return output;
        }

        public string Get_FileNameStem(string filePath)
        {
            var fileName = this.Get_FileName(filePath);

            var output = Instances.FileNameOperator.Get_FileNameStem(fileName);
            return output;
        }

        public string Get_FilePath_ForFileName(
            string directoryPath,
            string fileName)
        {
            // Ensure.
            var ensuredDirectoryPath = this.Ensure_IsDirectoryIndicated(directoryPath);
            var ensuredFileName = Instances.FunctionOperator.Run_Modifiers(
                fileName,
                this.Ensure_IsNotRootIndicated,
                this.Ensure_IsNotDirectoryIndicated);

            var output = this.Combine(
                ensuredDirectoryPath,
                ensuredFileName);

            return output;
        }

        /// <summary>
        /// Gets the combined path of a file.
        /// </summary>
        /// <param name="directoryPathPart">No check is performed for directory-indicating terminating directory separator.</param>
        /// <param name="relativeFilePathPart">No check is performed for the root-indicating initial directory separator.</param>
        /// <returns>The combined file path.</returns>
        /// <remarks>
        /// Uses a simple string concatentation.
        /// </remarks>
        public string Get_FilePath_Simple(
            string directoryPathPart,
            string relativeFilePathPart)
        {
            var output = directoryPathPart + relativeFilePathPart;
            return output;
        }

        /// <summary>
        /// Quality-of-life overload for <see cref="IPathOperator.Combine(string, string)"/>.
        /// <para><inheritdoc cref="IPathOperator.Combine(string, string)" path="/summary"/></para>
        /// </summary>
        public string Get_FilePath(
            string directoryPath,
            string fileName)
        {
            var output = this.Combine(directoryPath, fileName);
            return output;
        }

        public string Get_FilePath(
            string parentDirectoryPath,
            IEnumerable<string> filePathParts)
        {
            var filePathPartsArray = filePathParts.ToArray();

            var filePath = this.Get_FilePath(
                parentDirectoryPath,
                filePathPartsArray);

            return filePath;
        }

        public string Get_FilePath(
            string parentDirectoryPath,
            params string[] filePathParts)
        {
            var directoryPathParts = Instances.ArrayOperator.Except_Last(filePathParts);

            var fileParentDirectoryPath = this.Get_DirectoryPath(
                parentDirectoryPath,
                directoryPathParts);

            var fileName = Instances.ArrayOperator.Get_Last(filePathParts);

            var filePath = this.Get_FilePath_InDirectory(
                fileParentDirectoryPath,
                fileName);

            return filePath;
        }

        public string Get_FilePath_InDirectory(
            string parentDirectoryPath,
            string fileName,
            char directorySeparator)
        {
            var ensuredParentDirectoryPath = this.Ensure_IsDirectoryIndicated_UsingSeparator(
                parentDirectoryPath,
                directorySeparator);

            var output = $"{ensuredParentDirectoryPath}{fileName}";
            return output;
        }

        public string Get_FilePath_InDirectory(
            string parentDirectoryPath,
            string fileName)
        {
            var directorySeparator = this.Detect_DirectorySeparator(parentDirectoryPath);

            var output = this.Get_FilePath_InDirectory(
                parentDirectoryPath,
                fileName,
                directorySeparator);

            return output;
        }

        /// <summary>
        /// Quality-of-life overload for <see cref="Get_DirectoryName(string)"/>.
        /// </summary>
        public string Get_DirectoryName_FromDirectoryPath(string directoryPath)
        {
            var output = this.Get_DirectoryName(directoryPath);
            return output;
        }

        /// <summary>
        /// Quality-of-life overload for <see cref="Get_DirectoryName(string)"/>.
        /// </summary>
        public string Get_DirectoryName_OfDirectoryPath(string directoryPath)
        {
            var output = this.Get_DirectoryName(directoryPath);
            return output;
        }

        /// <summary>
        /// Get the directory name of a directory path.
        /// </summary>
        /// <remarks>
        /// Chooses <see cref="Implementations.IPathOperator.Get_DirectoryName_ViaLastPathPart(string)"/> as the default implementation.
        /// </remarks>
        public string Get_DirectoryName(string directoryPath)
        {
            var output = _Implementations.Get_DirectoryName_ViaLastPathPart(directoryPath);
            return output;
        }

        public string[] Get_DirectoryPathParts(string directoryPath)
        {
            var directoryInfo = Instances.DirectoryInfoOperator.From(directoryPath);

            var output = Instances.DirectoryInfoOperator.Get_PathParts(directoryInfo);
            return output;
        }

        public string Get_DirectoryPath(IEnumerable<string> pathParts)
        {
            var combined = this.Combine(pathParts);

            var output = this.Ensure_IsDirectoryIndicated(combined);
            return output;
        }


        public string Get_DirectoryPath(params string[] pathParts)
        {
            return this.Get_DirectoryPath(pathParts.AsEnumerable());
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
        /// Gets the characters that cannot occur in file names on the system executing the function.
        /// </summary>
        /// <remarks>
        /// Returns the result of <see cref="Path.GetInvalidFileNameChars"/>.
        /// </remarks>
        public char[] Get_InvalidFileNameCharacters()
        {
            var output = Path.GetInvalidFileNameChars();
            return output;
        }

        /// <summary>
        /// Returns the result of <see cref="Path.GetInvalidPathChars"/>.
        /// </summary>
        public char[] Get_InvalidPathCharacters()
        {
            var output = Path.GetInvalidPathChars();
            return output;
        }

        /// <summary>
        /// Gets the directory path of the directory containing a specified directory.
        /// </summary>
        /// <returns>The non-directory indicated directory path of the file's parent directory.</returns>
        /// <remarks>
        /// Uses the <see cref="DirectoryInfo"/> class.
        /// </remarks>
        public string Get_ParentDirectoryPath_ForDirectory(string directoryPath)
        {
            var directoryInfo = new DirectoryInfo(directoryPath);

            var parentDirectoryPath = directoryInfo.Parent.FullName;
            return parentDirectoryPath;
        }

        /// <summary>
		/// Works for both directory and file paths.
		/// </summary>
		public string Get_ParentDirectoryPath(string path)
        {
            // Ensure the path is not directory indicated.
            var ensuredPath = this.Ensure_IsNotDirectoryIndicated(path);

            // Get the index of the last directory separator.
            var lastDirectorySeparatorIndex = this.Get_LastDirectorySeparatorIndex(ensuredPath);

            var anyDirectorySeparatorWasFound = Instances.StringOperator.Was_Found(lastDirectorySeparatorIndex);
            if (!anyDirectorySeparatorWasFound)
            {
                throw new InvalidOperationException($"Unable to get parent directory for file path:\n{ensuredPath}");
            }

            // Get the path up-to-and-including the last directory separator, since we want to output a directory-indicated path.
            var output = ensuredPath[0..(lastDirectorySeparatorIndex + 1)];
            return output;
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

        public string Get_Path(
            string basePath,
            string path_RelativeToBasePath)
        {
            var output = Path.Combine(
                basePath,
                path_RelativeToBasePath);

            return output;
        }

        /// <summary>
        /// Gets the file name of a file path.
        /// </summary>
        /// <remarks>
        /// Chooses <see cref="Implementations.IPathOperator.Get_FileName_ViaLastPathPart(string)"/> as the default implementation.
        /// </remarks>
        public string Get_FileName(string filePath)
        {
            var output = _Implementations.Get_FileName_ViaLastPathPart(filePath);
            return output;
        }

        public string Get_LastPathPart(string path)
        {
            var pathParts = this.Get_PathParts_NonEmpty(path);

            var fileName = Instances.ArrayOperator.Get_Last(pathParts);
            return fileName;
        }

        public int Get_LastDirectorySeparatorIndex(string path)
        {
            var output = path.LastIndexOfAny(
                Instances.DirectorySeparators.Both);

            return output;
        }

        public bool Has_AnyDirectorySeparators(string path)
        {
            var directorySeparators = Instances.DirectorySeparators.Both;

            var output = Instances.StringOperator.ContainsAny(
                path,
                directorySeparators);

            return output;
        }

        public bool Has_FileExtension(
            string filePath,
            string fileExtension)
        {
            var hasFileExtension = Instances.StringOperator.EndsWith(
                filePath,
                fileExtension);

            return hasFileExtension;
        }

        public bool Has_InvalidPathCharacters(string path)
        {
            var invalidCharacters = Instances.PathOperator.Get_InvalidPathCharacters();

            var containsInvalidCharacters = Instances.StringOperator.ContainsAny(
                path,
                invalidCharacters);

            return containsInvalidCharacters;
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

        /// <summary>
        /// Determines if the path is within the given directory.
        /// </summary>
        /// <remarks>
        /// The concept of "within" is to say that the directory would contain the path.
        /// </remarks>
        public bool Is_Within_Directory(
            string directoryPath,
            string path)
        {
            // For now, just use a simple string comparison. TODO - * Handle relative paths, * Test if this needs improvement.
            var output = Instances.StringOperator.Contains(
                path,
                directoryPath);

            return output;
        }

        /// <summary>
		/// Attempts to detect the directory separator (Windows or non-Windows) used within a path segment.
		/// Returns true if the a directory separator can be detected, and sets the output <paramref name="directorySeparator"/> to the detected value.
		/// Returns false if a directory separator cannot be detected, and sets the output <paramref name="directorySeparator"/> to the provided <paramref name="defaultDirectorySeparator"/> value.
		/// Returns true if both (mixed) directory separators are detected, and sets the sets the output <paramref name="directorySeparator"/> to the dominant value.
		/// A path segment might have both Windows and non-Windows directory separators. Whichever directory separator occurs first in the path segment (thus, closer to the root) is dominant, and is returned as the path segment's directory separator.
		/// </summary>
		public bool Try_DetectDirectorySeparator(
            string pathSegment, out char directorySeparator, char defaultDirectorySeparator)
        {
            var firstIndexOfDirectorySeparator = pathSegment.IndexOfAny(Instances.DirectorySeparators.Both);

            var exists = Instances.StringOperator.Is_Found(firstIndexOfDirectorySeparator);

            directorySeparator = exists
                ? pathSegment[firstIndexOfDirectorySeparator]
                : defaultDirectorySeparator
                ;

            return exists;
        }

        public void Validate(string path)
        {
            var isValid = this.Is_Valid(path);
            if (!isValid)
            {
                throw new Exception($"Invalid path: \"{path}\"");
            }
        }
    }
}
