using System;

using F10Y.T0011;

using R5T.T0132;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface ITimeSpanOperator : IFunctionalityMarker,
        F10Y.L0000.ITimeSpanOperator
    {
#pragma warning disable IDE1006 // Naming Styles

        [Ignore]
        F10Y.L0000.ITimeSpanOperator _F10Y_L0000 => F10Y.L0000.TimeSpanOperator.Instance;

#pragma warning restore IDE1006 // Naming Styles


        public string ToString_NumberOfSeconds_WithMilliseconds(TimeSpan timeSpan)
        {
            var totalSeconds = timeSpan.TotalSeconds;

            var representation = Instances.DoubleOperator.ToString_WithThreeDecimalPlaces(totalSeconds);
            return representation;
        }
    }
}
