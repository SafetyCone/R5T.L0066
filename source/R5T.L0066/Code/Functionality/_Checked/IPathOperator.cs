using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using R5T.T0132;


namespace R5T.L0066.Checked
{
    public partial interface IPathOperator
    {
#pragma warning disable IDE1006 // Naming Styles
        private L0066.IPathOperator _Root => L0066.PathOperator.Instance;
#pragma warning restore IDE1006 // Naming Styles


        /// <inheritdoc cref="L0066.IPathOperator.Ensure_IsDirectoryIndicated(string)" path="/summary"/>
        /// <remarks>
        /// Checks that the input is not null or empty, and if it is, just returns the input.
        /// </remarks>
        public string Ensure_IsDirectoryIndicated_CheckNotNullOrEmpty(string pathPart)
        {
            var isNullOrEmpty = _Root.Is_NullOrEmpty(pathPart);
            if(isNullOrEmpty)
            {
                return pathPart;
            }

            var output = _Root.Ensure_IsDirectoryIndicated(pathPart);
            return output;
        }

        public bool Is_DirectoryIndicated_CheckNullOrEmpty(string path)
        {
            var isNullOrEmpty = Instances.StringOperator.Is_NullOrEmpty(path);
            if (isNullOrEmpty)
            {
                return false;
            }

            var output = Instances.PathOperator.Is_DirectoryIndicated(path);
            return output;
        }

        public bool Is_RootIndicated_CheckNullOrEmpty(string path)
        {
            // Ensure that we have a first character.
            var isNullOrEmpty = Instances.StringOperator.Is_NullOrEmpty(path);
            if (isNullOrEmpty)
            {
                return false;
            }

            var output = Instances.PathOperator.Is_RootIndicated(path);
            return output;
        }
    }
}
