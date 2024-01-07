using System;


namespace R5T.L0066
{
    public class ByteEqualityVerifier : IByteEqualityVerifier
    {
        #region Infrastructure

        public static IByteEqualityVerifier Instance { get; } = new ByteEqualityVerifier();


        private ByteEqualityVerifier()
        {
        }

        #endregion
    }
}
