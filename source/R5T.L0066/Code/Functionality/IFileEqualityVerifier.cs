using System;
using System.Threading.Tasks;

using R5T.T0132;


namespace R5T.L0066
{
    /// <summary>
    /// 
    /// </summary>
    [FunctionalityMarker]
    public partial interface IFileEqualityVerifier : IFunctionalityMarker
    {
        /// <summary>
        /// Byte-by-byte, verify that two files are the same.
        /// </summary>
        public async Task Verify_FileEquality_ByteLevel(
            string filePathA,
            string filePathB)
        {
            var gettingBytesA = Instances.FileOperator.Read_AllBytes(filePathA);
            var gettingBytesB = Instances.FileOperator.Read_AllBytes(filePathB);

            await Task.WhenAll(
                gettingBytesA,
                gettingBytesB);

            var bytesA = await gettingBytesA;
            var bytesB = await gettingBytesB;

            Instances.ByteEqualityVerifier.Verify_Equality(
                bytesA,
                bytesB);
        }

        /// <inheritdoc cref="Verify_FileEquality_ByteLevel(string, string)"/>
        public void Verify_FileEquality_ByteLevel_Synchonous(
            string filePathA,
            string filePathB)
        {
            var bytesA = Instances.FileOperator.Read_AllBytes_Synchronous(filePathA);
            var bytesB = Instances.FileOperator.Read_AllBytes_Synchronous(filePathB);

            Instances.ByteEqualityVerifier.Verify_Equality(
                bytesA,
                bytesB);
        }
    }
}
