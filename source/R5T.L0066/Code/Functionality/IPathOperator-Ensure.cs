using System;


namespace R5T.L0066
{
    public partial interface IPathOperator
    {
        /// <summary>
        /// Make sure the path uses the given directory separator.
        /// </summary>
        /// <remarks>
        /// This is different from <see cref="Ensure_IsDirectoryIndicated_UsingDefaultSeparator(string, char)"/>, where only if a directory separator is not detected within the path is the provided directory separator used.
        /// </remarks>
        public string Ensure_IsDirectoryIndicated_UsingSeparator(
            string directoryPath,
            char directorySeparator)
        {
            var isDirectoryIndicated = this.Is_DirectoryIndicated(directoryPath);
            if (isDirectoryIndicated)
            {
                return directoryPath;
            }

            // Else.
            var output = this.Make_DirectoryIndicated(
                directoryPath,
                directorySeparator);

            return output;
        }

        public string Ensure_IsDirectoryIndicated_UsingStandardSeparator(string directoryPath)
        {
            return this.Ensure_IsDirectoryIndicated_UsingSeparator(
                directoryPath,
                Instances.DirectorySeparators.Standard);
        }

        /// <summary>
		/// Ensures the path ends with a directory separator.
		/// The directory separator is detected within the path.
		/// </summary>
		public string Ensure_IsDirectoryIndicated(string pathPart)
        {
            var isDirectoryIndicated = this.Is_DirectoryIndicated(pathPart);

            var output = isDirectoryIndicated
                ? pathPart
                : this.Make_DirectoryIndicated(pathPart)
                ;

            return output;
        }

        /// <summary>
        /// If a directory separator cannot be detected in the input directory path, use the provided directory separator.
        /// </summary>
        /// <remarks>
        /// This is different from <see cref="Ensure_IsDirectoryIndicated_UsingSeparator(string, char)"/>, where even if a directory separator can be detected in the path, the path is made to use the provided directory separator.
        /// </remarks>
        public string Ensure_IsDirectoryIndicated_UsingDefaultSeparator(
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

            var output = this.Make_DirectoryIndicated(
                directoryPath,
                directorySeparator);

            return output;
        }

        /// <summary>
        /// Ensures that the path uses only the specified <paramref name="directorySeparator"/>.
        /// </summary>
        public string Ensure_UsesDirectorySeparator(
            string path,
            char directorySeparator)
        {
            var alternateDirectorySeparator = Instances.DirectorySeparatorOperator.Get_AlternateDirectorySeparator(directorySeparator);

            var containsAlternateDirectorySeparator = this.Contains_DirectorySeparator(
                path,
                alternateDirectorySeparator);

            var output = containsAlternateDirectorySeparator
                ? path.Replace(alternateDirectorySeparator, directorySeparator)
                : path
                ;

            return output;
        }

        public string Ensure_UsesDirectorySeparator_Standard(string path)
        {
            var output = this.Ensure_UsesDirectorySeparator(
                path,
                Instances.DirectorySeparators.Standard);

            return output;
        }

        /// <summary>
		/// Ensures the path does not end with a directory separator.
		/// </summary>
		public string Ensure_IsFileIndicated(string path)
        {
            var output = this.Ensure_IsNotDirectoryIndicated(path);
            return output;
        }

        public string Ensure_IsNotDirectoryIndicated(string path)
        {
            var isDirectoryIndicated = this.Is_DirectoryIndicated(path);

            var output = isDirectoryIndicated
                ? this.Make_NotDirectoryIndicated(path)
                : path
                ;

            return output;
        }

        public string Ensure_IsNotRootIndicated(string path)
        {
            var isRootIndicated = this.Is_RootIndicated(path);

            var output = isRootIndicated
                ? this.Make_NotRootIndicated(path)
                : path
                ;

            return output;
        }

        public string Ensure_UsesNonWindowsDirectorySeparator(string pathPart)
        {
            var output = this.Make_NonWindowsDirectorySeparated(pathPart);
            return output;
        }

        public string Ensure_IsRelative(string pathPart)
        {
            var isRelative = this.Is_Relative(pathPart);
            if(!isRelative)
            {
                var indexOfFirstDirectorySeparator = this.Get_IndexOfFirstDirectorySeparator(pathPart);

                var substring = Instances.StringOperator.Get_Substring_From_Exclusive(
                    indexOfFirstDirectorySeparator,
                    pathPart);

                var output = Instances.StringOperator.Trim_Start(
                    substring,
                    Instances.DirectorySeparators.Both);

                return output;
            }

            // Else.
            return pathPart;
        }

