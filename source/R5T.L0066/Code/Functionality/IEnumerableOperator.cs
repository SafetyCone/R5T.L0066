using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using R5T.T0132;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface IEnumerableOperator : IFunctionalityMarker,
        F10Y.L0000.IEnumerableOperator
    {
#pragma warning disable IDE1006 // Naming Styles
        private Implementations.IEnumerableOperator _Implementations => Implementations.EnumerableOperator.Instance;
#pragma warning restore IDE1006 // Naming Styles


        public bool Any_Duplicates<T>(
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

        public bool Any_Duplicates<T>(IEnumerable<T> enumerable)
            => this.Any_Duplicates(
                enumerable,
                EqualityComparer<T>.Default);

        public IEnumerable<T> Append_If<T>(
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

        public IEnumerable<T> AppendRange<T>(
            IEnumerable<T> enumerable,
            IEnumerable<T> appendix)
        {
            return enumerable.Concat(appendix);
        }

        public IEnumerable<T> AppendRange<T>(
            IEnumerable<T> enumerable,
            Func<IEnumerable<T>> appendixGenerator)
        {
            var appendix = appendixGenerator();

            var output = this.AppendRange(enumerable, appendix);
            return output;
        }

        public IEnumerable<T> Concatenate<T>(IEnumerable<IEnumerable<T>> enumerables)
        {
            var output = enumerables
                .SelectMany(enumerable => enumerable)
                ;

            return output;
        }

        public IEnumerable<T> Concatenate<T>(
            params IEnumerable<T>[] enumerables)
            => this.Concatenate(
                enumerables.AsEnumerable());

        public bool ContainsAll<T>(
            IEnumerable<T> superset,
            IEnumerable<T> subset)
        {
            var output = subset.Except(superset).None();
            return output;
        }

        public bool Contains<T>(
            IEnumerable<T> array,
            T item,
            IEqualityComparer<T> equalityComparer)
        {
            var output = array.Contains(
                item,
                equalityComparer);

            return output;
        }

        public bool Contains<T>(
            IEnumerable<T> array,
            T item)
        {
            var output = array.Contains(item);
            return output;
        }

        public IEnumerable<T> Enumerate_Duplicates<T>(
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

        public IEnumerable<T> Enumerate_Duplicates<T>(IEnumerable<T> enumerable)
            => this.Enumerate_Duplicates(
                enumerable,
                EqualityComparer<T>.Default);

        public IEnumerable<int> Enumerate_Range_Inclusive(
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

        public IEnumerable<int> Enumerate_Range_Inclusive(
            int start,
            int end)
            => this.Enumerate_Range_Inclusive(start, end, Instances.Integers.One);

        public T[] Get_Duplicates<T>(
            IEnumerable<T> enumerable,
            IEqualityComparer<T> equalityComparer)
        {
            var output = this.Enumerate_Duplicates(
                enumerable,
                equalityComparer)
                .ToArray();

            return output;
        }

        public T[] Get_Duplicates<T>(IEnumerable<T> enumerable)
            => this.Get_Duplicates(
                enumerable,
                EqualityComparer<T>.Default);

        public IEnumerable<T> Get_Empty_IfDefault<T>(IEnumerable<T> values = default)
        {
            var isDefault = Instances.DefaultOperator.Is_Default(values);

            var output = isDefault
                ? this.Empty<T>()
                : values
                ;

            return output;
        }

        public bool Equal_ElementSets<T>(
            IEnumerable<T> a,
            IEnumerable<T> b,
            IEqualityComparer<T> equalityComparer)
            => a.Except(b, equalityComparer)
            .None();

        public bool Equal_ElementSets<T>(
            IEnumerable<T> a,
            IEnumerable<T> b)
            => this.Equal_ElementSets(a, b,
                Instances.EqualityOperator.Get_EqualityComparer<T>());

        public IEnumerable<T> Except<T>(
            IEnumerable<T> items,
            T item)
            where T : IEquatable<T>
        {
            var output = items.Where(x => !x.Equals(item));
            return output;
        }

        public IEnumerable<T> Except<T>(
            IEnumerable<T> items,
            T item,
            IEqualityComparer<T> equalityComparer)
        {
            var output = items.Where(x => !equalityComparer.Equals(x, item));
            return output;
        }

        public void For_Each<T>(IEnumerable<T> enumerable, Action<T> action)
        {
            foreach (var item in enumerable)
            {
                action(item);
            }
        }

        public async Task For_Each<T>(IEnumerable<T> enumerable, Func<T, Task> action)
        {
            foreach (var item in enumerable)
            {
                await action(item);
            }
        }

        public IEnumerable<T> From<T>(T instance)
        {
            yield return instance;
        }

        public IEnumerable<T[]> From_Array<T>(T[] instance)
        {
            yield return instance;
        }

        public T Get_Second<T>(IEnumerable<T> values)
        {
            var output = this.Get_Nth(values, 2);
            return output;
        }

        public T Get_First<T>(IEnumerable<T> values)
        {
            var output = _Implementations.Get_First_UsingEnumerator(values);
            return output;
        }

        public T Get_Nth<T>(
            IEnumerable<T> values,
            int n)
        {
            var output = values
                .Skip(n - 1)
                .First();

            return output;
        }

        /// <summary>
		/// Enumerates the enumerable at the current moment.
		/// </summary>
        /// <remarks>
        /// This is a quality-of-life overload of <see cref="Enumerable.ToArray{TSource}(IEnumerable{TSource})"/>.
        /// While the method does enumerate the enumerable at the moment it is called, it's name suggests this is just a side effect.
        /// You frequently want to communicate to callers that you aver enumerating the enumerable now, not turning it into an array.
        /// </remarks>
        public T[] Now<T>(IEnumerable<T> items)
        {
            var output = items.ToArray();
            return output;
        }

        public IEnumerable<T> OrderAlphabetically<T>(
            IEnumerable<T> items,
            Func<T, string> keySelector)
        {
            var output = items.OrderBy(keySelector);
            return output;
        }

        public IEnumerable<IEnumerable<T>> OrderBy_First<T>(IEnumerable<IEnumerable<T>> values)
        {
            var valuesAndFirst = values
                .Select(x => (First: x.FirstOrDefault(), Values: x))
                .OrderBy(x => x.First)
                .Select(x => x.Values)
                ;

            return valuesAndFirst;
        }

        public IEnumerable<T> Prepend<T>(
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

        public IEnumerable<T> Prepend<T>(
            IEnumerable<T> items,
            params T[] prependix)
        {
            return this.Prepend(
                items,
                prependix.AsEnumerable());
        }

        public IEnumerable<T> Repeat<T>(T instance, int count)
        {
            return Enumerable.Repeat(instance, count);
        }

        public IEnumerable<TResult> SelectMany<TSource, TResult>(
            IEnumerable<TSource> sources,
            Func<TSource, IEnumerable<TResult>> selector)
            => sources.SelectMany(selector);

        public IEnumerable<T> Separate<T>(
            IEnumerable<T> enumerable,
            T separator)
        {
            var enumerator = enumerable.GetEnumerator();

            enumerator.MoveNext();

            var value = enumerator.Current;

            while(enumerator.MoveNext())
            {
                yield return value;

                yield return separator;

                value = enumerator.Current;
            }

            yield return value;
        }

        public IEnumerable<T> SeparateMany<T>(
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

        public IEnumerable<TResult> SeparateMany<TSource, TResult>(
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

        public IEnumerable<T> Skip_First<T>(IEnumerable<T> enumerable)
        {
            var output = enumerable.Skip(1);
            return output;
        }

        public bool StartsWith<T>(
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

        public bool StartsWith<T>(
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
        public Dictionary<TKey, TValue> ToDictionary<TKey, TValue>(IEnumerable<KeyValuePair<TKey, TValue>> pairs)
        {
            var output = pairs.ToDictionary(
                pair => pair.Key,
                pair => pair.Value);

            return output;
        }

        public IEnumerable<T> To_Generic<T>(IEnumerable enumerable)
            => enumerable.Cast<T>();
    }
}
