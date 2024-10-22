using System;

using R5T.T0131;


namespace R5T.L0066
{
    [ValuesMarker]
    public partial interface ISpecialDirectoryNames : IValuesMarker
    {
#pragma warning disable IDE1006 // Naming Styles

        /// <summary>
        /// <para><value>%USERPROFILE%</value></para>
        /// </summary>
        public string _USERPROFILE_ => "%USERPROFILE%";

#pragma warning restore IDE1006 // Naming Styles
    }
}
