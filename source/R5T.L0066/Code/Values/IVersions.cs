using System;

using R5T.T0131;


namespace R5T.L0066
{
    [ValuesMarker]
    public partial interface IVersions : IValuesMarker
    {
#pragma warning disable IDE1006 // Naming Styles
        public Raw.IVersions _Raw => Raw.Versions.Instance;
#pragma warning restore IDE1006 // Naming Styles


        /// <summary>
        /// The default version (for assuming when no version is present).
        /// <para><inheritdoc cref="Raw.IVersions._1_0_0" path="/summary"/></para>
        /// </summary>
        public Version Default => _Raw._1_0_0;

        /// <summary>
        /// The default initial version value.
        /// <para><inheritdoc cref="Raw.IVersions._0_0_1" path="/summary"/></para>
        /// </summary>
        public Version Initial_Default => _Raw._0_0_1;

        /// <summary>
        /// The none version is just null (since Version is a reference type).
        /// </summary>
        public Version None => null;
    }
}
