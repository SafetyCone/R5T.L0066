using System;

using R5T.T0132;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface IConverter : IFunctionalityMarker,
        F10Y.L0000.IConverter
    {
        double To_double(long value)
            => Convert.ToDouble(value);

        double To_double(ulong value)
            => Convert.ToDouble(value);

        ulong To_ulong(string ulongString)
            => Instances.UlongOperator.Parse(ulongString);

        ulong To_ulong(object value)
            => Convert.ToUInt64(value);

        ulong To_ulong(uint value)
            => Convert.ToUInt64(value);
    }
}
