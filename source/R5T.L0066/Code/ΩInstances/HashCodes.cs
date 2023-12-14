using System;


namespace R5T.L0066
{
    public class HashCodes : IHashCodes
    {
        #region Infrastructure

        public static IHashCodes Instance { get; } = new HashCodes();


        private HashCodes()
        {
        }

        #endregion
    }
}
