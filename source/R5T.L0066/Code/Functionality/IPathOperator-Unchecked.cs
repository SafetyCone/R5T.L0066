using System;
using System.IO;

using R5T.T0132;


namespace R5T.L0066.Unchecked
{
    [FunctionalityMarker]
    public partial interface IPathOperator : IFunctionalityMarker
    {
        /// <summary>
        /// Makes a directory path directory-indicated by appending the provided directory separator.
        /// Unchecked in the sense that no check is done on whether the directory path is already directory indicated (see <see cref="L0066.IPathOperator.Ensure_DirectoryIndicated(string)"/>)
        /// or whether the directory separator is actually one of the valid directory separators (see <see cref="IDirectorySeparators.Both"/>).
        /// </summary>
        public string Make_DirectoryIndicated_Unchecked(
            string directoryPath,
            char directorySeparator)
        {
            var output = Instances.StringOperator.Append(
                directoryPath,
                directorySeparator);

            return output;
        }

        /// <summary>
        /// Makes a directory path directory-indicated by appending the provided directory separator.
        /// Unchecked in the sense that no check is done on whether the directory path is already directory indicated (see <see cref="L0066.IPathOperator.Ensure_DirectoryIndicated(string)"/>).
        /// </summary>
        public string Make_DirectoryIndicated_Unchecked(string directoryPath)
        {
            var directorySeparator = Instances.PathOperator.Detect_DirectorySeparator(directoryPath);

            var output = this.Make_DirectoryIndicated_Unchecked(
                directoryPath,
                directorySeparator);

            return output;
        }
    }
}
