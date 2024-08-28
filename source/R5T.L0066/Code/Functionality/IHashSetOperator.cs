using System;
using System.Collections.Generic;

using R5T.T0132;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface IHashSetOperator : IFunctionalityMarker
    {
        /// <summary>
        /// Chooses <see cref="Add_Range_KeepLast{T}(HashSet{T}, IEnumerable{T})"/> as the default behavior (which it is for <see cref="HashSet{T}"/>).
        /// </summary>
        public HashSet<T> Add_Range<T>(HashSet<T> hashSet, IEnumerable<T> items)
            => this.Add_Range_KeepLast(hashSet, items);

        /// <summary>
        /// If the hash set already contains the item, replace it with any later items.
        /// (This is the default behavior for <see cref="HashSet{T}"/>.)
        /// </summary>
        public HashSet<T> Add_Range_KeepLast<T>(HashSet<T> hashSet, IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                hashSet.Add(item);
            }

            return hashSet;
        }

        /// <summary>
        /// If the hash set already contains the item, do not replace it with any later items.
        /// </summary>
        public HashSet<T> Add_Range_KeepFirst<T>(HashSet<T> hashSet, IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                var containsItem = hashSet.Contains(item);

                // Only add the item if the hash set does not already have the item.
                if (!containsItem)
                {
                    hashSet.Add(item);
                }
            }

            return hashSet;
        }

        public void Add_Range_ThrowIfDuplicate<T>(HashSet<T> hashSet, IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                var alreadyPresent = hashSet.Contains(item);
                if (alreadyPresent)
                {
                    throw this.Get_ValueAlreadyExistsException(item);
                }
            }
        }

        /// <summary>
        /// <para>Chooses <see cref="From_KeepLast{T}(IEnumerable{T})"/> as the default.</para>
        /// <inheritdoc cref="From_KeepLast{T}(IEnumerable{T})" path="/summary"/>
        /// </summary>
        public HashSet<T> From<T>(IEnumerable<T> values)
            => this.From_KeepLast(values);

        /// <inheritdoc cref="Add_Range_KeepLast{T}(HashSet{T}, IEnumerable{T})"/>
        public HashSet<T> From_KeepLast<T>(IEnumerable<T> values)
            // Leverage the default behavior of the hashset (which is keep last).
            => new HashSet<T>(values);

        public Exception Get_ValueAlreadyExistsException<T>(T value)
        {
            var output = new Exception($"Value already exists. Attempted to add duplicate value: {value}");
            return output;
        }

        /// <summary>
        /// Quality-of-life overload for <see cref="New{T}"/>.
        /// </summary>
        public HashSet<T> Get_New<T>()
            => this.New<T>();

        public HashSet<T> New<T>()
            => new HashSet<T>();

        public HashSet<T> New_WithEqualityComparer<T>(IEqualityComparer<T> equalityComparer)
            => new HashSet<T>(equalityComparer);

        public void Remove_Range<T>(HashSet<T> hash, IEnumerable<T> valuesToRemove)
        {
            foreach (var value in valuesToRemove)
            {
                hash.Remove(value);
            }
        }
    }
}
