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

        public Dictionary<TKey, TValue> Clone<TKey, TValue>(IDictionary<TKey, TValue> dictionary)
        {
            var output = new Dictionary<TKey, TValue>(dictionary);
            return output;
        }

        public Dictionary<TKey, TValue> To_Generic<TKey, TValue>(IDictionary dictionary)
            => Instances.EnumerableOperator.To_Generic<TKey>(dictionary.Keys)
                .ToDictionary(
                    key => key,
                    key => (TValue)dictionary[key]);
    }
}
