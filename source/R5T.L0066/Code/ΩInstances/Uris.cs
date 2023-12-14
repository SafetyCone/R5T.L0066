using System;


namespace R5T.L0066
{
    public class Uris : IUris
    {
        #region Infrastructure

        public static IUris Instance { get; } = new Uris();


        private Uris()
        {
        }

        #endregion
    }
}
