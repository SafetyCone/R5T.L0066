using System;

using R5T.T0131;


namespace R5T.L0066
{
    [ValuesMarker]
    public partial interface IFileExtensions : IValuesMarker
    {
#pragma warning disable IDE1006 // Naming Styles
        public Raw.IFileExtensions _Raw => Raw.FileExtensions.Instance;
#pragma warning restore IDE1006 // Naming Styles


        /// <inheritdoc cref="Raw.IFileExtensions.exe"/>
        public string Executable => _Raw.exe;

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
