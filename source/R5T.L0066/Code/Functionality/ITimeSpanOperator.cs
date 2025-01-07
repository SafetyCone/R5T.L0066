using System;

using R5T.T0132;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface ITimeSpanOperator : IFunctionalityMarker
    {
        public TimeSpan From_Days(int days)
            => new TimeSpan(days, 0, 0, 0);

        public TimeSpan From_Hours(int hours)
            => new TimeSpan(hours, 0, 0);

        public TimeSpan From_Milliseconds(int milliseconds)
            => new TimeSpan(0, 0, 0, 0, milliseconds);

        public TimeSpan From_Minutes(int minutes)
            => new TimeSpan(0, minutes, 0);

        public TimeSpan From_Seconds(int seconds)
            => new TimeSpan(0, 0, seconds);

        public TimeSpan From_Ticks(long ticks)
            => new TimeSpan(ticks);

        /// <summary>
		/// The offset returned satisfies:
		/// local time = UTC time + offset.
		/// </summary>
		/// <returns></returns>
		public TimeSpan Get_OffsetFromUtc()
        {
            var offsetFromUtc = DateTimeOffset.Now.Offset;
            return offsetFromUtc;
        }

        public string ToString_NumberOfSeconds_WithMilliseconds(TimeSpan timeSpan)
        {
            var totalSeconds = timeSpan.TotalSeconds;

            var representation = Instances.DoubleOperator.ToString_WithThreeDecimalPlaces(totalSeconds);
            return representation;
        }
    }
}
