using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using R5T.T0132;
using R5T.T0143;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface IEnumerableOperator : IFunctionalityMarker,
        F10Y.L0001.L000.IEnumerableOperator
    {
#pragma warning disable IDE1006 // Naming Styles

        [Ignore]
        Implementations.IEnumerableOperator _Implementations => Implementations.EnumerableOperator.Instance;


        [Ignore]
        F10Y.L0001.L000.IEnumerableOperator _F10Y_L0001_L000 => F10Y.L0001.L000.EnumerableOperator.Instance;


#pragma warning restore IDE1006 // Naming Styles


        bool Any_Duplicates<T>(
            IEnumerable<T> enumerable,
            IEqualityComparer<T> equalityComparer)
        {
            var hashSet = new HashSet<T>(equalityComparer);

            foreach (var item in enumerable)
            {
                var alreadyExists = hashSet.Contains(item);

                if(alreadyExists)
                {
                    return true;
                }
            }

            // Else, all are unique.
            return false;
        }

        bool Any_Duplicates<T>(IEnumerable<T> enumerable)
            => this.Any_Duplicates(
                enumerable,
                EqualityComparer<T>.Default);

        IEnumerable<T> Append_If<T>(
            IEnumerable<T> enumerable,
            bool value,
            Func<IEnumerable<T>> appendix_Provider)
        {
            if (value)
            {
                var appendix = appendix_Provider();

                var output = this.Append(
                    enumerable,
                    appendix);

                return output;
            }

            // Else
            return enumerable;
        }

        IEnumerable<T> AppendRange<T>(
            IEnumerable<T> enumerable,
            IEnumerable<T> appendix)
        {
            return enumerable.Concat(appendix);
        }

        IEnumerable<T> AppendRange<T>(
            IEnumerable<T> enumerable,
            Func<IEnumerable<T>> appendixGenerator)
        {
            var appendix = appendixGenerator();

            var output = this.AppendRange(enumerable, appendix);
            return output;
        }

        IEnumerable<T> Concatenate<T>(IEnumerable<IEnumerable<T>> enumerables)
        {
            var output = enumerables
                .SelectMany(enumerable => enumerable)
                ;

            return output;
        }

        IEnumerable<T> Concatenate<T>(
            params IEnumerable<T>[] enumerables)
            => this.Concatenate(
                enumerables.AsEnumerable());

        bool ContainsAll<T>(
            IEnumerable<T> superset,
            IEnumerable<T> subset)
        {
            var output = subset.Except(superset).None();
            return output;
        }

        bool Contains<T>(
            IEnumerable<T> array,
            T item,
            IEqualityComparer<T> equalityComparer)
        {
            var output = array.Contains(
                item,
                equalityComparer);

            return output;
        }

        bool Contains<T>(
            IEnumerable<T> array,
            T item)
        {
            var output = array.Contains(item);
            return output;
        }

        IEnumerable<T> Enumerate_Duplicates<T>(
            IEnumerable<T> enumerable,
            IEqualityComparer<T> equalityComparer)
        {
            var output = enumerable
                .GroupBy(
                    x => x,
                    equalityComparer)
                .Where(group => group.Count() > 1)
                .Select(group => group.Key)
                ;

            return output;
        }

        IEnumerable<T> Enumerate_Duplicates<T>(IEnumerable<T> enumerable)
            => this.Enumerate_Duplicates(
                enumerable,
                EqualityComparer<T>.Default);

        IEnumerable<int> Enumerate_Range_Inclusive(
            int start,
            int end,
            int increment)
        {
            var end_Inclusive = end + increment;

            for (int i = start; i < end_Inclusive; i += increment)
            {
                yield return i;
            }
        }

        IEnumerable<int> Enumerate_Range_Inclusive(
            int start,
            int end)
            => this.Enumerate_Range_Inclusive(start, end, Instances.Integers.One);

        T[] Get_Duplicates<T>(
            IEnumerable<T> enumerable,
            IEqualityComparer<T> equalityComparer)
        {
            var output = this.Enumerate_Duplicates(
                enumerable,
                equalityComparer)
                .ToArray();

            return output;
        }

        T[] Get_Duplicates<T>(IEnumerable<T> enumerable)
            => this.Get_Duplicates(
                enumerable,
                EqualityComparer<T>.Default);

        IEnumerable<T> Get_Empty_IfDefault<T>(IEnumerable<T> values = default)
        {
            var isDefault = Instances.DefaultOperator.Is_Default(values);

            var output = isDefault
                ? this.Empty<T>()
                : values
                ;

            return output;
        }

        bool Equal_ElementSets<T>(
            IEnumerable<T> a,
            IEnumerable<T> b,
            IEqualityComparer<T> equalityComparer)
            => a.Except(b, equalityComparer)
            .None();

        bool Equal_ElementSets<T>(
            IEnumerable<T> a,
            IEnumerable<T> b)
            => this.Equal_ElementSets(a, b,
                Instances.EqualityOperator.Get_EqualityComparer<T>());

        void For_Each<T>(IEnumerable<T> enumerable, Action<T> action)
        {
            foreach (var item in enumerable)
            {
                action(item);
            }
        }

        async Task For_Each<T>(IEnumerable<T> enumerable, Func<T, Task> action)
        {
            foreach (var item in enumerable)
            {
                await action(item);
            }
        }

        IEnumerable<T> From<T>(T instance)
        {
            yield return instance;
        }

        IEnumerable<T[]> From_Array<T>(T[] instance)
        {
            yield return instance;
        }

        T Get_First<T>(IEnumerable<T> values)
        {
            var output = _Implementations.Get_First_UsingEnumerator(values);
            return output;
        }

        IEnumerable<T> OrderAlphabetically<T>(
            IEnumerable<T> items,
            Func<T, string> keySelector)
        {
            var output = items.OrderBy(keySelector);
            return output;
        }

        IEnumerable<T> Prepend<T>(
            IEnumerable<T> items,
            IEnumerable<T> prependix)
        {
            foreach (var item in prependix)
            {
                yield return item;
            }

            foreach (var item in items)
            {
                yield return item;
            }
        }

        IEnumerable<T> Prepend<T>(
            IEnumerable<T> items,
            params T[] prependix)
        {
            return this.Prepend(
                items,
                prependix.AsEnumerable());
        }

        IEnumerable<T> Repeat<T>(T instance, int count)
        {
            return Enumerable.Repeat(instance, count);
        }

        IEnumerable<TResult> SelectMany<TSource, TResult>(
            IEnumerable<TSource> sources,
            Func<TSource, IEnumerable<TResult>> selector)
            => sources.SelectMany(selector);

        IEnumerable<T> SeparateMany<T>(
            IEnumerable<IEnumerable<T>> enumerable,
            T separator)
        {
            var enumerator = enumerable.GetEnumerator();

            var any = enumerator.MoveNext();
            if(any)
            {
                var value = enumerator.Current;

                while (enumerator.MoveNext())
                {
                    foreach (var item in value)
                    {
                        yield return item;
                    }

                    yield return separator;

                    value = enumerator.Current;
                }

                foreach (var item in value)
                {
                    yield return item;
                }
            }
            else
            {
                yield break;
            }
        }

        IEnumerable<TResult> SeparateMany<TSource, TResult>(
            IEnumerable<TSource> enumerable,
            Func<TSource, IEnumerable<TResult>> selector,
            TResult separator)
        {
            var enumerator = enumerable.GetEnumerator();

            var any = enumerator.MoveNext();
            if (any)
            {
                var value = enumerator.Current;

                var output = selector(value);

                while (enumerator.MoveNext())
                {
                    foreach (var item in output)
                    {
                        yield return item;
                    }

                    yield return separator;

                    value = enumerator.Current;

                    output = selector(value);
                }

                foreach (var item in output)
                {
                    yield return item;
                }
            }
            else
            {
                yield break;
            }
        }

        IEnumerable<T> Skip_First<T>(IEnumerable<T> enumerable)
        {
            var output = enumerable.Skip(1);
            return output;
        }

        bool StartsWith<T>(
            IEnumerable<T> enumerable,
            IEnumerable<T> start,
            IEqualityComparer<T> equalityComparer)
        {
            var enumerableEnumeration = enumerable.GetEnumerator();
            var startEnumerator = start.GetEnumerator();

            while (startEnumerator.MoveNext())
            {
                var enumerableHasNext = enumerableEnumeration.MoveNext();
                if (!enumerableHasNext)
                {
                    // Enumerable is too short.
                    return false;
                }

                var enumerableCurrent = enumerableEnumeration.Current;
                var startCurrent = startEnumerator.Current;

                var currentIsEqual = equalityComparer.Equals(enumerableCurrent, startCurrent);
                if (!currentIsEqual)
                {
                    return false;
                }
            }

            return true;
        }

        bool StartsWith<T>(
            IEnumerable<T> enumerable,
            IEnumerable<T> start)
        {
            var equalityComparer = EqualityComparer<T>.Default;

            var output = this.StartsWith(
                enumerable,
                start,
                equalityComparer);

            return output;
        }

        /// <summary>
        /// Makes a copy of a dictionary.
        /// </summary>
        /// <remarks>
        /// Name is "ToDictionary" instead of "To_Dictionary" in order to match the default LINQ extension method name. 
        /// </remarks>
        Dictionary<TKey, TValue> ToDictionary<TKey, TValue>(IEnumerable<KeyValuePair<TKey, TValue>> pairs)
        {
            var output = pairs.ToDictionary(
                pair => pair.Key,
                pair => pair.Value);

            return output;
        }

        IEnumerable<T> To_Generic<T>(IEnumerable enumerable)
            => enumerable.Cast<T>();
    }
}
