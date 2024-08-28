using System;

using R5T.T0132;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface IEqualityOperator : IFunctionalityMarker
    {
        /// <inheritdoc cref="INullOperator.NullCheckDeterminesEquality_Else{T}(T, T, Func{T, T, bool})"/>
        public bool NullCheckDeterminesEquality_Else<T>(T a, T b,
            Func<T, T, bool> equality)
            where T : class
            => Instances.NullOperator.NullCheckDeterminesEquality_Else(
                a,
                b,
                equality);
    }
}
