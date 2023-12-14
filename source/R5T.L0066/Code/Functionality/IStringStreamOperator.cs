using System;
using System.IO;
using System.Text;

using R5T.T0132;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface IStringStreamOperator : IFunctionalityMarker
    {
        public Stream From(string @string)
        {
            var bytes = Encoding.UTF8.GetBytes(@string);

            var memoryStream = new MemoryStream(bytes);
            return memoryStream;
        }
    }
}
