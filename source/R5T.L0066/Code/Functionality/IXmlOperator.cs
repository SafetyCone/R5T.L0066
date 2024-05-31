using System;
using System.IO;
using System.Text;
using System.Threading;
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
		/// Chooses <see cref="WriteToFile_EmptyIsOk(XDocument, string, SaveOptions)"/> as the default.
		/// </summary>
		public void Write(
            XDocument xDocument,
            string xmlFilePath)
        {
            this.WriteToFile_EmptyIsOk_Synchronous(
                xDocument,
                xmlFilePath);
        }

        /// <summary>
        /// XML files *must* have a root: https://www.w3schools.com/xml/xml_syntax.asp
        /// So if the document has no root, saving the document results in an <see cref="InvalidOperationException"/>: Token EndDocument in state Document would result in an invalid XML document.
        /// This method will allow writing an empty document.
        /// If the document has no root, just the declaration is written.
        /// If the document also has no declaration, nothing is written.
        /// </summary>
        public async Task WriteToFile_EmptyIsOk(
            XDocument xDocument,
            string xmlFilePath,
            SaveOptions saveOptions = SaveOptions.None)
        {
            using var fileStream = Instances.FileStreamOperator.Open_Write(xmlFilePath);
            using var writer = new StreamWriter(fileStream);

            await this.WriteToWriter_EmptyIsOk(
                xDocument,
                writer,
                saveOptions);
        }

        /// <inheritdoc cref="WriteToFile_EmptyIsOk(XDocument, string, SaveOptions)"/>
        public void WriteToFile_EmptyIsOk_Synchronous(
            XDocument xDocument,
            string xmlFilePath,
            SaveOptions saveOptions = SaveOptions.None)
        {
            if (xDocument.Root is null)
            {
                if (xDocument.Declaration is null)
                {
                    Instances.FileOperator.WriteAnEmptyFile_Synchronous(xmlFilePath);
                }
                else
                {
                    var text = xDocument.Declaration.ToString();

                    Instances.FileOperator.Write_Text_Synchronous(
                        xmlFilePath,
                        text);
                }
            }
            else
            {
                xDocument.Save(
                    xmlFilePath,
                    saveOptions);
            }
        }

        /// <inheritdoc cref="WriteToFile_EmptyIsOk(XDocument, string, SaveOptions)"/>
        public async Task WriteToWriter_EmptyIsOk(
            XDocument xDocument,
            TextWriter writer,
            SaveOptions saveOptions = SaveOptions.None)
        {
            if (xDocument.Root is null)
            {
                if (xDocument.Declaration is null)
                {
                    await writer.WriteAsync(Instances.Strings.Empty);
                }
                else
                {
                    var text = xDocument.Declaration.ToString();

                    await writer.WriteAsync(text);
                }
            }
            else
            {
                await xDocument.SaveAsync(
                    writer,
                    saveOptions,
                    CancellationToken.None);
            }
        }

        /// <inheritdoc cref="WriteToFile_EmptyIsOk(XDocument, string, SaveOptions)"/>
        public void WriteToWriter_EmptyIsOk_Synchronous(
            XDocument xDocument,
            TextWriter writer,
            SaveOptions saveOptions = SaveOptions.None)
        {
            if (xDocument.Root is null)
            {
                if (xDocument.Declaration is null)
                {
                    writer.Write(Instances.Strings.Empty);
                }
                else
                {
                    var text = xDocument.Declaration.ToString();

                    writer.Write(text);
                }
            }
            else
            {
                xDocument.Save(
                    writer,
                    saveOptions);
            }
        }

        public string WriteToString_Synchronous(
            XDocument xDocument,
            SaveOptions saveOptions = SaveOptions.None)
        {
            var stringBuilder = new StringBuilder();
            var writer = new StringWriter(stringBuilder);

            this.WriteToWriter_EmptyIsOk_Synchronous(
                xDocument,
                writer,
                saveOptions);

            var output = stringBuilder.ToString();
            return output;
        }
    }
}
