using System;
using System.Threading.Tasks;
using System.Xml.Linq;

using R5T.T0132;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface IXDocumentOperator : IFunctionalityMarker
    {
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
    }
}
