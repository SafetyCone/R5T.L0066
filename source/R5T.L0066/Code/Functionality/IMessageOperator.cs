using System;
using System.Collections.Generic;

using R5T.T0132;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface IMessageOperator : IFunctionalityMarker
    {
        public string Get_UnequalListCountsMessage(int countA, int countB)
        {
            var message = $"Unequal list counts. Found: {countA}, {countB}.";
            return message;
        }

        /// <summary>
        /// <inheritdoc cref="Documentation.CollectionCountsNotActuallyChecked" path="/summary"/>
        /// Just gets the message assuming that is the case.
        /// </summary>
        public string Get_UnequalListCountsMessage<T>(
            IList<T> a,
            IList<T> b)
        {
            var message = this.Get_UnequalListCountsMessage(
                a.Count,
                b.Count);

            return message;
        }
    }
}
