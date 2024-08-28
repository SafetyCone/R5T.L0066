using System;

using R5T.T0132;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface IHashCodeOperator : IFunctionalityMarker
    {
        public int Combine<T1, T2>(
            T1 value1,
            T2 value2)
        {
            var output = HashCode.Combine(
                value1,
                value2);

            return output;
        }

        public int Combine<T1, T2, T3>(
            T1 value1,
            T2 value2,
            T3 value3)
        {
            var output = HashCode.Combine(
                value1,
                value2,
                value3);

            return output;
        }
    }
}
