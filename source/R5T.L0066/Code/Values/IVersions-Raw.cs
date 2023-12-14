using System;

using R5T.T0131;


namespace R5T.L0066.Raw
{
    [ValuesMarker]
    public partial interface IVersions : IValuesMarker
    {
//#pragma warning disable IDE1006 // Naming Styles

        /// <summary>
        /// "1.0.0"
        /// </summary>
        public Version _1_0_0 => new Version(1, 0, 0);

        /// <summary>
        /// "0.0.1"
        /// </summary>
        public Version _0_0_1 => new Version(0, 0, 1);

//#pragma warning restore IDE1006 // Naming Styles
    }
}
