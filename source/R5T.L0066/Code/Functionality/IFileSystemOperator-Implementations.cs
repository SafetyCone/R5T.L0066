using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using R5T.T0132;


namespace R5T.L0066.Implementations
{
    [FunctionalityMarker]
    public partial interface IFileSystemOperator : IFunctionalityMarker
    {
        /// <summary>
        /// Moves a directory from one location to another.
        /// </summary>
        /// <remarks>
        /// Uses the <see cref="Directory.Move(string, string)"/> command,
        /// which <strong>cannot</strong> handle moving a directory to a location within the old directory.
        /// </remarks>
        public void Move_Directory_ViaSystemCommand(
             string sourceDirectoryPath,
             string destinationDirectoryPath)
        {
            Directory.Move(
                sourceDirectoryPath,
                destinationDirectoryPath);
        }
    }
}
