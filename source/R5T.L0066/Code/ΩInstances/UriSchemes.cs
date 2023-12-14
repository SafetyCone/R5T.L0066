using System;


namespace R5T.L0066
{
    public class UriSchemes : IUriSchemes
    {
        #region Infrastructure

        public static IUriSchemes Instance { get; } = new UriSchemes();


        private UriSchemes()
        {
        }

        #endregion
    }
}
