using System;
using System.IO;
using System.Xml;

using R5T.T0132;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface IXmlWriterOperator : IFunctionalityMarker
    {
        /// <summary>
        /// Gets the standard XML writer.
        /// </summary>
        public XmlWriter New_Synchronous(Stream stream)
        {
            var settings = Instances.XmlWriterSettingsOperator.GetStandardSettings();

            var writer = XmlWriter.Create(stream, settings);
            return writer;
        }

        /// <inheritdoc cref="New_Synchronous(Stream)"/>
        public XmlWriter New(Stream stream)
        {
            var settings = Instances.XmlWriterSettingsOperator.GetStandardSettings();

            var writer = XmlWriter.Create(stream, settings);
            return writer;
        }
    }
}
