using System;
using System.Collections.Generic;

using R5T.T0132;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface IComparisonOperator : IFunctionalityMarker
    {
        /// <summary>
        /// Chooses <see cref="Get_Comparer_DefaultForType{T}"/> as the default.
        /// </summary>
        public Comparer<T> Get_Comparer<T>()
            => this.Get_Comparer_DefaultForType<T>();

        public Comparer<T> Get_Comparer_DefaultForType<T>()
            => Comparer<T>.Default;

        public bool IsEqualResult(int comparisonResult)
        {
            var output = comparisonResult == Instances.ComparisonResults.EqualTo;
            return output;
        }

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
