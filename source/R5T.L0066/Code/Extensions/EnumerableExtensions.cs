using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        /// <inheritdoc cref="R5T.L0066.IEnumerableOperator.Except_First{T}(IEnumerable{T})"/>
        public static IEnumerable<T> Except_First<T>(this IEnumerable<T> enumerable)
        {
            var output = Instances.EnumerableOperator.Except_First(enumerable);
            return output;
        }

        /// <inheritdoc cref="R5T.L0066.IEnumerableOperator.Except_First{T}(IEnumerable{T}, int)"/>
        public static IEnumerable<T> Except_First<T>(this IEnumerable<T> enumerable, int numberOfElements)
        {
            var output = Instances.EnumerableOperator.Except_First(enumerable, numberOfElements);
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

        public static IEnumerable<T> OrderAlphabeticallyBy<T>(this IEnumerable<T> items,
            Func<T, string> keySelector)
        {
            var output = Instances.EnumerableOperator.OrderAlphabetically(items, keySelector);
            return output;
        }

        public static IEnumerable<T> OrderByNames<T>(this IEnumerable<T> items,
            Func<T, string> nameSelector,
            IEnumerable<string> orderedNames)
        {
            var output = Instances.OrderOperator.Order_ByNames(
                items,
                nameSelector,
                orderedNames);

            return output;
        }

        public static IEnumerable<T> OrderByNames<T>(this IEnumerable<T> items,
            Func<T, string> nameSelector,
            params string[] orderedNames)
        {
            return items.OrderByNames(
                nameSelector,
                orderedNames.AsEnumerable());
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


namespace R5T.L0066.Extensions
{
    public static class EnumerableExtensions
    {
        public static bool Any_Duplicates<T>(this IEnumerable<T> enumerable,
            IEqualityComparer<T> equalityComparer)
            => Instances.EnumerableOperator.Any_Duplicates(
                enumerable,
                equalityComparer);

        public static bool Any_Duplicates<T>(this IEnumerable<T> enumerable)
            => Instances.EnumerableOperator.Any_Duplicates(
                enumerable);

        public static IEnumerable<T> AppendRange<T>(this IEnumerable<T> enumerable, Func<IEnumerable<T>> appendix)
            => Instances.EnumerableOperator.AppendRange(enumerable, appendix);

        public static IEnumerable<T> Enumerate_Duplicates<T>(this IEnumerable<T> enumerable,
            IEqualityComparer<T> equalityComparer)
            => Instances.EnumerableOperator.Enumerate_Duplicates(
                enumerable,
                equalityComparer);

        public static IEnumerable<T> Enumerate_Duplicates<T>(this IEnumerable<T> enumerable)
            => Instances.EnumerableOperator.Enumerate_Duplicates(enumerable);

        public static void For_Each<T>(this IEnumerable<T> enumerable,
            Action<T> action)
            => Instances.EnumerableOperator.For_Each(enumerable, action);

        public static Task For_Each<T>(this IEnumerable<T> enumerable,
            Func<T, Task> action)
            => Instances.EnumerableOperator.For_Each(enumerable, action);

        public static T[] Get_Duplicates<T>(this IEnumerable<T> enumerable,
            IEqualityComparer<T> equalityComparer)
            => Instances.EnumerableOperator.Get_Duplicates(
                enumerable,
                equalityComparer);

        public static T[] Get_Duplicates<T>(this IEnumerable<T> enumerable)
            => Instances.EnumerableOperator.Get_Duplicates(enumerable);

        public static IEnumerable<T> OrderAlphabetically_By<T>(this IEnumerable<T> items,
            Func<T, string> keySelector)
        {
            var output = Instances.EnumerableOperator.OrderAlphabetically(items, keySelector);
            return output;
        }

        public static Dictionary<TKey, TValue> To_Dictionary<TKey, TValue>(this IEnumerable<KeyValuePair<TKey, TValue>> pairs)
            => EnumerableOperator.Instance.ToDictionary(pairs);
    }
}
