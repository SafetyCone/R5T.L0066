using System;

using R5T.T0132;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface IUInt64Operator : IFunctionalityMarker
    {
        public UInt64 Parse(string uint64String)
        {
            var output = UInt64.Parse(uint64String);
            return output;
        }
    }
}
