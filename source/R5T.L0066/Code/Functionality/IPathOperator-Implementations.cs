using System;
using System.IO;
using System.Linq;

using R5T.T0132;


namespace R5T.L0066.Implementations
{
    [FunctionalityMarker]
    public partial interface IPathOperator : IFunctionalityMarker
    {
#pragma warning disable IDE1006 // Naming Styles
        public Unchecked.IPathOperator _Unchecked => Unchecked.PathOperator.Instance;
#pragma warning restore IDE1006 // Naming Styles


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
            var output = _Unchecked.Make_DirectoryIndicated_Unchecked(parentDirectoryPath);
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
    }
}
