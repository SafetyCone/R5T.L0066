using System;

using R5T.T0132;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface IPredicateProvider : IFunctionalityMarker
    {
        /// <summary>
        /// Gets a predicate that always returns true for its input.
        /// </summary>
        public Func<T, bool> Get_True<T>()
            => _ => true;
    }
}
