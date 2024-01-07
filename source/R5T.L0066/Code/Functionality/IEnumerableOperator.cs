using System;
using System.Collections.Generic;
using System.Linq;

using R5T.T0132;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface IEnumerableOperator : IFunctionalityMarker
    {
        public IEnumerable<T> Append<T>(
            IEnumerable<T> enumerable,
            IEnumerable<T> appendix)
        {
            return enumerable.Concat(appendix);
        }

        public IEnumerable<T> Empty<T>()
        {
            return Enumerable.Empty<T>();
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

        /// <summary>
        /// Returns a new empty enumerable.
        /// </summary>
        public IEnumerable<T> New<T>()
        {
            return Enumerable.Empty<T>();
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
    }
}
