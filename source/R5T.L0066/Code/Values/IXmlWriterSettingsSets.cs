using System;
using System.Xml;

using R5T.T0131;


namespace R5T.L0066
{
    [ValuesMarker]
    public partial interface IXmlWriterSettingsSets : IValuesMarker
    {
        /// <summary>
        /// Writes XML content exactly as-is, with no modifications.
        /// </summary>
        public XmlWriterSettings AsIs => new XmlWriterSettings
        {
            ConformanceLevel = ConformanceLevel.Fragment,
            Indent = false,
            OmitXmlDeclaration = true,
            NewLineHandling = NewLineHandling.None,
        };

        public XmlWriterSettings Indented => Instances.ObjectOperator.ModifyAndReturn(
            this.AsIs,
            writerSettings =>
            {
                writerSettings.Indent = true;
            });
    }
}
