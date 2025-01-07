using System;
using System.Collections.Generic;
using System.Linq;

using R5T.T0132;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface IArrayOperator : IFunctionalityMarker
    {
        public T[] Append<T>(
            T[] array,
            IEnumerable<T> appendix)
        {
            var output = array.AsEnumerable()
                .Append(appendix)
                .ToArray();

            return output;
        }

        public T[] Append<T>(
            T[] array,
            params T[] appendix)
            => this.Append(
                array,
                appendix.AsEnumerable());

        /// <summary>
        /// Tests if two arrays are equal handling checks for:
        /// <list type="bullet">
        /// <item>Does a simple null-check determine equality?</item>
        /// <item>Are the arrays equal in length?</item>
        /// <item>Are the elements of each array equal, given the input equality provider.</item>
        /// </list>
        /// </summary>
        public bool Are_Equal<T>(
            T[] a,
            T[] b,
            Func<T, T, bool> equalityProvider)
        {
            var output = Instances.NullOperator.NullCheckDeterminesEquality_Else(a, b,
                (a, b) =>
                {
                    var output = true;

                    output &= this.Are_Equal_ArrayLength(a, b);
                    output &= this.Are_Equal_ForeachElement(a, b, equalityProvider);

                    return output;
                });

            return output;
        }

        public bool Are_Equal_ArrayLength<T>(
            T[] a,
            T[] b)
        {
            var output = this.LengthsAreEqual(a, b);
            return output;
        }

        public bool Are_Equal_ForeachElement<T>(
            T[] a,
            T[] b,
            Func<T, T, bool> equality)
        {
            var output = Instances.NullOperator.NullCheckDeterminesEquality_Else(a, b,
                (a, b) =>
                {
                    var pairs = a.Zip(b);

                    foreach (var pair in pairs)
                    {
                        var isEqual = equality(pair.Item1, pair.Item2);
                        if (!isEqual)
                        {
                            return false;
                        }
                    }

                    return true;
                });

            return output;
        }

        public bool Are_Equal<T>(
            T[] a,
            T[] b,
            IEqualityComparer<T> equalityComparer)
            => this.Are_Equal(a, b,
                (x, y) => equalityComparer.Equals(x, y));

        public bool Are_Equal<T>(
            T[] a,
            T[] b)
            => this.Are_Equal(a, b,
                Instances.EqualityOperator.Get_EqualityComparer<T>());

        public T[] CastTo<T>(Array array)
            => (T[])array;

        public bool Contains<T>(
            T[] array,
            T item)
        {
            var output = Instances.EnumerableOperator.Contains(
                array,
                item);

            return output;
        }

        /// <summary>
        /// Produces an empty array of the specified type.
        /// </summary>
        public T[] Empty<T>()
        {
            return new T[0];
        }

        public T[] Empty_IfNull<T>(T[] array)
        {
            var isNull = Instances.NullOperator.Is_Null(array);

            var output = isNull
                ? this.Empty<T>()
                : array
                ;

            return output;
        }

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

        public T Get_First<T>(T[] array)
        {
            var output = array[0];
            return output;
        }

        public int Get_IndexOfLast(Array array)
        {
            var output = array.Length - 1;
            return output;
        }

        public T Get_Last<T>(T[] arrary)
        {
            var output = arrary[^1];
            return output;
        }

        public int Get_Count<T>(T[] array)
            => array.Length;

        public int Get_Length<T>(T[] array)
            => array.Length;

        public int[] Get_Range_Inclusive(int start, int end, int increment)
            => Instances.EnumerableOperator.Enumerate_Range_Inclusive(start, end, increment)
            .Now();

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

        public bool Is_Empty(Array array)
        {
            var output = array.Length == 0;
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

        public bool Is_NullOrEmpty(Array array)
        {
            var isNull = Instances.NullOperator.Is_Null(array);
            if (isNull)
            {
                return true;
            }

            var isEmpty = this.Is_Empty(array);
            if (isEmpty)
            {
                return true;
            }

            return false;
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

        public T[] Null_IfEmpty<T>(T[] array)
        {
            var isEmpty = this.Is_Empty(array);

            var output = isEmpty
                ? null
                : array
                ;

            return output;
        }
    }
}
