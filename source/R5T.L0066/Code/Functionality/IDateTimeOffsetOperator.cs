using System;

using F10Y.T0011;

using R5T.T0132;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface IDateTimeOffsetOperator : IFunctionalityMarker,
        F10Y.L0000.IDateTimeOffsetOperator
    {
#pragma warning disable IDE1006 // Naming Styles

        [Ignore]
        F10Y.L0000.IDateTimeOffsetOperator _F10Y_L0000 => F10Y.L0000.DateTimeOffsetOperator.Instance;

#pragma warning restore IDE1006 // Naming Styles


        public DateTimeOffset From_DateTime_Utc(DateTime dateTimeUtc)
        {
            var dateTimeOffset = new DateTimeOffset(dateTimeUtc, TimeSpan.Zero);

            return dateTimeOffset;
        }

        public DateTimeOffset From_UnixMilliseconds(long unixMilliseconds)
        {
            var output = DateTimeOffset.FromUnixTimeMilliseconds(unixMilliseconds);
            return output;
        }

        public DateTimeOffset From_UnixMilliseconds(ulong unixMilliseconds)
        {
            var unixMilliseconds_Long = Convert.ToInt64(unixMilliseconds);

            var output = this.From_UnixMilliseconds(unixMilliseconds_Long);
            return output;
        }
    }
}
