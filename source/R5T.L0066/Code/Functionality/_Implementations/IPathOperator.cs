using System;
using System.IO;

using F10Y.T0011;
using R5T.T0132;

using Glossary = R5T.Y0006.Glossary.For_Paths;


namespace R5T.L0066.Implementations
{
    [FunctionalityMarker]
    public partial interface IPathOperator : IFunctionalityMarker,
        F10Y.L0000.Implementations.IPathOperator
    {
#pragma warning disable IDE1006 // Naming Styles

        [Ignore]
        public F10Y.L0000.Implementations.IPathOperator _F10Y_L0000 => F10Y.L0000.Implementations.PathOperator.Instance;

#pragma warning restore IDE1006 // Naming Styles


        public string Get_FileNameStem(string filePath)
        {
            var fileName = Instances.PathOperator.Get_FileName(filePath);

            var output = Instances.FileNameOperator.Get_FileNameStem(fileName);
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
