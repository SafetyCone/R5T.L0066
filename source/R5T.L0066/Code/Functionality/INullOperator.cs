using System;

using R5T.T0132;
using R5T.T0143;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface INullOperator : IFunctionalityMarker,
        F10Y.L0000.INullOperator
    {
#pragma warning disable IDE1006 // Naming Styles

        [Ignore]
        public F10Y.L0000.INullOperator _F10Y_L0000 => F10Y.L0000.NullOperator.Instance;

#pragma warning restore IDE1006 // Naming Styles

        /// <summary>
        /// Returns true of neither inputs are null, false otherwise.
        /// Useful as the first line of a multi-line type instance equality method.
        /// </summary>
        public bool Are_BothNonNull<T>(T a, T b)
            where T : class
        {
            var output = true;

            output &= this.Is_NotNull(a);
            output &= this.Is_NotNull(b);

            return output;
        }

        /// <inheritdoc cref="Are_BothNonNull{T}(T, T)"/>
        public bool Is_NeitherNull<T>(T a, T b)
            where T : class
        {
            var output = this.Are_BothNonNull(a, b);
            return output;
        }

        public object Get_Null()
            => null;

        public T Get_Null<T>()
            where T: class
            => null;

        public void Set_Null<T>(ref T value)
            where T : class
        {
            value = null;
        }
    }
}
