using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using R5T.T0132;
using R5T.T0143;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface IDirectoryInfoOperator : IFunctionalityMarker,
        F10Y.L0001.L000.IDirectoryInfoOperator
    {
#pragma warning disable IDE1006 // Naming Styles

        [Ignore]
        F10Y.L0001.L000.IDirectoryInfoOperator _F10Y_L0001_L000 => F10Y.L0001.L000.DirectoryInfoOperator.Instance;

#pragma warning restore IDE1006 // Naming Styles


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
                .ToArray();

            return output;
        }

        public bool Has_Parent(DirectoryInfo directoryInfo)
        {
            var parent = this.Get_Parent(directoryInfo);

            var output = Instances.NullOperator.Is_NotNull(parent);
            return output;
        }

        public void Set_LastModifiedTime(
            DirectoryInfo directoryInfo,
            DateTime lastModifiedTime)
            => Instances.FileSystemInfoOperator.Set_LastModifiedTime(
                directoryInfo,
                lastModifiedTime);
    }
}
