using System;

using R5T.T0132;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface IDateOperator : IFunctionalityMarker
    {
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
