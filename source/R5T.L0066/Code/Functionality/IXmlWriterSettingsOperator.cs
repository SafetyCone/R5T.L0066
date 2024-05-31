using System;
using System.Text;
using System.Xml;

using R5T.T0132;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface IXmlWriterSettingsOperator : IFunctionalityMarker
    {
        /// <summary>
        /// Gets a simple indenting XML writer settings instance.
        /// </summary>
        public XmlWriterSettings GetIndent()
        {
            var xmlWriterSettings = new XmlWriterSettings
            {
                Indent = true,
            };
            return xmlWriterSettings;
        }

        /// <summary>
        /// The System XML writer includes an XML declaration by default, however this is often not desired.
        /// An XML writer can be created with settings specifying to omit the XML declaration, but other settings must be set to get the desired default behavior.
        /// This method produces XML writer settings that replicate the default settings, except specifying to omit the declaration.
        /// </summary>
        public XmlWriterSettings GetNoDeclaration_Synchronous()
        {
            var settings = new XmlWriterSettings
            {
                OmitXmlDeclaration = true,
            };

            return settings;
        }

        /// <inheritdoc cref="GetNoDeclaration_Synchronous()"/>
        public XmlWriterSettings GetNoDeclaration()
        {
            var settings = new XmlWriterSettings
            {
                Async = true,
                OmitXmlDeclaration = true,
            };

            return settings;
        }

        /// <summary>
        /// Gets the standard XML writer settings.
        /// </summary>
        public XmlWriterSettings GetStandardSettings_Synchronous()
        {
            var settings = this.GetNoDeclaration_Synchronous();

            settings.Encoding = new UTF8Encoding(false);
            settings.Indent = true;

            return settings;
        }

        /// <summary>
        /// Gets the standard XML writer settings.
        /// </summary>
        public XmlWriterSettings GetStandardSettings()
        {
            var settings = this.GetNoDeclaration();

            settings.Encoding = new UTF8Encoding(false);
            settings.Indent = true;

            return settings;
        }
    }
}
