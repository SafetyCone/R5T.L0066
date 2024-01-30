using System;
using System.IO;

using R5T.T0132;

using Glossary = R5T.Y0006.Glossary.ForPaths;


namespace R5T.L0066.Implementations
{
    [FunctionalityMarker]
    public partial interface IPathOperator : IFunctionalityMarker
    {
        public string Get_DirectoryName_ViaDirectoryInfo(string directoryPath)
        {
            var directoryInfo = new DirectoryInfo(directoryPath);
            
            var output = directoryInfo.Name;
            return output;
        }

        public string Get_DirectoryName_ViaLastPathPart(string directoryPath)
        {
            var output = Instances.PathOperator.Get_LastPathPart(directoryPath);
            return output;
        }

        public string Get_FileName_ViaFileInfo(string filePath)
        {
            var fileInfo = new FileInfo(filePath);
                
            var output = fileInfo.Name;
            return output;
        }

        public string Get_FileName_ViaLastPathPart(string filePath)
        {
            var output = Instances.PathOperator.Get_LastPathPart(filePath);
            return output;
        }

        /// <inheritdoc cref="L0066.IPathOperator.Get_ParentDirectoryPath_ForFile(string)" path="/summary"/>
        /// <inheritdoc cref="L0066.IPathOperator.Get_ParentDirectoryPath_ForFile(string)" path="/returns"/>
        /// <remarks>
        /// Uses the <see cref="FileInfo"/> class.
        /// </remarks>
        public string Get_ParentDirectoryPath_ForFile_UsingFileInfo(string filePath)
        {
            var fileInfo = new FileInfo(filePath);

            var parentDirectoryPath = fileInfo.Directory.FullName;

            // Unchecked, since we know the directory full name is *not* directory indicated.
            var output = Instances.PathOperator.Make_DirectoryIndicated(parentDirectoryPath);
            return output;
        }

        /// <inheritdoc cref="L0066.IPathOperator.Get_ParentDirectoryPath_ForFile(string)" path="/summary"/>
        /// <inheritdoc cref="L0066.IPathOperator.Get_ParentDirectoryPath_ForFile(string)" path="/returns"/>
        /// <remarks>
        /// Uses string parsing operations.
        /// </remarks>
        public string Get_ParentDirectoryPath_ForFile_UsingStringParsing(string filePath)
        {
            var lastIndexOfDirectorySeparator = Instances.StringOperator.Get_LastIndexOfAny(
                filePath,
                Instances.DirectorySeparators.Both);

            var output = Instances.StringOperator.Get_Substring_Upto_Inclusive(
                lastIndexOfDirectorySeparator,
                filePath);

            return output;
        }

        /// <summary>
        /// Is the path file indicated (does <em>not</em> end with one of the two directory separator characters).
        /// </summary>
        public bool Is_FileIndicated_ViaNotDirectoryIndicated(string pathPart)
        {
            // File-indicated is the opposite of directory indicated.
            var isDirectoryIndicated = Instances.PathOperator.Is_DirectoryIndicated(pathPart);

            var output = !isDirectoryIndicated;
            return output;
        }

        /// <summary>
        /// Determines whether the <paramref name="pathPart"/> is <inheritdoc cref="Glossary.FileIndicated" path="/name"/>.
        /// </summary>
        public bool Is_FileIndicated_ViaCheckLastCharacter(string pathPart)
        {
            // Test last character of path.
            var lastCharacter = Instances.StringOperator.Get_LastCharacter(pathPart);

            var isDirectorySeparator = Instances.DirectorySeparatorOperator.Is_DirectorySeparator(lastCharacter);

            // If the last character of the path is a directory separator, then the path is *not* file indicated (it is directory indicated).
            var output = !isDirectorySeparator;
            return output;
        }
    }
}
