using System;
using System.Collections.Generic;
using System.Linq;


namespace R5T.L0066
{
    public partial interface IPathOperator
    {
        public string Resolve_Path(string pathSegment)
        {
            // Do not check whether path is resolved. Do the resolution operations just the same, and give callers the responsibility to first check whether a path is already resolved (perhaps via an EnsurePathIsResolved() extension).

            // Get path parts.
            var pathParts = this.Get_PathParts(pathSegment);

            // Now choose path parts, taking into account current directory and parent directory names.
            var pathPartsStack = new Stack<string>();

            foreach (var pathPart in pathParts)
            {
                if (Instances.DirectoryNameOperator.Is_CurrentDirectoryName(pathPart))
                {
                    // Do nothing.
                    continue;
                }

                if (Instances.DirectoryNameOperator.Is_ParentDirectoryName(pathPart))
                {
                    // Throw away the top path part.
                    pathPartsStack.Pop_OkIfEmpty(
                        out _);

                    continue;
                }

                // Else, add the path part.
                pathPartsStack.Push(pathPart);
            }

            // Recombine chosen path parts, using the directory separator of the input path.
            // Element order must be reversed since stack gives out elements in popped (LIFO) order.
            var chosenPathPartsInOrder = pathPartsStack.Reverse().ToArray();

            // Get the directory separator.
            var directorySeparator = this.Detect_DirectorySeparator(pathSegment);

            var combinedPath = this.Combine_WithoutModification(chosenPathPartsInOrder, directorySeparator);

            var output = this.Match_Terminals(
                combinedPath,
                pathSegment);

            return output;
        }
    }
}
