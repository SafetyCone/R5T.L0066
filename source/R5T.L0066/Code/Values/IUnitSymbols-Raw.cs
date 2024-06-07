using System;

using R5T.T0131;


namespace R5T.L0066.Raw
{
    [ValuesMarker]
    public partial interface IUnitSymbols : IValuesMarker
    {
        /// <summary>
        /// <para><value>KB</value></para>
        /// </summary>
        public string KB => "KB";

        /// <summary>
        /// <para><value>MB</value></para>
        /// </summary>
        public string MB => "MB";

        /// <summary>
        /// <para><value>GB</value></para>
        /// </summary>
        public string GB => "GB";

        /// <summary>
        /// <para><value>GiB</value></para>
        /// </summary>
        public string GiB => "GiB";
    }
}
