using System;

using R5T.T0131;


namespace R5T.L0066
{
    [ValuesMarker]
    public partial interface IDateTimeFormats : IValuesMarker
    {
        public string YYYYMMDD => "yyyyMMdd";
        public string YYYYMMDD_HHMMSS => "yyyyMMdd HHmmss";
        public string YYYYMMDD_HHMMSS_Dashed => "yyyyMMdd-HHmmss";
        public string YYYY_MM_DD_Dashed => "yyyy-MM-dd";
    }
}
