using System;
using System.Linq;

using Glossary = R5T.Y0006.Glossary.ForPaths;


namespace R5T.L0066
{
    public partial interface IPathOperator
    {
        public int Get_IndexOfFirstDirectorySeparator(string pathPart)
        {
            var hasIndexOfFirstDirectorySeparator = this.Has_IndexOfFirstDirectorySeparator(
                pathPart,
                out var indexOfFirstDirectorySeparator_OrNotFound);

            if(!hasIndexOfFirstDirectorySeparator)
            {
                throw new Exception($"Path part did not have a directory separator:\n\t{pathPart}");
            }

            return indexOfFirstDirectorySeparator_OrNotFound;
        }

        public bool Has_FirstDirectorySeparator(
            string pathPart,
            out char firstDirectorySeparator_OrDefault)
        {
            var hasIndexOfFirstDirectorySeparator = this.Has_IndexOfFirstDirectorySeparator(
                pathPart,
                out var indexOfFirstDirectorySeparator_OrNotFound);

            firstDirectorySeparator_OrDefault = hasIndexOfFirstDirectorySeparator
                ? pathPart[indexOfFirstDirectorySeparator_OrNotFound]
                : default
                ;

            return hasIndexOfFirstDirectorySeparator;
        }

        public bool Has_IndexOfFirstDirectorySeparator(
            string pathPart,
            out int indexOfFirstDirectorySeparator_OrNotFound)
        {
            var directorySeparators = Instances.DirectorySeparators.Both;

            indexOfFirstDirectorySeparator_OrNotFound = Instances.StringOperator.Get_IndexOfAny_OrNotFound(
                pathPart,
                directorySeparators);

            var wasFound = Instances.StringOperator.Was_Found(indexOfFirstDirectorySeparator_OrNotFound);
            return wasFound;
        }

        public bool Has_ParentDirectory(string path)
        {
            // If a path has any directory separators, then it has a parent directory.
            var output = this.Has_AnyDirectorySeparators(path);
            return output;
        }

        /// <summary>
        /// Determines whether the <paramref name="pathPart"/> is <inheritdoc cref="Glossary.DirectoryIndicated" path="/name"/>.
        /// </summary>
        /// <remarks>
        /// Works by testing if the last character of the path is one of the two directory separators.
        /// </remarks>
        public bool Is_DirectoryIndicated(string pathPart)
        {
            // Test last character of path.
            var lastCharacter = Instances.StringOperator.Get_LastCharacter(pathPart);

            // If the last character of the path is a directory separator, then the path is directory indicated.
            var output = Instances.DirectorySeparatorOperator.Is_DirectorySeparator(lastCharacter);
            return output;
        }

        /// <summary>
        /// Determines whether the <paramref name="pathPart"/> is <inheritdoc cref="Glossary.FileIndicated" path="/name"/>.
        /// </summary>
        public bool Is_FileIndicated(string pathPart)
        {
            var output = Instances.PathOperator._Implementations.Is_FileIndicated_ViaCheckLastCharacter(pathPart);
            return output;
        }

        /// <summary>
        /// Determines if the first directory separator in the path is the specified <paramref name="directorySeparator"/>.
        /// If no directory separator is found, then the specified <paramref name="assumption"/> is made.
        /// </summary>
        public bool Is_FirstDirectorySeparator(
            string pathPart,
            char directorySeparator,
            bool assumption = true)
        {
            // Get the first directory separator of either type.
            var hasFirstDirectorySeparator = this.Has_FirstDirectorySeparator(
                pathPart,
                out var firstDirectorySeparator);

            // If no directory separator is found in the string, make an assumption.
            if (!hasFirstDirectorySeparator)
            {
                return assumption;
            }

            // Else, see if the directory separator matches.
            var output = firstDirectorySeparator == directorySeparator;
            return output;
        }

        public bool Is_MixedPlatform(string path)
        {
            var bothDirectorySeparators = Instances.DirectorySeparators.Both;

            // If the path contains both directory separators, then it is mixed.
            var output = path.ContainsAll(bothDirectorySeparators);
            return output;
        }

        /// <summary>
		/// Chooses <see cref="Is_NonWindows_AssumeTrue(string)"/> as the default.
		/// </summary>
		public bool Is_NonWindows(string path)
        {
            var output = this.Is_NonWindows_AssumeTrue(path);
            return output;
        }

        /// <summary>
        /// Determines if a path is a non-Windows path, assuming it is if there are no directory separators present to allow an actual determination.
        /// </summary>
        public bool Is_NonWindows_AssumeTrue(string path)
        {
            var output = this.Is_FirstDirectorySeparator(
                path,
                Instances.DirectorySeparators.NonWindows,
                true);

            return output;
        }

