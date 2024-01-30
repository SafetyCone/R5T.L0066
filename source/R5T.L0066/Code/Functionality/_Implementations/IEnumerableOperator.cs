using System;
using System.Collections.Generic;
using System.Linq;

using R5T.T0132;


namespace R5T.L0066.Implementations
{
    [FunctionalityMarker]
    public partial interface IEnumerableOperator : IFunctionalityMarker
    {
        public T Get_First_UsingEnumerator<T>(IEnumerable<T> values)
        {
            var enumerator = values.GetEnumerator();

            // Enumerator starts before first element.
            var hasFirst = enumerator.MoveNext();
            if(!hasFirst)
            {
                throw new Exception("Enumerable was empty.");
            }

            var output = enumerator.Current;
            return output;
        }

        public T Get_First_UsingLinq<T>(IEnumerable<T> values)
        {
            var output = values.First();
            return output;
        }
    }
}
