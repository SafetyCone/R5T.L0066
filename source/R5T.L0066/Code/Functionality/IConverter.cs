using System;

using R5T.T0132;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface IConverter : IFunctionalityMarker
    {
        public Decimal To_Decimal(string decimalString)
            => Instances.DecimalOperator.Parse(decimalString);

        public double To_double(long value)
            => Convert.ToDouble(value);

        public double To_double(ulong value)
            => Convert.ToDouble(value);

        public ulong To_ulong(string ulongString)
            => Instances.UlongOperator.Parse(ulongString);

        public ulong To_ulong(object value)
            => Convert.ToUInt64(value);

        public ulong To_ulong(uint value)
            => Convert.ToUInt64(value);
    }
}
