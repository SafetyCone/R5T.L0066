using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using R5T.T0132;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface IDirectoryInfoOperator : IFunctionalityMarker
    {
        public DirectoryInfo From(string directoryPath)
        {
            var output = new DirectoryInfo(directoryPath);
            return output;
        }

        public string[] Get_PathParts(DirectoryInfo directoryInfo)
        {
            // Returns directory path parts in reversed order.
            static IEnumerable<string> Internal_Reversed(DirectoryInfo directoryInfo)
            {
                while (directoryInfo != null)
                {
                    yield return directoryInfo.Name;

                    directoryInfo = directoryInfo.Parent;
                }
            }

            var output = Internal_Reversed(directoryInfo)
                .Reverse()
                .Now();

            return output;
        }

        public bool Has_Parent(DirectoryInfo directoryInfo)
        {
            var output = directoryInfo.Parent != null;
            return output;
        }
    }
}
