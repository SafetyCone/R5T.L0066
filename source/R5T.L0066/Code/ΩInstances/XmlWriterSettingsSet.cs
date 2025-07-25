using System;


namespace R5T.L0066
{
    public class XmlWriterSettingsSet : IXmlWriterSettingsSet
    {
        #region Infrastructure

        public static IXmlWriterSettingsSet Instance { get; } = new XmlWriterSettingsSet();


        private XmlWriterSettingsSet()
        {
        }

        #endregion
    }
}
