using System;
using System.Xml;

using F10Y.T0011;

using R5T.T0131;


namespace R5T.L0066
{
    [ValuesMarker]
    public partial interface IXmlWriterSettingsSet : IValuesMarker,
        F10Y.L0000.IXmlWriterSettingsSet
    {
#pragma warning disable IDE1006 // Naming Styles

        [Ignore]
        F10Y.L0000.IXmlWriterSettingsSet _F10Y_L0000 => F10Y.L0000.XmlWriterSettingsSet.Instance;

#pragma warning restore IDE1006 // Naming Styles


        /// <summary>
        /// Writes XML content exactly as-is, with no modifications.
        /// </summary>
        XmlWriterSettings AsIs => new XmlWriterSettings
        {
            ConformanceLevel = ConformanceLevel.Fragment,
            //Indent = false,
            //OmitXmlDeclaration = true,
            NewLineHandling = NewLineHandling.None,
        };

        XmlWriterSettings Indented => Instances.ObjectOperator.ModifyAndReturn(
            this.AsIs,
            writerSettings =>
            {
                writerSettings.Indent = true;
            });
    }
}
