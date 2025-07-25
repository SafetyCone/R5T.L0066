using System;
using System.Collections.Generic;


namespace R5T.L0066.Extensions
{
    public static class HashSetExtensions
    {
        /// <inheritdoc cref="F10Y.L0000.IHashSetOperator.Add_Range{T}(HashSet{T}, IEnumerable{T})"/>
        public static HashSet<T> Add_Range<T>(this HashSet<T> hashSet, IEnumerable<T> items)
        {
            return Instances.HashSetOperator.Add_Range(hashSet, items);
        }

        /// <inheritdoc cref="F10Y.L0000.IHashSetOperator.Add_Range_KeepLast{T}(HashSet{T}, IEnumerable{T})"/>
        public static HashSet<T> Add_Range_KeepLast<T>(this HashSet<T> hashSet, IEnumerable<T> items)
        {
            return HashSetOperator.Instance.Add_Range_KeepLast(hashSet, items);
        }

        /// <inheritdoc cref="Add_Range_KeepFirst{T}(HashSet{T}, IEnumerable{T})"/>
        public static HashSet<T> Add_Range_KeepFirst<T>(this HashSet<T> hashSet, IEnumerable<T> items)
        {
            return HashSetOperator.Instance.Add_Range_KeepFirst(hashSet, items);
        }

        public static void Add_Range_ThrowIfDuplicate<T>(this HashSet<T> hashSet, IEnumerable<T> items)
        {
            HashSetOperator.Instance.Add_Range_ThrowIfDuplicate(hashSet, items);
        }
    }
}
