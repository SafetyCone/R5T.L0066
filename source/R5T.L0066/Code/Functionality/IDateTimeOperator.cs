using System;
using System.Globalization;

using R5T.T0132;
using R5T.T0143;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface IDateTimeOperator : IFunctionalityMarker,
        F10Y.L0000.IDateTimeOperator
    {
#pragma warning disable IDE1006 // Naming Styles

        [Ignore]
        public F10Y.L0000.IDateTimeOperator _F10Y_L0000 => F10Y.L0000.DateTimeOperator.Instance;

#pragma warning restore IDE1006 // Naming Styles


        public DateTime From_UnixMillis_AssumeUtc(long unixMilliseconds)
            => Instances.DateTimeOffsetOperator.From_UnixMilliseconds(unixMilliseconds)
                .UtcDateTime;

        public DateTime From_UnixMillis_AssumeLocal(long unixMilliseconds)
            => Instances.DateTimeOffsetOperator.From_UnixMilliseconds(unixMilliseconds)
                .LocalDateTime;

        public DateTime From_UnixMillis_AssumeUtc(ulong unixMilliseconds)
            => Instances.DateTimeOffsetOperator.From_UnixMilliseconds(unixMilliseconds)
                .UtcDateTime;

        public DateTime From_UnixMillis_AssumeLocal(ulong unixMilliseconds)
            => Instances.DateTimeOffsetOperator.From_UnixMilliseconds(unixMilliseconds)
                .LocalDateTime;

        public DateTime ParseExact(
            string dateTimeString,
            string format)
        {
            var dateTime = DateTime.ParseExact(
                dateTimeString,
                format,
                Instances.FormatProviders.Default);

            return dateTime;
        }

        /// <summary>
        /// Chooses <see cref="ToString_YYYYMMDD_HHMMSS_Space(DateTime)"/> as the default.
        /// <para><inheritdoc cref="ToString_YYYYMMDD_HHMMSS_Space(DateTime)" path="/summary"/></para>
        /// </summary>
        public string ToString_YYYYMMDD_HHMMSS(DateTime dateTime)
        {
            var output = this.ToString_YYYYMMDD_HHMMSS_Space(dateTime);
            return output;
        }

        /// <inheritdoc cref="IDateTimeFormatTemplates.YYYYMMDD_HHMMSS_Dashed"/>>
        public string ToString_YYYYMMDD_HHMMSS_Dash(DateTime dateTime)
        {
            var formatTemplate = Instances.DateTimeFormatTemplates.YYYYMMDD_HHMMSS_Dashed;

            var output = Instances.DateTimeOperator.Format(
                dateTime,
                formatTemplate);

            return output;
        }

        /// <summary>
		/// Example output: 20221014 15:12:01
		/// </summary>
        public string ToString_YYYYMMDD_HHMMSS_Coloned(DateTime dateTime)
        {
            var formatTemplate = Instances.DateTimeFormatTemplates.YYYYMMDD_HHMMSS_Coloned;

            var output = Instances.DateTimeOperator.Format(
                dateTime,
                formatTemplate);

            return output;
        }

        /// <summary>
		/// Example output: 20221014 151201
		/// </summary>
        public string ToString_YYYYMMDD_HHMMSS_Space(DateTime dateTime)
        {
            var formatTemplate = Instances.DateTimeFormatTemplates.YYYYMMDD_HHMMSS;

            var output = Instances.DateTimeOperator.Format(
                dateTime,
                formatTemplate);

            return output;
        }

        public DateTime Subtract_Days(DateTime dateTime, int days)
        {
            var timeSpan = Instances.TimeSpanOperator.From_Days(days);

            var output = dateTime.Subtract(timeSpan);
            return output;
        }

        public string ToString_MMM_DD_YYYY(DateTime dateTime)
        {
            var output = $"{dateTime:MMM dd, yyyy}";
            return output;
        }

        public string ToString_YYYY_MM_DD(DateTime dateTime)
        {
            var output = $"{dateTime:yyyy-MM-dd}";
            return output;
        }
    }
}
