using System;

using R5T.T0131;


namespace R5T.L0066
{
    [ValuesMarker]
    public partial interface IDateTimeFormatTemplates : IValuesMarker
    {
        /// <inheritdoc cref="IDateTimeFormats.YYYYMMDD"/>
        public string YYYYMMDD => $"{{0:{Instances.DateTimeFormats.YYYYMMDD}}}";

        /// <inheritdoc cref="IDateTimeFormats.YYYYMMDD_HHMMSS"/>
        public string YYYYMMDD_HHMMSS => $"{{0:{Instances.DateTimeFormats.YYYYMMDD_HHMMSS}}}";

        /// <inheritdoc cref="IDateTimeFormats.YYYYMMDD_HHMMSS_Dashed"/>
        public string YYYYMMDD_HHMMSS_Coloned => $"{{0:{Instances.DateTimeFormats.YYYYMMDD_HHMMSS_Coloned}}}";

        /// <inheritdoc cref="IDateTimeFormats.YYYYMMDD_HHMMSS_Dashed"/>
        public string YYYYMMDD_HHMMSS_Dashed => $"{{0:{Instances.DateTimeFormats.YYYYMMDD_HHMMSS_Dashed}}}";
    }
}
