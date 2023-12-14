using System;


namespace R5T.L0066
{
    public class Versions : IVersions
    {
        #region Infrastructure

        public static IVersions Instance { get; } = new Versions();


        private Versions()
        {
        }

        #endregion
    }
}


namespace R5T.L0066.Raw
{
    public class Versions : IVersions
    {
        #region Infrastructure

        public static IVersions Instance { get; } = new Versions();


        private Versions()
        {
        }

        #endregion
    }
}
