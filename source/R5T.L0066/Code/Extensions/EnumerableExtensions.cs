using System;
using System.Collections.Generic;

using Instances = R5T.L0066.Instances;


namespace System.Linq
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> Append<T>(this IEnumerable<T> enumerable,
            IEnumerable<T> appendix)
        {
            return Instances.EnumerableOperator.Append(enumerable, appendix);
        }

        public static IEnumerable<T> Append<T>(this IEnumerable<T> enumerable,
            params T[] appendix)
        {
            return Instances.EnumerableOperator.Append(enumerable, appendix);
        }

        public static IEnumerable<T> AppendRange<T>(this IEnumerable<T> enumerable,
            IEnumerable<T> appendix)
        {
            return Instances.EnumerableOperator.AppendRange(enumerable, appendix);
        }

        public static bool ContainsAll<T>(this IEnumerable<T> superset,
            IEnumerable<T> subset)
        {
            var output = Instances.EnumerableOperator.ContainsAll(superset, subset);
            return output;
        }

        /// <inheritdoc cref="R5T.L0066.IEnumerableOperator.Except_Last{T}(IEnumerable{T})"/>
        public static IEnumerable<T> Except_Last<T>(this IEnumerable<T> enumerable)
        {
            var output = Instances.EnumerableOperator.Except_Last(enumerable);
            return output;
        }

        /// <inheritdoc cref="R5T.L0066.IEnumerableOperator.Except_Last{T}(IEnumerable{T}, int)"/>
        public static IEnumerable<T> Except_Last<T>(this IEnumerable<T> enumerable, int numberOfElements)
        {
            var output = Instances.EnumerableOperator.Except_Last(enumerable, numberOfElements);
            return output;
        }

        public static IEnumerable<T> Except<T>(this IEnumerable<T> items, T item)
            where T : IEquatable<T>
        {
            var output = Instances.EnumerableOperator.Except(items, item);
            return output;
        }

        public static bool None<T>(this IEnumerable<T> items)
        {
            return Instances.EnumerableOperator.None(items);
        }

        public static T[] Now<T>(this IEnumerable<T> items)
        {
            var output = Instances.EnumerableOperator.Now(items);
            return output;
        }

        public static IEnumerable<T> Prepend<T>(this IEnumerable<T> items,
            IEnumerable<T> prependix)
        {
            return Instances.EnumerableOperator.Prepend(
                items,
                prependix);
        }

        public static IEnumerable<T> Prepend<T>(this IEnumerable<T> items,
            params T[] prependix)
        {
            return Instances.EnumerableOperator.Prepend(
                items,
                prependix);
        }

        public static T Second<T>(this IEnumerable<T> items)
        {
            var output = Instances.EnumerableOperator.Get_Second(items);
            return output;
        }

        public static IEnumerable<T> Skip_First<T>(this IEnumerable<T> enumerable)
        {
            var output = Instances.EnumerableOperator.Skip_First(enumerable);
            return output;
        }

        public static IEnumerable<(T, T)> Zip<T>(this IEnumerable<T> items,
            IEnumerable<T> b)
        {
            var output = Instances.EnumerableOperator.Zip(
                items,
                b);

            return output;
        }
    }
}
