using System;


namespace R5T.L0066
{
    public class SpecialDirectoryNames : ISpecialDirectoryNames
    {
        #region Infrastructure

        public static ISpecialDirectoryNames Instance { get; } = new SpecialDirectoryNames();


        private SpecialDirectoryNames()
        {
        }

        #endregion
    }
}
