using System;
using System.IO;
using System.Threading.Tasks;

using R5T.T0132;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface IMemoryStreamOperator : IFunctionalityMarker
    {
        public MemoryStream FromBytes(byte[] bytes)
        {
            var memoryStream = new MemoryStream(bytes);
            return memoryStream;
        }

        public async Task<MemoryStream> FromFile(string filePath)
        {
            var fileBytes = await Instances.FileOperator.Read_Bytes(filePath);

            var memoryStream = this.FromBytes(fileBytes);
            return memoryStream;
        }

        public MemoryStream Get_New()
            => new MemoryStream();
    }
}
