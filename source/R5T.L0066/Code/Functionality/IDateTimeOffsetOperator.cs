using System;

using R5T.T0132;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface IDateTimeOffsetOperator : IFunctionalityMarker
    {
        public DateTimeOffset From_DateTime_Utc(DateTime dateTimeUtc)
        {
            var dateTimeOffset = new DateTimeOffset(dateTimeUtc, TimeSpan.Zero);

            return dateTimeOffset;
        }

        public DateTimeOffset From_DateTime_Local(DateTime dateTimeLocal)
        {
            var localOffset = this.Get_LocalOffsetFromUtc();

            var dateTimeOffset = new DateTimeOffset(dateTimeLocal, localOffset);

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

        public DateTimeOffset Get_Now_Local()
        {
            var nowLocal = DateTimeOffset.Now;
            return nowLocal;
        }

        public DateTimeOffset Get_Now_Utc()
        {
            var nowUtc = DateTimeOffset.UtcNow;
            return nowUtc;
        }

        /// <summary>
        /// Chooses <see cref="Get_Now_Local"/> as the default.
        /// </summary>
        public DateTimeOffset Get_Now()
        {
            var now = this.Get_Now_Local();
            return now;
        }

        public TimeSpan Get_LocalOffsetFromUtc()
        {
            var currentOffset = Instances.TimeSpanOperator.Get_OffsetFromUtc();
            return currentOffset;
        }
    }
}
