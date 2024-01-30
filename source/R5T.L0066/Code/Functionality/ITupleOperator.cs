using System;

using R5T.T0132;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface ITupleOperator : IFunctionalityMarker
    {
        public (T, T1, T2, T3, T4) Combine<T, T1, T2, T3, T4>(
            T t1,
            (T1, T2, T3, T4) subset)
        {
            return (t1, subset.Item1, subset.Item2, subset.Item3, subset.Item4);
        }

        public (T, T1, T2, T3, T4, T5) Combine<T, T1, T2, T3, T4, T5>(
            T t1,
            (T1, T2, T3, T4, T5) subset)
        {
            return (t1, subset.Item1, subset.Item2, subset.Item3, subset.Item4, subset.Item5);
        }
    }
}