        /// <summary>
        /// Determines if a path is a non-Windows path, making no assumption if there are no directory separators present to allow an actual determination.
        /// </summary>
        public bool Is_NonWindows_Strict(string path)
        {
            var output = this.Is_FirstDirectorySeparator(
                path,
                Instances.DirectorySeparators.NonWindows,
                false);

            return output;
        }

        public bool Is_NullOrEmpty(string path)
        {
            var output = Instances.StringOperator.Is_NullOrEmpty(path);
            return output;
        }

        public bool Is_Relative(string pathPart)
        {
            // If the path isn't rooted, it's relative.
            var isRooted = this.Is_Rooted(pathPart);

            var output = !isRooted;
            return output;
        }

        public bool Is_Resolved(string path)
        {
            var isUnresolved = this.Is_Unresolved(path);

            // Resolved and unresolved are opposites.
            var output = !isUnresolved;
            return output;
        }

        public bool Is_Rooted(string pathPart)
        {
            // If the path starts with one of the directory separators, then it is rooted.
            var firstCharacter = pathPart.First();

            var firstCharacterIsDirectorySeparator = Instances.DirectorySeparatorOperator.Is_DirectorySeparator(firstCharacter);
            if (firstCharacterIsDirectorySeparator)
            {
                return true;
            }

            // If the path has a volume separator, and it comes before the first directory separator, then the path is rooted.
            var hasIndexOfVolumeSeparator = Instances.StringOperator.Has_IndexOf(
                pathPart,
                Instances.PathSeparators.VolumeSeparator,
                out var indexOfVolumeSeparator_OrNotFound);

            var hasIndexOfFirstDirectorySeparator = this.Has_IndexOfFirstDirectorySeparator(
                pathPart,
                out var indexOfFirstDirectorySeparator_OrNotFound);

            if (hasIndexOfVolumeSeparator && hasIndexOfFirstDirectorySeparator && indexOfVolumeSeparator_OrNotFound < indexOfFirstDirectorySeparator_OrNotFound)
            {
                return true;
            }

            return false;
        }

        /// <summary>
		/// Determines whether the <paramref name="path"/> is <inheritdoc cref="Glossary.RootIndicated" path="/name"/>.
		/// </summary>
		public bool Is_RootIndicated(string path)
        {
            // Now get the first character.
            var firstCharacter = path.First();

            var directorySeparators = Instances.DirectorySeparators.Both;

            // If the first character is a directory separator, then the path is root-indicated.
            var output = directorySeparators.Contains(firstCharacter);
            return output;
        }

        public bool Is_UnknownPlatform(string path)
        {
            var bothDirectorySeparators = Instances.DirectorySeparators.Both;

            var containsEither = Instances.StringOperator.ContainsAny(
                path,
                bothDirectorySeparators);

            // If the path does not contain either directory separator, then it's platform is unknown.
            var output = !containsEither;
            return output;
        }

        public bool Is_Unresolved(string path)
        {
            // Is the path simply one of the relative directory names?
            // Files named "." or ".." are illegal, because there is already an entry in every directory named "." or "..".
            var isRelativeDirectoryName = Instances.DirectoryNameOperator.Is_RelativeDirectoryName(path);
            if (isRelativeDirectoryName)
            {
                return true;
            }

            // Since "." certainly, or ".." conceivably, might exist within the path ("." as the file extension separator and ".." perhaps accidentally in a file path), look for these directory names together with either of the directory separator.
            // Note that (at least) on Windows, the current or parent directory names cannot exist at the end of the directory or file name ("Directory.", "Directory..", "File." and "File.." are not allowed). Thus only before, instead of also after, a directory separator needs to be checked.
            // Directories and files cannot be named ".." or ".", since an entry with those names already exists in each directory.
            // The relative directory names will not appear alone since that would instead be interpretted as part of a file name or directory name.
            var searchStrings = new[]
            {
                $"{Instances.DirectoryNames.ParentDirectory}{Instances.DirectorySeparators.Windows}",
                $"{Instances.DirectoryNames.CurrentDirectory}{Instances.DirectorySeparators.Windows}",
                $"{Instances.DirectoryNames.ParentDirectory}{Instances.DirectorySeparators.NonWindows}",
                $"{Instances.DirectoryNames.CurrentDirectory}{Instances.DirectorySeparators.NonWindows}",
            };

            var output = Instances.StringOperator.ContainsAny(path,
                searchStrings);

            return output;
        }

        /// <summary>
        /// Determines whether a path is valid based on whether the path, taken as a path, contains any 
        /// </summary>
        public bool Is_Valid_NoInvalidPathCharacters(string path)
        {
            var hasInvalidPathCharacters = Instances.PathOperator.Has_InvalidPathCharacters(path);

            var output = !hasInvalidPathCharacters;
            return output;
        }

