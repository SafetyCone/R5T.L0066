using System;

using R5T.T0132;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface IRangeOperator : IFunctionalityMarker
    {
        public bool Contains(
            Range range,
            int index)
        {
            var output = this.Contains_Inclusive(
                range,
                index);

            return output;
        }

        /// <summary>
        /// Inclusive of the start and end indices.
        /// </summary>
        public bool Contains_Inclusive(
            Range range,
            int index)
        {
            var output = true
                && range.Start.Value <= index
                && range.End.Value > index
                ;

            return output;
        }
    }
}
