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
        public Dictionary<TKey, TValue> To_Generic<TKey, TValue>(IDictionary dictionary)
            => Instances.EnumerableOperator.To_Generic<TKey>(dictionary.Keys)
                .ToDictionary(
                    key => key,
                    key => (TValue)dictionary[key]);
    }
}
