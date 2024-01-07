using System;

using R5T.T0132;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface IByteEqualityVerifier : IFunctionalityMarker
    {
        /// <summary>
        /// Byte-by-byte, verify that two byte arrays are equal.
        /// </summary>
        /// <remarks>
        /// This is useful in testing file byte-level equality.
        /// </remarks>
        public void Verify_Equality(
            byte[] bytesA,
            byte[] bytesB)
        {
            var byteCountA = bytesA.Length;
            var byteCountB = bytesB.Length;

            var sameByteCount = byteCountA == byteCountB;
            if (!sameByteCount)
            {
                throw new Exception($"Differing byte counts: A is {byteCountA}, and B is {byteCountB}.");
            }

            for (int iByte = 0; iByte < bytesA.Length; iByte++)
            {
                var byteIsEqual = bytesA[iByte] == bytesB[iByte];
                if (!byteIsEqual)
                {
                    throw new Exception($"Byte number {iByte} was unequal.");
                }
            }
        }
    }
}
