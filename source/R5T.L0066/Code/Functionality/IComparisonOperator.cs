using System;
using System.Collections.Generic;

using F10Y.T0011;
using R5T.T0132;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface IComparisonOperator : IFunctionalityMarker,
        F10Y.L0000.IComparisonOperator
    {
        [Ignore]
        public F10Y.L0000.IComparisonOperator _F10Y_L0000 => F10Y.L0000.ComparisonOperator.Instance;


        /// <summary>
        /// Chooses <see cref="Get_Comparer_DefaultForType{T}"/> as the default.
        /// </summary>
        public Comparer<T> Get_Comparer<T>()
            => this.Get_Comparer_DefaultForType<T>();

        public Comparer<T> Get_Comparer_DefaultForType<T>()
            => Comparer<T>.Default;

        /// <summary>
        /// Determines if the comparison result is the equal to result (<see cref="IComparisonResults.EqualTo"/>, <inheritdoc cref="IComparisonResults.EqualTo" path="descendant::value"/>).
        /// </summary>
        public bool IsEqualResult(int comparisonResult)
        {
            var output = comparisonResult == Instances.ComparisonResults.EqualTo;
            return output;
        }

        /// <summary>
        /// Determines if the comparison result is one of the values other than the equal to result (<see cref="IComparisonResults.EqualTo"/>, <inheritdoc cref="IComparisonResults.EqualTo" path="descendant::value"/>)
        /// such as <see cref="IComparisonResults.GreaterThan"/>, <inheritdoc cref="IComparisonResults.GreaterThan" path="descendant::value"/>, or <see cref="IComparisonResults.LessThan"/>, <inheritdoc cref="IComparisonResults.LessThan" path="descendant::value"/>.
        /// </summary>
        public bool IsNotEqualResult(int comparisonResult)
        {
            var output = !this.IsEqualResult(comparisonResult);
            return output;
        }

        public int Reverse(int comparisonResult)
        {
            if (comparisonResult == Instances.ComparisonResults.GreaterThan)
            {
                return Instances.ComparisonResults.LessThan;
            }

            if(comparisonResult == Instances.ComparisonResults.LessThan)
            {
                return Instances.ComparisonResults.GreaterThan;
            }

            return Instances.ComparisonResults.EqualTo;
        }
    }
}
