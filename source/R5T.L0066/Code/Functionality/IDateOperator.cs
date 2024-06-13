using System;

using R5T.T0132;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface IDateOperator : IFunctionalityMarker
    {
        public DateTime Get_Day(DateTime now)
        {
            var output = new DateTime(
                now.Year,
                now.Month,
                now.Day);

            return output;
        }

        public DateTime Get_Today_Local()
        {
            var nowLocal = Instances.NowOperator.Get_Now_Local();

            var todayLocal = this.Get_Day(nowLocal);
            return todayLocal;
        }

        public DateTime Get_Today_Utc()
        {
            var nowUtc = Instances.NowOperator.Get_Now_Utc();

            var todayUtc = this.Get_Day(nowUtc);
            return todayUtc;
        }

        /// <summary>
        /// Chooses <see cref="Get_Today_Local"/> as the default.
        /// </summary>
        public DateTime Get_Today()
        {
            var today = this.Get_Today_Local();
            return today;
        }

        public string Get_YYYYMMDDFormatTemplate()
        {
            var yyyyMMddFormatTemplate = $"{{0:{Instances.DateTimeFormats.YYYYMMDD}}}";
            return yyyyMMddFormatTemplate;
        }

        public string ToString_YYYYMMDD(DateTime date)
        {
            var formatTemplate = this.Get_YYYYMMDDFormatTemplate();

            var output = Instances.DateTimeOperator.Format(
                date,
                formatTemplate);

            return output;
        }

        /// <summary>
        /// Chooses <see cref="ToString_YYYYMMDD_HHMMSS_Space(DateTime)"/> as the default.
        /// </summary>
        public string ToString_YYYYMMDD_HHMMSS(DateTime dateTime)
        {
            var output = this.ToString_YYYYMMDD_HHMMSS_Space(dateTime);
            return output;
        }

        public string ToString_YYYYMMDD_HHMMSS_Dash(DateTime dateTime)
        {
            var formatTemplate = Instances.DateTimeFormatTemplates.YYYYMMDD_HHMMSS_Dashed;

            var output = Instances.DateTimeOperator.Format(
                dateTime,
                formatTemplate);

            return output;
        }

        public string ToString_YYYYMMDD_HHMMSS_Space(DateTime dateTime)
        {
            var formatTemplate = Instances.DateTimeFormatTemplates.YYYYMMDD_HHMMSS;

            var output = Instances.DateTimeOperator.Format(
                dateTime,
                formatTemplate);

            return output;
        }
    }
}
