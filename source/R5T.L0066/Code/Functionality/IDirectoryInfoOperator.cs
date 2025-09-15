using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using R5T.T0132;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface IDirectoryInfoOperator : IFunctionalityMarker,
        F10Y.L0000.IDirectoryInfoOperator
    {
        public DateTime Get_LastModifiedTime_ForFiles_UTC(
            DirectoryInfo directoryInfo,
            Func<DirectoryInfo, bool> descendantDirectoryRecursionPredicate)
            => this.Get_LastModifiedFile(
                directoryInfo,
                descendantDirectoryRecursionPredicate)
                // Return the UTC time.
                .LastWriteTimeUtc;

        /// <summary>
        /// Chooses <see cref="Get_LastModifiedTime_ForFilesInDirectory_Local(DirectoryInfo)"/> as the default.
        /// </summary>
        public DateTime Get_LastModifiedTime_ForFilesInDirectory(DirectoryInfo directoryInfo)
            => this.Get_LastModifiedTime_ForFilesInDirectory_Local(directoryInfo);

        public DateTime Get_LastModifiedTime_ForFilesInDirectory_Local(DirectoryInfo directoryInfo)
            => this.Get_LastModifiedTime_ForFiles_Local(
                directoryInfo,
                Instances.FunctionOperator.Return_True);

        public DateTime Get_LastModifiedTime_ForFilesInDirectory_UTC(DirectoryInfo directoryInfo)
            => this.Get_LastModifiedTime_ForFiles_UTC(
                directoryInfo,
                Instances.FunctionOperator.Return_True);

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
