using System;

using R5T.T0132;
using R5T.T0143;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface IDoubleOperator : IFunctionalityMarker,
        F10Y.L0000.IDoubleOperator
    {
#pragma warning disable IDE1006 // Naming Styles

        [Ignore]
        F10Y.L0000.IDoubleOperator _F10Y_L0000 => F10Y.L0000.DoubleOperator.Instance;

#pragma warning restore IDE1006 // Naming Styles


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
