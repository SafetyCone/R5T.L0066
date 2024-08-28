using System;
using System.IO;

using R5T.T0132;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface IStreamOperator : IFunctionalityMarker
    {
        public void Seek_Beginnning(Stream stream)
        {
            stream.Seek(
                0,
                SeekOrigin.Begin);
        }
    }
}
