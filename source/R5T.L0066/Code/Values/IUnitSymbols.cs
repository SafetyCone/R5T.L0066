using System;

using R5T.T0131;


namespace R5T.L0066
{
    [ValuesMarker]
    public partial interface IUnitSymbols : IValuesMarker
    {
#pragma warning disable IDE1006 // Naming Styles
        public Raw.IUnitSymbols _Raw => Raw.UnitSymbols.Instance;
#pragma warning restore IDE1006 // Naming Styles


        /// <summary>
        /// 1024 * 1024 * 1024 (2^30)
        /// <inheritdoc cref="Raw.IUnitSymbols.GiB" path="descendant::value[1]"/>
        /// </summary>
        public string Gibibyte => _Raw.GiB;

        /// <summary>
        /// <inheritdoc cref="Raw.IUnitSymbols.GB" path="descendant::value[1]"/>
        /// </summary>
        public string Gigabyte => _Raw.GB;
    }
}
