using System;

using R5T.T0131;


namespace R5T.L0066
{
    [ValuesMarker]
    public partial interface IValues : IValuesMarker
    {
        /// <summary>
        /// <para>true</para>
        /// By default, files are overwritten.
        /// </summary>
        public const bool Default_OverwriteValue_Const = true;

        /// <inheritdoc cref="Default_OverwriteValue_Const"/>
        public bool Default_OverwriteValue => Default_OverwriteValue_Const;
    }
}
