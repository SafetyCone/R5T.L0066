using System;


namespace R5T.L0066
{
    public class PathSeparators : IPathSeparators
    {
        #region Infrastructure

        public static IPathSeparators Instance { get; } = new PathSeparators();


        private PathSeparators()
        {
        }

        #endregion
    }
}
