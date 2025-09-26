using System;
using System.Collections.Generic;


namespace R5T.L0066.Extensions
{
    public static class DictionaryExtensions
    {
        /// <inheritdoc cref="IDictionaryOperator.Acquire_Value{TKey, TValue}(IDictionary{TKey, TValue}, TKey, Func{TValue})"/>
        public static TValue Acquire_Value<TKey, TValue>(this IDictionary<TKey, TValue> dictionary,
            TKey key,
            Func<TValue> valueConstructor)
            => Instances.DictionaryOperator.Acquire_Value(
                dictionary,
                key,
                valueConstructor);

        public static void Add<TKey1, TKey2, TValue>(this IDictionary<TKey1, Dictionary<TKey2, TValue>> dictionaryOfDictionaries,
            TKey1 key1,
            TKey2 key2,
            TValue value,
            IEqualityComparer<TKey2> key2EqualityComparer)
            => Instances.DictionaryOperator.Add(
                dictionaryOfDictionaries,
                key1,
                key2,
                value,
                key2EqualityComparer);

        public static void Add<TKey1, TKey2, TValue>(this IDictionary<TKey1, Dictionary<TKey2, TValue>> dictionaryOfDictionaries,
            TKey1 key1,
            TKey2 key2,
            TValue value)
            => Instances.DictionaryOperator.Add(
                dictionaryOfDictionaries,
                key1,
                key2,
                value);

        public static Dictionary<TKey, TValue> Add_AndReturn<TKey, TValue>(this Dictionary<TKey, TValue> dictionary,
            TKey key,
            TValue value)
            => Instances.DictionaryOperator.Add_AndReturn(
                dictionary,
                key,
                value);

        public static Dictionary<TKey, TValue> Add_AndReturn<TKey, TValue>(this Dictionary<TKey, TValue> dictionary,
            KeyValuePair<TKey, TValue> pair)
            => Instances.DictionaryOperator.Add_AndReturn(
                dictionary,
                pair);

        public static Dictionary<TKey, TValue> Add_AndReturn<TKey, TValue>(this Dictionary<TKey, TValue> dictionary,
            IEnumerable<KeyValuePair<TKey, TValue>> pairs)
            => Instances.DictionaryOperator.Add_AndReturn(
                dictionary,
                pairs);

        public static Dictionary<TKey, TValue> Add_AndReturn<TKey, TValue>(this Dictionary<TKey, TValue> dictionary,
            params KeyValuePair<TKey, TValue>[] pairs)
            => Instances.DictionaryOperator.Add_AndReturn(
                dictionary,
                pairs);

        public static TValue Add_AndReturnValue<TKey, TValue>(this IDictionary<TKey, TValue> dictionary,
            TKey key,
            TValue value)
            => Instances.DictionaryOperator.Add_AndReturnValue(
                dictionary,
                key,
                value);

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

        public static bool TryGetValue<TKey1, TKey2, TValue>(this IDictionary<TKey1, Dictionary<TKey2, TValue>> dictionaryOfDictionaries,
            TKey1 key1,
            TKey2 key2,
            out TValue value)
            => Instances.DictionaryOperator.TryGetValue(dictionaryOfDictionaries,
                key1,
                key2,
                out value);

        public static Dictionary<TKey, TValue[]> To_Dictionary_Arrayed<TKey, TValue>(this IDictionary<TKey, List<TValue>> dictionary)
            => Instances.DictionaryOperator.To_DictionaryArrayed(dictionary);
    }
}
