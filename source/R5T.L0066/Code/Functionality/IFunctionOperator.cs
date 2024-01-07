using System;
using System.Collections.Generic;

using R5T.T0132;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface IFunctionOperator : IFunctionalityMarker
    {
        /// <summary>
        /// Given a value and a set of modifier functions (functions that take the value, and return a value of the same type),
        /// feed the value through the modifier functions.
        /// </summary>
        public T Run_Modifiers<T>(
            T value,
            IEnumerable<Func<T, T>> modifiers)
        {
            foreach (var modifier in modifiers)
            {
                value = modifier(value);
            }

            return value;
        }
    }
}
