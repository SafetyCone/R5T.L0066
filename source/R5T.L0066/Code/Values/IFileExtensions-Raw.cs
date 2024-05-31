using System;

using R5T.T0131;


namespace R5T.L0066.Raw
{
    [ValuesMarker]
    public partial interface IFileExtensions : IValuesMarker
    {
#pragma warning disable IDE1006 // Naming Styles

        /// <summary>
        /// <para><value>exe</value></para>
        /// </summary>
        public string exe => "exe";

        /// <summary>
        /// <para><value>dll</value></para>
        /// </summary>
        public string dll => "dll";

        /// <summary>
        /// <para><value>txt</value></para>
        /// </summary>
        public string txt => "txt";

        /// <summary>
        /// <para><value>xml</value></para>
        /// </summary>
        public string xml => "xml";

#pragma warning restore IDE1006 // Naming Styles
    }
}