        /// <summary>
        /// Determines whether a path is valid based solely on whether it is not null and not empty.
        /// </summary>
        public bool Is_Valid_NotNullNotEmpty(string path)
        {
            var output = Instances.StringOperator.Is_NotNullOrEmpty(path);
            return output;
        }

        /// <summary>
        /// Breaks a path down into its path parts, then verifies there are no invalid file name characters in any of the path parts (except for a volume separator in the first path part).
        /// </summary>
        public bool Is_Valid_NoInvalidFileNameCharactersInPathParts(string path)
        {
            // Do a quick check to ensure we have at least one path part.
            var isValid_NonNullNotEmpty = this.Is_Valid_NotNullNotEmpty(path);
            if (!isValid_NonNullNotEmpty)
            {
                return false;
            }

            // Now we have at least the first path parts.
            var pathParts = Instances.PathOperator.Get_PathParts(path);

            var invalidFileNameCharacters = Instances.PathOperator.Get_InvalidFileNameCharacters();

            var invalidFileNameCharactersExceptVolumeSeparator = invalidFileNameCharacters.Except(Instances.PathSeparators.VolumeSeparator).Now();

            var firstPathPart = pathParts.First();

            var firstPathPartIsInvalid = Instances.StringOperator.ContainsAny(
                firstPathPart,
                invalidFileNameCharactersExceptVolumeSeparator);

            if (firstPathPartIsInvalid)
            {
                return false;
            }

            foreach (var pathPart in pathParts.Skip_First())
            {
                var pathPartIsInvalid = Instances.StringOperator.ContainsAny(
                    pathPart,
                    invalidFileNameCharacters);

                if (pathPartIsInvalid)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Directory names and files names cannot end with the current directory name ("."), or the parent directory name ("..").
        /// This validates that the path contains no current directory or parent directory names, unless the entire path part is the current or parent directory name.
        /// </summary>
        public bool Is_Valid_NoEndingWithSpecialDirectoryNames(string path)
        {
            var pathParts = Instances.PathOperator.Get_PathParts(path);

            foreach (var pathPart in pathParts)
            {
                // The path part is valid if it is the current directory or parent directory name.
                if (pathPart == Instances.DirectoryNames.CurrentDirectory || pathPart == Instances.DirectoryNames.ParentDirectory)
                {
                    continue;
                }

                var endsWithSpecialDirectoryName = pathPart.EndsWith(Instances.DirectoryNames.CurrentDirectory) || path.EndsWith(Instances.DirectoryNames.ParentDirectory);
                if (endsWithSpecialDirectoryName)
                {
                    return false;
                }
            }

            return true;
        }

        public bool Is_Valid(string path)
        {
            // A path is valid if it is:
            // 1. Not null or empty.
            // 2. Contains no invalid path characters (when considered as a path).
            // 3. All path parts contain no invalid file name characters.
            // 4. No path parts end with either "." or "..", unless the entire path part is either "." or ".." (the special current directory and parent directory names).
            // Note: there are differences between the allowed characters in a path, and the allowed characters in a file name (or directory name).
            // Note: there are no differences for directory names vs. file names.

            // Not null or empty.
            var isValid_NotNullNotEmpty = this.Is_Valid_NotNullNotEmpty(path);
            if (!isValid_NotNullNotEmpty)
            {
                return false;
            }

            // Contains invalid path characters.
            var isValid_NoInvalidPathCharacters = this.Is_Valid_NoInvalidPathCharacters(path);
            if (!isValid_NoInvalidPathCharacters)
            {
                return false;
            }

            //var isValid_NoInvalidFileNameCharactersInPathParts = this.Is_Valid_NoInvalidFileNameCharactersInPathParts(path);
            //if (!isValid_NoInvalidFileNameCharactersInPathParts)
            //{
            //	return false;
            //}

            var isValid_NoEndingWithSpecialDirectoryNames = this.Is_Valid_NoEndingWithSpecialDirectoryNames(path);
            if (!isValid_NoEndingWithSpecialDirectoryNames)
            {
                return false;
            }


            return true;
        }

        /// <summary>
		/// Chooses <see cref="Is_Windows_AssumeTrue(string)"/> as the default.
		/// </summary>
		public bool Is_Windows(string pathPart)
        {
            var output = this.Is_Windows_AssumeTrue(pathPart);
            return output;
        }

        public bool Is_Windows_AssumeTrue(string pathPart)
        {
            var output = this.Is_FirstDirectorySeparator(
                pathPart,
                Instances.DirectorySeparators.Windows,
                true);

            return output;
        }

        public bool Is_Windows_Strict(string pathPart)
        {
            var output = this.Is_FirstDirectorySeparator(
                pathPart,
                Instances.DirectorySeparators.Windows,
                false);

            return output;
        }
    }
}
