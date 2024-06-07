using System;

using R5T.T0131;


namespace R5T.L0066.Raw
{
    [ValuesMarker]
    public partial interface IUnitNames : IValuesMarker
    {
#pragma warning disable IDE1006 // Naming Styles

        /// <summary>
        /// <para><value>kilobyte</value></para>
        /// </summary>
        public string kilobyte => "kilobyte";

        /// <summary>
        /// <para><value>megabyte</value></para>
        /// </summary>
        public string megabyte => "megabyte";

        /// <summary>
        /// <para><value>gigabyte</value></para>
        /// </summary>
        public string gigabyte => "gigabyte";

#pragma warning restore IDE1006 // Naming Styles
    }
}
