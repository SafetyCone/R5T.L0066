using System;


namespace R5T.L0066
{
    public partial interface IPathOperator
    {
        public void Verify_NoInvalidPathCharacters(string path)
        {
            var hasInvalidPathCharacters = this.Has_InvalidPathCharacters(path);
            if (hasInvalidPathCharacters)
            {
                throw new Exception($"Path had invalid path characters. Path:\n{path}");
            }
        }

        public void Verify_IsDirectoryIndicated(string pathPart)
        {
            var isDirectoryIndicated = this.Is_DirectoryIndicated(pathPart);
            if (!isDirectoryIndicated)
            {
                throw new Exception($"Path part was not directory indcated:\n\t{pathPart}");
            }
        }

        public void Verify_NotDirectoryIndicated(string pathPart)
        {
            var isDirectoryIndicated = this.Is_DirectoryIndicated(pathPart);
            if (isDirectoryIndicated)
            {
                throw new Exception($"Path part was directory indcated:\n\t{pathPart}");
            }
        }

        public void Verify_IsFileIndicated(string pathPart)
        {
            var isFileIndicated = this.Is_FileIndicated(pathPart);
            if (!isFileIndicated)
            {
                throw new Exception($"Path part was not file indcated:\n\t{pathPart}");
            }
        }

        public void Verify_NotFileIndicated(string pathPart)
        {
            var isFileIndicated = this.Is_FileIndicated(pathPart);
            if (isFileIndicated)
            {
                throw new Exception($"Path part was file indcated:\n\t{pathPart}");
            }
        }
    }
}
