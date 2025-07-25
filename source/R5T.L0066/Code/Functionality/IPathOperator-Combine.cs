using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using R5T.T0132;


namespace R5T.L0066
{
    public partial interface IPathOperator
    {
        public string Append_DirectoryRelativePath_ToDirectoryPath(
            string parentDirectoryPath,
            string childDirectoryRelativePath)
        {
            var directoryIndicatedDirectoryPath = this.Ensure_IsDirectoryIndicated(parentDirectoryPath);
            var notRootIndicatedChildDirectoryRelativePath = this.Ensure_IsNotRootIndicated(childDirectoryRelativePath);

            var possiblyMixedDirectorySeparatorDirectoryPath = this.Combine_WithoutModification(directoryIndicatedDirectoryPath, notRootIndicatedChildDirectoryRelativePath);

            var directorySeparator = this.Detect_DirectorySeparator_OrStandard(directoryIndicatedDirectoryPath);

            var output = this.Ensure_UsesDirectorySeparator(possiblyMixedDirectorySeparatorDirectoryPath, directorySeparator);
            return output;
        }

        public string Append_ToFileNameStem(
            string filePath,
            Func<string, string> fileNameModifier)
        {
            var directoryPath = Instances.PathOperator.Get_ParentDirectoryPath_ForFile(filePath);
            var fileName = Instances.PathOperator.Get_FileName(filePath);

            var newFileName = fileNameModifier(fileName);

            var newFilePath = Instances.PathOperator.Get_FilePath(
                directoryPath,
                newFileName);

            return newFilePath;
        }

        public string Append_ToFileNameStem(
            string filePath,
            string appendix)
        {
            var newFilePath = this.Append_ToFileNameStem(
                filePath,
                fileName => Instances.FileNameOperator.Append_ToFileNameStem(
                    fileName,
                    appendix));

            return newFilePath;
        }

        public string Combine_ToDirectoryPath(params string[] pathParts)
        {
            var output_Combined = this.Combine(pathParts);

            var output = this.Ensure_IsDirectoryIndicated(output_Combined);
            return output;
        }

        public string Combine_ToFilePath(params string[] pathParts)
        {
            var output_Combined = this.Combine(pathParts);

            var output = this.Ensure_IsNotDirectoryIndicated(output_Combined);
            return output;
        }

        public new string Combine(params string[] pathParts)
        {
            var output = Path.Combine(pathParts);
            return output;
        }

        public string Combine(IEnumerable<string> pathParts)
        {
            var pathPartsArray = pathParts.ToArray();

            var output = this.Combine(pathPartsArray);
            return output;
        }

        /// <summary>
        /// Performs a simple string concatenation.
        /// </summary>
        public string Combine_PathParts(
            string pathPart1,
            string pathPart2)
        {
            var output = Instances.StringOperator.Concatenate(
                pathPart1,
                pathPart2);

            return output;
        }

        public string Combine_PathParts(
            string pathPart1,
            string pathPart2,
            string directorySeparator)
        {
            var output = $"{pathPart1}{directorySeparator}{pathPart2}";
            return output;
        }

        public string Combine_PathParts(
            string pathPart1,
            string pathPart2,
            char directorySeparator)
        {
            var output = $"{pathPart1}{directorySeparator}{pathPart2}";
            return output;
        }

        public bool Contains_DirectorySeparator(
            string path,
            char directorySeparator)
        {
            var output = Instances.StringOperator.Contains(
                path,
                directorySeparator);

            return output;
        }

        /// <summary>
        /// Combines two paths, detecting the directory separator and ensuring the path is resolved.
        /// </summary>
        public string Combine(
            string prefixPath,
            string suffixPath)
        {
            var directorySeparator = this.Detect_DirectorySeparator(
                prefixPath,
                suffixPath);

            var output = this.Combine_EnsureResolved(
                prefixPath,
                suffixPath,
                directorySeparator);

            return output;
        }

        /// <summary>
        /// Combines the two paths, ensuring that only the specified directory separator is between the two paths.
        /// This is useful because paths might end with a directory separator or begin with a directory separator, and you don't want to have double directory separators.
        /// </summary>
        public string Combine_EnsureLinkingDirectorySeparator(
            string prefixPath,
            string suffixPath,
            char directorySeparator)
        {
            var ensuredPrefixPath = this.Ensure_IsNotDirectoryIndicated(prefixPath);
            var ensuredSuffixPath = this.Ensure_IsNotRootIndicated(suffixPath);

            var output = this.Combine_WithoutModification(
                ensuredPrefixPath,
                ensuredSuffixPath,
                directorySeparator);

            return output;
        }

        /// <summary>
        /// Combine the path segments, ensuring that the result is resolved.
        /// </summary>
        public string Combine_EnsureResolved(
            string prefixPath,
            string suffixPath,
            char directorySeparator)
        {
            var combinedDirectorySeparatorEnsuredPath = this.Combine_EnsureDirectorySeparator(
                prefixPath,
                suffixPath,
                directorySeparator);

            var output = this.Ensure_IsResolved(combinedDirectorySeparatorEnsuredPath);
            return output;
        }

        /// <summary>
        /// Combine the path segments, ensuring that the result is resolved.
        /// </summary>
        public string Combine_EnsureResolved(
            string prefixPath,
            string suffixPath)
        {
            var directorySeparator = this.Detect_DirectorySeparator_OrStandard(prefixPath);

            var output = this.Combine_EnsureResolved(
                prefixPath,
                suffixPath,
                directorySeparator);

            return output;
        }

        /// <summary>
        /// Combines the paths, ensuring that the path uses the specified directory separator.
        /// </summary>
        public string Combine_EnsureDirectorySeparator(
            string prefixPath,
            string suffixPath,
            char directorySeparator)
        {
            var possiblyMixedDirectorySeparatorsPath = this.Combine_EnsureLinkingDirectorySeparator(
                prefixPath,
                suffixPath,
                directorySeparator);

            var output = this.Ensure_UsesDirectorySeparator(
                possiblyMixedDirectorySeparatorsPath,
                directorySeparator);

            return output;
        }

        public string Combine_WithoutModification(
            string[] pathSegments,
            char directorySeparator)
        {
            var output = String.Join(directorySeparator, pathSegments);
            return output;
        }

        public string Combine_WithoutModification(
            string prefixPath,
            string suffixPath,
            char directorySeparator)
        {
            var output = $"{prefixPath}{directorySeparator}{suffixPath}";
            return output;
        }

        public string Combine_WithoutModification(
            string prefixPath,
            string suffixPath)
        {
            var output = $"{prefixPath}{suffixPath}";
            return output;
        }
    }
}
