using System;
using System.Globalization;

using R5T.T0132;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface IDateTimeOperator : IFunctionalityMarker
    {
        public string Format(
            DateTime dateTime,
            string formatTemplate)
        {
            var output = Instances.StringOperator.Format(
                formatTemplate,
                dateTime);

            return output;
        }

        public DateTime From_YYYYMMDD(string YYYYMMDD)
        {
            var output = DateTime.ParseExact(YYYYMMDD, "yyyyMMdd", CultureInfo.InvariantCulture);
            return output;
        }

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

        /// <summary>
		/// Chooses <see cref="Get_Now_Local"/> as the default.
		/// </summary>
		public DateTime Get_Now()
        {
            var output = this.Get_Now_Local();
            return output;
        }

        public DateTime Get_Now_Local()
        {
            var output = DateTime.Now;
            return output;
        }

        public DateTime Get_Now_Utc()
        {
            var output = DateTime.UtcNow;
            return output;
        }

        public int Get_Year(DateTime dateTime)
        {
            var output = dateTime.Year;
            return output;
        }

        public DateTime Get_Zero()
            => new DateTime();

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
