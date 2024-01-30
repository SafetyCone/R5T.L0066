using System;

using R5T.T0131;


namespace R5T.L0066
{
    [ValuesMarker]
    public partial interface IFileExtensions : IValuesMarker
    {
        /// <summary>
        /// <para><value>dll</value></para>
        /// </summary>
        public string Dll => "dll";

        /// <summary>
        /// <para><value>txt</value></para>
        /// </summary>
        public string Text => "txt";

        /// <summary>
        /// <para><value>xml</value></para>
        /// </summary>
        public string Xml => "xml";
    }
}
