using System;

using R5T.T0132;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface IUlongOperator : IFunctionalityMarker
    {
        public ulong Parse(string ulongString)
            => Instances.UInt64Operator.Parse(ulongString);
    }
}
