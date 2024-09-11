using System;

using R5T.T0131;


namespace R5T.L0066
{
    [ValuesMarker]
    public partial interface IPredicates : IValuesMarker
    {
        /// <inheritdoc cref="IPredicateOperator.For{T}" path="/summary"/>
        /// <remarks>
        /// See: <see cref="IPredicateOperator.For{T}"/>
        /// </remarks>
        // Allow a method in this values instance, for quality-of-life.
        // It will *not* get picked up in instances survey.
        public IPredicates<T> For<T>()
            => Predicates<T>.Instance;
    }


    [ValuesMarker]
    public partial interface IPredicates<T> : IValuesMarker
    {
        /// <summary>
        /// Always returns false.
        /// </summary>
        Func<T, bool> False => x => false;

        /// <summary>
        /// Always returns true.
        /// </summary>
        Func<T, bool> True => x => true;
    }
}
