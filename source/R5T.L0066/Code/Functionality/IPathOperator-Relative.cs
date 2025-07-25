using System;
using System.Collections.Generic;
using System.Linq;


namespace R5T.L0066
{
    public partial interface IPathOperator
    {
        public string Get_DestinationDirectoryPath(
            string directoryPath,
            string destinationDirectoryPath)
        {
            var directoryName = this.Get_DirectoryName(directoryPath);

            var output = this.Get_DirectoryPath(
                destinationDirectoryPath,
                directoryName);

            return output;
        }

        public IEnumerable<string> Get_DestinationFilePaths(
            IEnumerable<string> sourceFilePaths,
            string destinationDirectoryPath)
        {
            var destinationFilePaths = sourceFilePaths
                .Select(sourceFilePath => this.Get_DestinationFilePath(
                    sourceFilePath,
                    destinationDirectoryPath))
                ;

            return destinationFilePaths;
        }

        public string Get_DestinationFilePath(
            string filePath,
            string destinationDirectoryPath)
        {
            var fileName = this.Get_FileName(filePath);

            var destinationFilePath = this.Get_FilePath(
                destinationDirectoryPath,
                fileName);

            return destinationFilePath;
        }

        public Dictionary<string, string> Get_RelativePaths(
            string sourcePath,
            IEnumerable<string> destinationPaths)
        {
            var directorySeparator = this.Detect_DirectorySeparator(sourcePath);

            var relativePathsByDestinationPath = destinationPaths
                .Distinct()
                .Select(destinationPath =>
                {
                    var relativePath = this.Get_RelativePath(
                        sourcePath,
                        destinationPath,
                        directorySeparator);

                    return (destinationPath, relativePath);
                })
                .ToDictionary(
                    x => x.destinationPath,
                    x => x.relativePath);

            return relativePathsByDestinationPath;
        }

        public new string Get_RelativePath(
            string sourcePath,
            string destinationPath)
        {
            var directorySeparator = this.Detect_DirectorySeparator(sourcePath);

            var output = this.Get_RelativePath(
                sourcePath,
                destinationPath,
                directorySeparator);

            return output;
        }

        public string Get_RelativePath(
            string sourcePath,
            string destinationPath,
            char outputDirectorySeparator)
        {
            var sourcePathUri = Instances.UriOperator.From_Path(sourcePath);
            var destinationPathUri = Instances.UriOperator.From_Path(destinationPath);

            var relativeUri = Instances.UriOperator.Make_RelativeUri(
                sourcePathUri,
                destinationPathUri);

            var escapedRelativePath = Instances.UriOperator.To_String(relativeUri);

            var relativePath = Instances.UriOperator.UnescapeDataString(escapedRelativePath);

            // Ensure we are using the desired directory separator for the output.
            var output = this.Ensure_UsesDirectorySeparator(
                relativePath,
                outputDirectorySeparator);

            return output;
        }
    }
}
