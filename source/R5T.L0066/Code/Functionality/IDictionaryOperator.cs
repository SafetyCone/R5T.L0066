using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using R5T.T0132;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface IDictionaryOperator : IFunctionalityMarker
    {
        public TValue Acquire_Value<TKey, TValue>(
            IDictionary<TKey, TValue> dictionary,
            TKey key,
            Func<TValue> valueConstructor)
        {
            if (dictionary.ContainsKey(key))
            {
                var value = dictionary[key];
                return value;
            }
            else
            {
                var value = valueConstructor();

                return this.Add_AndReturnValue(
                    dictionary,
                    key,
                    value);
            }
        }

        public TValue Add_AndReturnValue<TKey, TValue>(IDictionary<TKey, TValue> dictionary,
            TKey key,
            TValue value)
        {
            dictionary.Add(key, value);

            return value;
        }

        public void Add<TKey1, TKey2, TValue>(
            IDictionary<TKey1, Dictionary<TKey2, TValue>> dictionaryOfDictionaries,
            TKey1 key1,
            TKey2 key2,
            TValue value,
            IEqualityComparer<TKey2> key2EqualityComparer)
        {
            var subDictionary = this.Acquire_Value(
                dictionaryOfDictionaries,
                key1,
                () => new Dictionary<TKey2, TValue>(key2EqualityComparer));

            subDictionary.Add(
                key2,
                value);
        }

        public void Add<TKey1, TKey2, TValue>(
            IDictionary<TKey1, Dictionary<TKey2, TValue>> dictionaryOfDictionaries,
            TKey1 key1,
            TKey2 key2,
            TValue value)
            => this.Add(
                dictionaryOfDictionaries,
                key1,
                key2,
                value,
                EqualityComparer<TKey2>.Default);

        public void Add<TKey, TValue>(
            Dictionary<TKey, TValue> dictionary,
            KeyValuePair<TKey, TValue> pair)
            => this.Add_KeyValuePair(
                dictionary,
                pair);

        public void Add<TKey, TValue>(
            Dictionary<TKey, TValue> dictionary,
            IEnumerable<KeyValuePair<TKey, TValue>> pairs)
            => this.Add_KeyValuePairs(
                dictionary,
                pairs);

        public void Add<TKey, TValue>(
            Dictionary<TKey, TValue> dictionary,
            params KeyValuePair<TKey, TValue>[] pairs)
            => this.Add_KeyValuePairs(
                dictionary,
                pairs);

        public void Add_KeyValuePair<TKey, TValue>(
            Dictionary<TKey, TValue> dictionary,
            KeyValuePair<TKey, TValue> pair)
            => dictionary.Add(pair.Key, pair.Value);

        public void Add_KeyValuePairs<TKey, TValue>(
            Dictionary<TKey, TValue> dictionary,
            IEnumerable<KeyValuePair<TKey, TValue>> pairs)
        {
            foreach (var pair in pairs)
            {
                this.Add_KeyValuePair(
                    dictionary,
                    pair);
            }
        }

        public void Add_KeyValuePairs<TKey, TValue>(
            Dictionary<TKey, TValue> dictionary,
            params KeyValuePair<TKey, TValue>[] pairs)
            => this.Add_KeyValuePairs(
                dictionary,
                pairs.AsEnumerable());

        public Dictionary<TKey, TValue> Add_AndReturn<TKey, TValue>(
            Dictionary<TKey, TValue> dictionary,
            TKey key,
            TValue value)
        {
            dictionary.Add(key, value);

            return dictionary;
        }

        public Dictionary<TKey, TValue> Add_AndReturn<TKey, TValue>(
            Dictionary<TKey, TValue> dictionary,
            KeyValuePair<TKey, TValue> pair)
        {
            dictionary.Add(pair.Key, pair.Value);

            return dictionary;
        }

        public Dictionary<TKey, TValue> Add_AndReturn<TKey, TValue>(
            Dictionary<TKey, TValue> dictionary,
            IEnumerable<KeyValuePair<TKey, TValue>> pairs)
        {
            this.Add_KeyValuePairs(
                dictionary,
                pairs);

            return dictionary;
        }

        public Dictionary<TKey, TValue> Add_AndReturn<TKey, TValue>(
            Dictionary<TKey, TValue> dictionary,
            params KeyValuePair<TKey, TValue>[] pairs)
            => this.Add_AndReturn(
                dictionary,
                pairs.AsEnumerable());

        /// <summary>
        /// Adds the key-value pair if the key does not exist, else replaces the value for the given key if the key already exists.
        /// </summary>
        public void Add_OrReplace<TKey, TValue>(
            IDictionary<TKey, TValue> dictionary,
            TKey key,
            TValue value)
        {
            var wasAdded = dictionary.TryAdd(key, value);
            if(!wasAdded)
            {
                dictionary[key] = value;
            }
        }

        public void Add_Range<TKey, TValue>(
            IDictionary<TKey, TValue> dictionary,
            IEnumerable<KeyValuePair<TKey, TValue>> pairs)
        {
            foreach (var pair in pairs)
            {
                dictionary.Add(pair);
            }
        }

        /// <summary>
        /// If there is an expandable list of values for each key, add the value to either a new list (if the key does not already exist), or the existing list.
        /// </summary>
        public void Add_Value<TKey, TValue>(
            IDictionary<TKey, List<TValue>> dictionary,
            TKey key,
            TValue value)
        {
            var hasValue = dictionary.TryGetValue(key, out List<TValue> list);
            if (!hasValue)
            {
                list = new List<TValue>();

                dictionary.Add(key, list);
            }

            list.Add(value);
        }

        public void Add_Value<TKey, TValue>(
            IDictionary<TKey, IList<TValue>> dictionary,
            Func<IList<TValue>> listConstructor,
            TKey key,
            TValue value)
        {
            var hasValue = dictionary.TryGetValue(key, out IList<TValue> list);
            if (!hasValue)
            {
                list = listConstructor();

                dictionary.Add(key, list);
            }

            list.Add(value);
        }

        public Dictionary<TKey, TValue> Clone<TKey, TValue>(IDictionary<TKey, TValue> dictionary)
        {
            var output = new Dictionary<TKey, TValue>(dictionary);
            return output;
        }

        public IEnumerable<TValue> Get_Values<TKey, TValue>(
            IDictionary<TKey, TValue> dictionary,
            IEnumerable<TKey> keys)
        {
            foreach (var key in keys)
            {
                yield return dictionary[key];
            }
        }

        public int Integrate_Values<TKey, TValue>(
            Dictionary<TKey, TValue> destination,
            Dictionary<TKey, TValue> source)
        {
            var updated_Count = 0;

            foreach (var (key, value) in source)
            {
                Instances.DictionaryOperator.Add_OrReplace(
                    destination,
                    key,
                    value);

                updated_Count++;
            }

            return updated_Count;
        }

        public int Integrate_Values<TKey, TValue>(
            Dictionary<TKey, TValue[]> destination,
            Dictionary<TKey, TValue[]> source)
        {
            var updated_Count = 0;

            foreach (var (key, value) in source)
            {
                Instances.DictionaryOperator.Add_OrReplace(
                    destination,
                    key,
                    value);

                updated_Count += value.Length;
            }

            return updated_Count;
        }

        public Dictionary<TKey, TValue> To_Generic<TKey, TValue>(IDictionary dictionary)
            => Instances.EnumerableOperator.To_Generic<TKey>(dictionary.Keys)
                .ToDictionary(
                    key => key,
                    key => (TValue)dictionary[key]);

        public bool TryGetValue<TKey1, TKey2, TValue>(IDictionary<TKey1, Dictionary<TKey2, TValue>> dictionaryOfDictionaries,
            TKey1 key1,
            TKey2 key2,
            out TValue value)
        {
            var hasSubDictionary = dictionaryOfDictionaries.TryGetValue(
                key1,
                out var subDictionary);

            if(!hasSubDictionary)
            {
                value = default;

                return false;
            }

            var output = subDictionary.TryGetValue(
                key2,
                out value);

            return output;
        }
    }
}
