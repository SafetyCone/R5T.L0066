using System;
using System.Collections.Generic;
using System.Linq;

using R5T.T0132;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface IEnumerableOperator : IFunctionalityMarker
    {
#pragma warning disable IDE1006 // Naming Styles
        private Implementations.IEnumerableOperator _Implementations => Implementations.EnumerableOperator.Instance;
#pragma warning restore IDE1006 // Naming Styles


        public IEnumerable<T> Append<T>(
            IEnumerable<T> enumerable,
            IEnumerable<T> appendix)
        {
            return enumerable.Concat(appendix);
        }

        public IEnumerable<T> Append<T>(
            IEnumerable<T> enumerable,
            params T[] appendix)
        {
            return enumerable.Concat(appendix);
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

        public IEnumerable<T> Get_Empty_IfDefault<T>(IEnumerable<T> values = default)
        {
            var isDefault = Instances.DefaultOperator.Is_Default(values);

            var output = isDefault
                ? this.Empty<T>()
                : values
                ;

            return output;
        }

        public IEnumerable<T> Empty<T>()
        {
            return Enumerable.Empty<T>();
        }

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

        /// <summary>
		/// Returns the entire sequence, except for the first element (skips the first element).
		/// </summary>
		public IEnumerable<T> Except_First<T>(IEnumerable<T> enumerable)
        {
            // Skip the last element.
            var output = this.Except_First(enumerable, 1);
            return output;
        }

        /// <summary>
		/// Quality-of-life name for <see cref="Enumerable.Skip{TSource}(IEnumerable{TSource}, int)"/>
		/// </summary>
		public IEnumerable<T> Except_First<T>(
            IEnumerable<T> enumerable,
            int numberOfElements)
        {
            // Use SkipLast().
            var output = enumerable.Skip(numberOfElements);
            return output;
        }

        /// <summary>
		/// Returns the entire sequence, except for the last element (skips the last element).
		/// </summary>
		public IEnumerable<T> Except_Last<T>(IEnumerable<T> enumerable)
        {
            // Skip the last element.
            var output = this.Except_Last(enumerable, 1);
            return output;
        }

        /// <summary>
		/// Quality-of-life name for <see cref="Enumerable.SkipLast{TSource}(IEnumerable{TSource}, int)"/>
		/// </summary>
		public IEnumerable<T> Except_Last<T>(
            IEnumerable<T> enumerable,
            int numberOfElements)
        {
            // Use SkipLast().
            var output = enumerable.SkipLast(numberOfElements);
            return output;
        }

        public IEnumerable<T> From<T>(T instance)
        {
            yield return instance;
        }

        public IEnumerable<T> From<T>(params T[] instances)
        {
            foreach (var instance in instances)
            {
                yield return instance;
            }
        }

        public IEnumerable<T> From<T>(params IEnumerable<T>[] enumerables)
        {
            var output = enumerables.SelectMany(enumerable => enumerable);
            return output;
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
        /// Returns true if the enumerable has no elements.
        /// </summary>
        public bool Is_Empty<T>(IEnumerable<T> items)
        {
            var any = items.Any();

            // None is not-any.
            var output = !any;
            return output;
        }

        /// <summary>
        /// Returns a new empty enumerable.
        /// </summary>
        public IEnumerable<T> New<T>()
        {
            return Enumerable.Empty<T>();
        }

        /// <summary>
        /// <para>The opposite of Any().</para>
        /// Quality-of-life overload for <see cref="Is_Empty{T}(IEnumerable{T})"/>.
        /// </summary>
        public bool None<T>(IEnumerable<T> items)
        {
            return this.Is_Empty(items);
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

        public IEnumerable<(T, T)> Zip<T>(
            IEnumerable<T> a,
            IEnumerable<T> b)
        {
            var output = a.Zip(
                b,
                (a, b) => (a, b));

            return output;
        }
    }
}
