using System;
using System.Collections.Generic;
using System.Linq;

using F10Y.T0011;
using R5T.T0132;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface IArrayOperator : IFunctionalityMarker,
        F10Y.L0000.IArrayOperator
    {
#pragma warning disable IDE1006 // Naming Styles

        [Ignore]
        public F10Y.L0000.IArrayOperator _F10Y_L0000 => F10Y.L0000.ArrayOperator.Instance;

#pragma warning restore IDE1006 // Naming Styles


        public T[] Append<T>(
            T[] array,
            IEnumerable<T> appendix)
        {
            var output = array.AsEnumerable()
                .Append_Many(appendix)
                .ToArray();

            return output;
        }

        public T[] Append<T>(
            T[] array,
            params T[] appendix)
            => this.Append(
                array,
                appendix.AsEnumerable());

        public bool Are_Equal_ArrayLength<T>(
            T[] a,
            T[] b)
        {
            var output = this.LengthsAreEqual(a, b);
            return output;
        }

        public T[] CastTo<T>(Array array)
            => (T[])array;

        public T[] Except_Last<T>(T[] array)
        {
            //if(array.Length < 2)
            //{
            //    return this.Empty<T>();
            //}

            var output = array[0..^1];
            return output;
        }

        public T[] From<T>(T value)
        {
            var output = new[]
            {
                value,
            };

            return output;
        }

        public int[] Get_Range_Inclusive(int start, int end, int increment)
            => Instances.EnumerableOperator.Enumerate_Range_Inclusive(start, end, increment)
            .ToArray();

        public int[] Get_Range_Inclusive(int start, int end)
            => this.Get_Range_Inclusive(start, end, Instances.Integers.One);

        public T Get_SecondFromEnd<T>(T[] array)
        {
            var output = array[^2];
            return output;
        }

        public T Get_SecondToLast<T>(T[] array)
        {
            var output = array[^2];
            return output;
        }

        public bool Is_LengthOfOne(Array array)
        {
            var output = array.Length == 1;
            return output;
        }

        /// <summary>
        /// If the two arrays are different lengths, then they cannot be equal.
        /// In that case, testing the array lengths determines whether the arrays are equal (they are not).
        /// Otherwise, if the array lengths are the same, then the arrays might still be unequal, so the length check does not determine equality.
        /// </summary>
        public bool LengthCheckDeterminesEquality<T>(
            T[] a,
            T[] b,
            out bool lengthsAreEqual)
        {
            lengthsAreEqual = this.LengthsAreEqual(a, b);

            // If the lenghts
            var output = !lengthsAreEqual;
            return output;
        }

        /// <summary>
        /// Handles null check.
        /// </summary>
        public bool LengthsAreEqual(Array a, Array b)
        {
            var output = Instances.NullOperator.NullCheckDeterminesEquality_Else(a, b,
                (a, b) =>
                {
                    var lengthA = a.Length;
                    var lengthB = b.Length;

                    var output = lengthA == lengthB;
                    return output;
                });

            return output;
        }
    }
}
