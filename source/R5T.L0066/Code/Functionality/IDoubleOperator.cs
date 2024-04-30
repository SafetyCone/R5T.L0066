using System;

using R5T.T0132;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface IDoubleOperator : IFunctionalityMarker
    {
        /// <summary>
        /// Converts a double to a string representation with three decimal places.
        /// </summary>
        public string ToString_WithThreeDecimalPlaces(double value)
        {
            var output = $"{value:0.000}";
            return output;
        }
    }
}
