using System;
using System.IO;
using System.Threading.Tasks;
using System.Xml.Linq;

using R5T.T0132;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface IXmlOperator : IFunctionalityMarker
    {
        /// <summary>
        /// Chooses <see cref="Load_XDocument_Synchronous(string)"/> as the default.
        /// </summary>
        public XDocument Load_Synchronous(string xmlFilePath)
        {
            var xDocument = this.Load_XDocument_Synchronous(xmlFilePath);
            return xDocument;
        }

        public XDocument Load_XDocument_Synchronous(string xmlFilePath)
        {
            var output = Instances.XDocumentOperator.Load_Synchronous(xmlFilePath);
            return output;
        }

        public XElement New_Element(string elementName)
        {
            var output = Instances.XElementOperator.New(elementName);
            return output;
        }

        /// <inheritdoc cref="IXmlTextOperator.StandardizeNewLines(string)"/>
        public string StandardizeNewLines(string xmlText)
        {
            var output = Instances.XmlTextOperator.StandardizeNewLines(xmlText);
            return output;
        }

        /// <summary>
		/// Chooses <see cref="WriteToFile_EmptyIsOk_Synchronous(XDocument, string, SaveOptions)"/> as the default.
		/// </summary>
		public void Write(
            XDocument document,
            string xmlFilePath)
            => this.WriteToFile_EmptyIsOk_Synchronous(
                document,
                xmlFilePath);

        /// <inheritdoc cref="IXDocumentOperator.To_File_EmptyIsOk(XDocument, string, SaveOptions)"/>
        public Task WriteToFile_EmptyIsOk(
            XDocument document,
            string xmlFilePath,
            SaveOptions saveOptions = SaveOptions.None)
            => Instances.XDocumentOperator.To_File_EmptyIsOk(
                document,
                xmlFilePath,
                saveOptions);

        /// <inheritdoc cref="WriteToFile_EmptyIsOk(XDocument, string, SaveOptions)"/>
        public void WriteToFile_EmptyIsOk_Synchronous(
            XDocument document,
            string xmlFilePath,
            SaveOptions saveOptions = SaveOptions.None)
            => Instances.XDocumentOperator.To_File_EmptyIsOk_Synchronous(
                document,
                xmlFilePath,
                saveOptions);

        /// <inheritdoc cref="WriteToFile_EmptyIsOk(XDocument, string, SaveOptions)"/>
        public Task WriteToWriter_EmptyIsOk(
            XDocument document,
            TextWriter writer,
            SaveOptions saveOptions = SaveOptions.None)
            => Instances.XDocumentOperator.To_Writer_EmptyIsOk(
                document,
                writer,
                saveOptions);

        /// <inheritdoc cref="WriteToFile_EmptyIsOk(XDocument, string, SaveOptions)"/>
        public void WriteToWriter_EmptyIsOk_Synchronous(
            XDocument document,
            TextWriter writer,
            SaveOptions saveOptions = SaveOptions.None)
            => Instances.XDocumentOperator.To_Writer_EmptyIsOk_Synchronous(
                document,
                writer,
                saveOptions);

        public string WriteToString_Synchronous(
            XDocument document,
            SaveOptions saveOptions = SaveOptions.None)
            => Instances.XDocumentOperator.To_String(
                document,
                saveOptions);
    }
}
