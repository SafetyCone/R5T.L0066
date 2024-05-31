using System;

using R5T.T0131;


namespace R5T.L0066
{
    [ValuesMarker]
    public partial interface IEnvironmentVariableNames : IValuesMarker
    {
        /// <summary>
        /// <para><value>Path</value></para>
        /// </summary>
        public string Path => "Path";
    }
}
