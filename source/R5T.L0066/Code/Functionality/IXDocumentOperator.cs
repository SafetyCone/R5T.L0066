using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.XPath;

using R5T.L0066.Extensions;
using R5T.T0132;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface IXDocumentOperator : IFunctionalityMarker
    {
        public async Task<Dictionary<string, XDocument>> Load(IEnumerable<string> xmlFilePaths)
        {
            var documents_ByXmlFilePath = new ConcurrentDictionary<string, XDocument>();

            var loadTasks = new List<Task>();

            async Task Internal(string xmlFilePath)
            {
                var document = await this.Load(xmlFilePath);

                documents_ByXmlFilePath.TryAdd(
                    xmlFilePath,
                    document);
            }

            foreach (var xmlFilePath in xmlFilePaths)
            {
                var loadTask = Internal(xmlFilePath);

                loadTasks.Add(loadTask);
            }

            await Task.WhenAll(loadTasks);

            var output = documents_ByXmlFilePath.Clone();
            return output;
        }

        /// <summary>
        /// Gets the standard load options, which is <see cref="LoadOptions.None"/>.
        /// </summary>
        /// <remarks>
        /// Do not preserve insignificant whitespace.
        /// Other options seem too esoteric to consider.
        /// </remarks>
        public LoadOptions Get_LoadOptions_Standard()
        {
            return LoadOptions.None;
        }

        /// <summary>
        /// Gets the root element of the document, or default if it does not exist.
        /// </summary>
        public XElement Get_Root_OrDefault(XDocument document)
            => document.Root;

        /// <summary>
        /// Gets the root element of the given document,
        /// throwing an exception if the document does not have a root element.
        /// </summary>
        public XElement Get_Root(XDocument document)
        {
            var hasRoot = this.Has_Root(
                document,
                out var root_OrDefault);

            if(!hasRoot)
            {
                throw new Exception("XML document did not have a root.");
            }

            return root_OrDefault;
        }

        /// <summary>
        /// Gets the root element of the given document,
        /// verifying that the root element exists and has the given name.
        /// </summary>
        public XElement Get_Root(
            XDocument document,
            string rootName)
        {
            var rootElement = this.Get_Root(document);

            Instances.XElementOperator.Verify_NameIs(
                rootElement,
                rootName);

            return rootElement;
        }

        public bool Has_Root(
            XDocument document,
            out XElement root_OrDefault)
        {
            root_OrDefault = this.Get_Root_OrDefault(document);

            var output = Instances.NullOperator.Is_NotNull(root_OrDefault);
            return output;
        }

        public XDocument Load_Synchronous(string filePath)
        {
            var loadOptions = this.Get_LoadOptions_Standard();

            var xDocument = XDocument.Load(
                filePath,
                loadOptions);

            return xDocument;
        }

        public Task<XDocument> Load(string filePath)
        {
            var loadOptions = this.Get_LoadOptions_Standard();

            return this.Load(
                filePath,
                loadOptions);
        }

        public async Task<XDocument> Load(
            string filePath,
            LoadOptions loadOptions)
        {
            using var fileStream = Instances.FileStreamOperator.Open_Read(filePath);

            var xDocument = await XDocument.LoadAsync(
                fileStream,
                loadOptions,
                Instances.CancellationTokens.None);

            return xDocument;
        }

        /// <inheritdoc cref="Parse_WithoutTrimStart(string)"/>
        public XDocument Parse_WithoutTrimStart(
            string xmlText,
            LoadOptions loadOptions)
            => XDocument.Parse(
                xmlText,
                loadOptions);

        /// <summary>
        /// If the XML text contains a processing instruction, the <see cref="XDocument.Parse(string)"/> method requires there to be no whitespace before the processing instruction.
        /// This is annoying, and so <see cref="Parse_WithTrimStart(string)"/> fixes this annoyance.
        /// But this method provides direct access to the annoying underlying method.
        /// </summary>
        public XDocument Parse_WithoutTrimStart(
            string xmlText)
            => XDocument.Parse(
                xmlText);

        /// <inheritdoc cref="Parse_WithTrimStart(string)"/>
        public XDocument Parse_WithTrimStart(
            string xmlText,
            LoadOptions loadOptions)
        {
            var trimmedXmlText = xmlText.TrimStart();

            var output = this.Parse_WithoutTrimStart(
                trimmedXmlText,
                loadOptions);

            return output;
        }

        /// <summary>
        /// If the XML text contains a processing instruction, the <see cref="XDocument.Parse(string)"/> method requires there to be no whitespace before the processing instruction.
        /// This is annoying, and so and this method is a fix for that.
        /// However, <see cref="Parse_WithoutTrimStart(string)"/> provides direct access to the annoying underlying method.
        /// </summary>
        public XDocument Parse_WithTrimStart(string xmlText)
        {
            var trimmedXmlText = xmlText.TrimStart();

            var output = this.Parse_WithoutTrimStart(trimmedXmlText);
            return output;
        }

        /// <summary>
        /// Chooses <see cref="Parse_WithTrimStart(string, LoadOptions)"/> as the default.
        /// </summary>
        public XDocument Parse(
            string xmlText,
            LoadOptions loadOptions)
            => this.Parse_WithTrimStart(
                xmlText,
                loadOptions);

        /// <summary>
        /// Chooses <see cref="Parse_WithTrimStart(string)"/> as the default.
        /// </summary>
        public XDocument Parse(string xmlText)
            => this.Parse_WithTrimStart(xmlText);

        public XDocument Parse_AsIs(string xmlText)
            => this.Parse(
                xmlText,
                LoadOptions.PreserveWhitespace);

        /// <summary>
        /// Quality-of-life overload for <see cref="To_File_EmptyIsOk(XDocument, string, SaveOptions)"/>.
        /// </summary>
        public Task Save_EmptyIsOk(
            string xmlFilePath,
            XDocument document,
            SaveOptions saveOptions = SaveOptions.None)
            => this.To_File_EmptyIsOk(
                document,
                xmlFilePath,
                saveOptions);

        /// <summary>
        /// Quality-of-life overload for <see cref="To_File_EmptyIsOk_Synchronous(XDocument, string, SaveOptions)"/>.
        /// </summary>
        public void Save_EmptyIsOk_Synchronous(
            string xmlFilePath,
            XDocument document,
            SaveOptions saveOptions = SaveOptions.None)
            => this.To_File_EmptyIsOk_Synchronous(
                document,
                xmlFilePath,
                saveOptions);

        public async Task Save_NonEmpty(
            string xmlFilePath,
            XDocument document,
            SaveOptions saveOptions = SaveOptions.None)
        {
            using var fileStream = Instances.FileStreamOperator.Open_Write(xmlFilePath);
            using var writer = new StreamWriter(fileStream);

            await this.Save_NonEmpty(
                document,
                writer,
                saveOptions);
        }

        public Task Save_NonEmpty(
            XDocument document,
            TextWriter writer,
            SaveOptions saveOptions = SaveOptions.None)
            => document.SaveAsync(
                writer,
                saveOptions,
                Instances.CancellationTokens.None);

        public void Save_NonEmpty_Synchronous(
            string xmlFilePath,
            XDocument document,
            SaveOptions saveOptions = SaveOptions.None)
            => document.Save(
                xmlFilePath,
                saveOptions);

        /// <summary>
        /// Chooses <see cref="Save(string, XDocument, SaveOptions)"/> as the default.
        /// </summary>
        public Task Save(
            string xmlFilePath,
            XDocument document,
            SaveOptions saveOptions = SaveOptions.None)
            => this.Save_EmptyIsOk(
                xmlFilePath,
                document,
                saveOptions);

        /// <summary>
        /// Chooses <see cref="Save_EmptyIsOk(string, XDocument, SaveOptions)"/> as the default.
        /// </summary>
        public void Save_Synchronous(
            string xmlFilePath,
            XDocument document,
            SaveOptions saveOptions = SaveOptions.None)
            => this.Save_EmptyIsOk_Synchronous(
                xmlFilePath,
                document,
                saveOptions);

        public XElement SelectElement_ByXPath(
            XDocument document,
            string xPath)
            => document.XPathSelectElement(xPath);

        public IEnumerable<XElement> SelectElements_ByXPath(
            XDocument document,
            string xPath)
            => document.XPathSelectElements(xPath);

        /// <summary>
        /// XML files *must* have a root: https://www.w3schools.com/xml/xml_syntax.asp
        /// So if the document has no root, saving the document results in an <see cref="InvalidOperationException"/>: Token EndDocument in state Document would result in an invalid XML document.
        /// This method will allow writing an empty document.
        /// If the document has no root, just the declaration is written.
        /// If the document also has no declaration, nothing is written.
        /// </summary>
        public async Task To_File_EmptyIsOk(
            XDocument document,
            string xmlFilePath,
            SaveOptions saveOptions = SaveOptions.None)
        {
            using var fileStream = Instances.FileStreamOperator.Open_Write(xmlFilePath);
            using var writer = new StreamWriter(fileStream);

            await this.To_Writer_EmptyIsOk(
                document,
                writer,
                saveOptions);
        }

        /// <inheritdoc cref="To_File_EmptyIsOk(XDocument, string, SaveOptions)"/>
        public void To_File_EmptyIsOk_Synchronous(
            XDocument document,
            string xmlFilePath,
            SaveOptions saveOptions = SaveOptions.None)
        {
            if (document.Root is null)
            {
                if (document.Declaration is null)
                {
                    Instances.FileOperator.WriteAnEmptyFile_Synchronous(xmlFilePath);
                }
                else
                {
                    var text = document.Declaration.ToString();

                    Instances.FileOperator.Write_Text_Synchronous(
                        xmlFilePath,
                        text);
                }
            }
            else
            {
                document.Save(
                    xmlFilePath,
                    saveOptions);
            }
        }

        /// <summary>
        /// Quality-of-life overload for <see cref="Save_NonEmpty(string, XDocument, SaveOptions)"/>.
        /// </summary>
        public Task To_File_NonEmpty(
            XDocument document,
            string xmlFilePath,
            SaveOptions saveOptions = SaveOptions.None)
            => this.Save_NonEmpty(
                xmlFilePath,
                document,
                saveOptions);

        /// <summary>
        /// Quality-of-life overload for <see cref="Save_NonEmpty_Synchronous(string, XDocument, SaveOptions)"/>.
        /// </summary>
        public void To_File_NonEmpty_Synchronous(
            XDocument document,
            string xmlFilePath,
            SaveOptions saveOptions = SaveOptions.None)
            => this.Save_NonEmpty_Synchronous(
                xmlFilePath,
                document,
                saveOptions);

        /// <summary>
        /// Chooses <see cref="To_File_EmptyIsOk(XDocument, string, SaveOptions)"/> as the default.
        /// </summary>
        public Task To_File(
            XDocument document,
            string xmlFilePath,
            SaveOptions saveOptions = SaveOptions.None)
            => this.To_File_EmptyIsOk(
                document,
                xmlFilePath,
                saveOptions);

        /// <summary>
        /// Chooses <see cref="To_File_EmptyIsOk_Synchronous(XDocument, string, SaveOptions)"/> as the default.
        /// </summary>
        public void To_File_Synchronous(
            XDocument document,
            string xmlFilePath,
            SaveOptions saveOptions = SaveOptions.None)
            => this.To_File_EmptyIsOk_Synchronous(
                document,
                xmlFilePath,
                saveOptions);

        public string To_String(
            XDocument document,
            SaveOptions saveOptions = SaveOptions.None)
        {
            var stringBuilder = new StringBuilder();
            var writer = new StringWriter(stringBuilder);

            this.To_Writer_EmptyIsOk_Synchronous(
                document,
                writer,
                saveOptions);

            var output = stringBuilder.ToString();
            return output;
        }

        /// <summary>
        /// Quality-of-life overload for <see cref="To_String(XDocument, SaveOptions)"/>.
        /// </summary>
        public string To_Text(
            XDocument document,
            SaveOptions saveOptions = SaveOptions.None)
            => this.To_String(
                document,
                saveOptions);

        /// <inheritdoc cref="To_File_EmptyIsOk(XDocument, string, SaveOptions)"/>
        public async Task To_Writer_EmptyIsOk(
            XDocument document,
            TextWriter writer,
            SaveOptions saveOptions = SaveOptions.None)
        {
            if (document.Root is null)
            {
                if (document.Declaration is null)
                {
                    await writer.WriteAsync(Instances.Strings.Empty);
                }
                else
                {
                    var text = document.Declaration.ToString();

                    await writer.WriteAsync(text);
                }
            }
            else
            {
                await document.SaveAsync(
                    writer,
                    saveOptions,
                    CancellationToken.None);
            }
        }

        /// <inheritdoc cref="To_File_EmptyIsOk(XDocument, string, SaveOptions)"/>
        public void To_Writer_EmptyIsOk_Synchronous(
            XDocument document,
            TextWriter writer,
            SaveOptions saveOptions = SaveOptions.None)
        {
            if (document.Root is null)
            {
                if (document.Declaration is null)
                {
                    writer.Write(Instances.Strings.Empty);
                }
                else
                {
                    var text = document.Declaration.ToString();

                    writer.Write(text);
                }
            }
            else
            {
                document.Save(
                    writer,
                    saveOptions);
            }
        }

        public Task To_Writer_NonEmpty(
            XDocument document,
            TextWriter writer,
            SaveOptions saveOptions = SaveOptions.None)
            => document.SaveAsync(
                writer,
                saveOptions,
                Instances.CancellationTokens.None);

        public void To_Writer_NonEmpty_Synchronous(
            XDocument document,
            TextWriter writer,
            SaveOptions saveOptions = SaveOptions.None)
            => document.Save(
                writer,
                saveOptions);

        /// <summary>
        /// Chooses <see cref="To_Writer_EmptyIsOk(XDocument, TextWriter, SaveOptions)"/> as the default.
        /// </summary>
        public Task To_Writer(
            XDocument document,
            TextWriter writer,
            SaveOptions saveOptions = SaveOptions.None)
            => this.To_Writer_EmptyIsOk(
                document,
                writer,
                saveOptions);

        /// <summary>
        /// Chooses <see cref="To_Writer_EmptyIsOk_Synchronous(XDocument, TextWriter, SaveOptions)"/> as the default.
        /// </summary>
        public void To_Writer_Synchronous(
            XDocument document,
            TextWriter writer,
            SaveOptions saveOptions = SaveOptions.None)
            => this.To_Writer_EmptyIsOk_Synchronous(
                document,
                writer,
                saveOptions);
    }
}