        public string Ensure_IsResolved(string pathPart)
        {
            var isResolved = this.Is_Resolved(pathPart);
            if (isResolved)
            {
                return pathPart;
            }
            else
            {
                var output = this.Resolve_Path(pathPart);
                return output;
            }
        }

        public string Ensure_UsesWindowsDirectorySeparator(string path)
        {
            var output = this.Make_WindowsDirectorySeparated(path);
            return output;
        }

        /// <summary>
		/// Makes a path directory indicated.
		/// </summary>
		public string Make_DirectoryIndicated(string path)
        {
            var output = this.Make_DirectoryIndicated(path, true);
            return output;
        }

        /// <summary>
        /// Detects the directory separator within the path (or errors if a directory separator cannot be detected),
        /// then adds or removes the directory separator to the end of the path if the path is not directory indicated.
        /// </summary>
        public string Make_DirectoryIndicated(
            string path,
            bool directoryIndicated)
        {
            var directorySeparator = Instances.PathOperator.Detect_DirectorySeparator(path);

            var output = this.Make_DirectoryIndicated(
                path,
                directorySeparator,
                directoryIndicated);

            return output;
        }

        /// <summary>
        /// Given a path and a directory separator, makes the path either directory indicated or not, given the directory separator.
        /// </summary>
        public string Make_DirectoryIndicated(
            string path,
            char directorySeparator,
            bool directoryIndicated)
        {
            var output = directoryIndicated
                ? this.Make_DirectoryIndicated(path, directorySeparator)
                : Instances.PathOperator.Make_NotDirectoryIndicated(path)
                ;

            return output;
        }

        /// <summary>
        /// Makes a directory path directory-indicated by appending the provided directory separator.
        /// Unchecked in the sense that no check is done on whether the directory path is already directory indicated (see <see cref="IPathOperator.Ensure_IsDirectoryIndicated(string)"/>)
        /// or whether the directory separator is actually one of the valid directory separators (see <see cref="IDirectorySeparators.Both"/>).
        /// </summary>
        public string Make_DirectoryIndicated(
            string path,
            char directorySeparator)
        {
            var output = Instances.StringOperator.Append(
                path,
                directorySeparator);

            return output;
        }

        public string Make_NonWindowsDirectorySeparated(string path)
        {
            var output = path.Replace(
                Instances.DirectorySeparators.Windows,
                Instances.DirectorySeparators.NonWindows);

            return output;
        }

        public string Make_WindowsDirectorySeparated(string path)
        {
            var output = path.Replace(
                Instances.DirectorySeparators.NonWindows,
                Instances.DirectorySeparators.Windows);

            return output;
        }

        public string Make_NotDirectoryIndicated(string path)
        {
            var output = path.TrimEnd(Instances.DirectorySeparators.Both);
            return output;
        }

        public string Make_NotRootIndicated(string path)
        {
            var output = path.TrimStart(Instances.DirectorySeparators.Both);
            return output;
        }

        public string Make_RootIndicated(
            string path,
            char directorySeparator)
        {
            var output = directorySeparator + path;
            return output;
        }

        public string Make_RootIndicated(
            string path,
            bool rootIndicated)
        {
            var directorySeparator = this.Detect_DirectorySeparator(path);

            var output = this.Make_RootIndicated(
                path,
                directorySeparator,
                rootIndicated);

            return output;
        }

        public string Make_RootIndicated(
           string path,
           char directorySeparator,
           bool rootIndicated)
        {
            var output = rootIndicated
                ? this.Make_RootIndicated(path, directorySeparator)
                : this.Make_NotRootIndicated(path)
                ;

            return output;
        }

        public string Match_DirectoryIndication(
            string path,
            string referencePath)
        {
            var directoryIndicated = this.Is_DirectoryIndicated(referencePath);

            var output = this.Make_DirectoryIndicated(path,
                directoryIndicated);

            return output;
        }

        public string Match_RootIndication(
            string path,
            string referencePath)
        {
            var rootIndicated = this.Is_RootIndicated(referencePath);

            var output = this.Make_RootIndicated(
                path,
                rootIndicated);

            return output;
        }

        /// <summary>
		/// Ensures that both the beginning and end of a path match a reference path in terms of root-indication and directory-indication.
		/// This is useful after modifying a path when you want to retain information about whether the initial path was root- or directory-indicated.
		/// </summary>
		public string Match_Terminals(
            string path,
            string referencePath)
        {
            var output = path;

            output = this.Match_RootIndication(output, referencePath);
            output = this.Match_DirectoryIndication(output, referencePath);

            return output;
        }
    }
}
