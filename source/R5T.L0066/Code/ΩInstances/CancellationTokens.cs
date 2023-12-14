using System;


namespace R5T.L0066
{
    public class CancellationTokens : ICancellationTokens
    {
        #region Infrastructure

        public static ICancellationTokens Instance { get; } = new CancellationTokens();


        private CancellationTokens()
        {
        }

        #endregion
    }
}
