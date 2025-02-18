using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using R5T.T0132;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface ICollectionOperator : IFunctionalityMarker
    {
        public bool Equal_Counts<T>(
            ICollection<T> a,
            ICollection<T> b)
            => a.Count == b.Count;
    }
}
