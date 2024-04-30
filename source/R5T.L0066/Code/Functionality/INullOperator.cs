using System;

using R5T.T0132;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface INullOperator : IFunctionalityMarker
    {
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

        /// <inheritdoc cref="NullCheckDeterminesEquality{T}(T, T, out bool)"/>
        public bool NullCheckDeterminesEquality_Else<T>(T a, T b,
            Func<T, T, bool> equality)
            where T : class
        {
            // Does a null check on the values determine equality?
            var nullCheckDeterminesEquality = this.NullCheckDeterminesEquality(a, b, out var areEqual);
            if (nullCheckDeterminesEquality)
            {
                return areEqual;
            }

            // Else, if a simple null check does not determine equality, run the equality function.
            var output = equality(a, b);
            return output;
        }

        /// <summary>
        /// Returns whether a null check can decide whether two instances are equal,
        /// and if so, what equality the null check provides.
        /// </summary>
        /// <remarks>
        /// <inheritdoc cref="Y0006.Documentation.NullCheckDeterminesEquality" path="/summary"/>
        /// </remarks>
        public bool NullCheckDeterminesEquality<T>(T a, T b, out bool areEqual)
            // Restrict to reference types so that we don't accidentally use this on value types (since the "is null" syntax works for value types, this operation is unneccesary).
            where T : class
        {
            if (a is null)
            {
                if (b is null)
                {
                    // If both are null, then a null check can determine equality, and both are equal.
                    areEqual = true;
                    return true;
                }
                else
                {
                    // If one is null, but the other is not, then a null check can determine equality, and both are equal.
                    areEqual = false;
                    return true;
                }
            }
            else
            {
                if (b is null)
                {
                    // If one is null, but the other is not, then a null check can determine equality, and both are equal.
                    areEqual = false;
                    return true;
                }
                else
                {
                    // If neither are null, then a null check *cannot* determine equality.
                    // Return a dummy value for whether or not they are equal.
                    areEqual = false;
                    return false;
                }
            }
        }

        public bool Is_NotNull<T>(T value)
            where T : class
        {
            // A great, quick null check.
            var output = value is object;
            return output;
        }

        public bool Is_Null<T>(T value)
            where T : class
        {
            var output = value is null;
            return output;
        }
    }
}
