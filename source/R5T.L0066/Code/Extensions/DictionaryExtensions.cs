using System;
using System.Collections.Generic;


namespace R5T.L0066.Extensions
{
    public static class DictionaryExtensions
    {
        public static void Add_OrReplace<TKey, TValue>(this IDictionary<TKey, TValue> dictionary,
            TKey key,
            TValue value)
            => Instances.DictionaryOperator.Add_OrReplace(
                dictionary,
                key,
                value);

        public static void Add_Range<TKey, TValue>(this IDictionary<TKey, TValue> dictionary,
            IEnumerable<KeyValuePair<TKey, TValue>> pairs)
            => Instances.DictionaryOperator.Add_Range(
                dictionary,
                pairs);

        public static Dictionary<TKey, TValue> Clone<TKey, TValue>(this IDictionary<TKey, TValue> dictionary)
            => Instances.DictionaryOperator.Clone(dictionary);

        public static IEnumerable<TValue> Get_Values<TKey, TValue>(this IDictionary<TKey, TValue> dictionary,
            IEnumerable<TKey> keys)
            => Instances.DictionaryOperator.Get_Values(
                dictionary,
                keys);
    }
}
