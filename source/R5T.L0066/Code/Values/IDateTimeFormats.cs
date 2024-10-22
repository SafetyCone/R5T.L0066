using System;

using R5T.T0131;


namespace R5T.L0066
{
    [ValuesMarker]
    public partial interface IDateTimeFormats : IValuesMarker
    {
        /// <summary>
        /// <para><value>yyyyMMdd</value></para>
        /// </summary>
        public string YYYYMMDD => "yyyyMMdd";

        /// <summary>
        /// <para><value>yyyyMMdd HHmmss</value></para>
        /// </summary>
        public string YYYYMMDD_HHMMSS => "yyyyMMdd HHmmss";

        /// <summary>
        /// <para><value>yyyyMMdd-HH:mm:ss</value></para>
        /// </summary>
        public string YYYYMMDD_HHMMSS_Coloned => "yyyyMMdd-HH:mm:ss";

        /// <summary>
        /// <para><value>yyyyMMdd-HHmmss</value></para>
        /// </summary>
        public string YYYYMMDD_HHMMSS_Dashed => "yyyyMMdd-HHmmss";

        /// <summary>
        /// <para><value>yyyy-MM-dd</value></para>
        /// <para><description>YYYY-MM-DD</description></para>
        /// </summary>
        public string YYYY_MM_DD_Dashed => "yyyy-MM-dd";
    }
}
