using System;

using R5T.T0132;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface IComparisonOperator : IFunctionalityMarker
    {
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
