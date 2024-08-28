using System;

using R5T.T0131;


namespace R5T.L0066.Raw
{
    [ValuesMarker]
    public partial interface IFormatStrings : IValuesMarker
    {
        /// <summary>
        /// <para><value>F4</value></para>
        /// Four decimal places.
        /// </summary>
        public string F4 => "F4";
    }
}
