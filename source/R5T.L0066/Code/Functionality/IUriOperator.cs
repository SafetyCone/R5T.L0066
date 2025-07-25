using System;

using R5T.T0132;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface IUriOperator : IFunctionalityMarker
    {
        public string Escape_DataString(string value)
        {
            var output = Uri.EscapeDataString( value);
            return output;
        }

        public Uri From(string uri)
        {
            var output = new Uri(uri);
            return output;
        }

        public Uri From(
            Uri baseUri,
            string relativeUri)
        {
            var output = new Uri(
                baseUri,
                relativeUri);

            return output;
        }

        public Uri From(
            string baseUri,
            string relativeUri)
        {
            var baseUriObject = this.From(baseUri);

            var output = this.From(
                baseUriObject,
                relativeUri);

            return output;
        }

        public Uri From_Path(string path)
        {
            var output = this.From(
                Instances.UriSchemes.File,
                path);

            return output;
        }

        public Uri Make_RelativeUri(
            Uri sourceUri,
            Uri destinationUri)
        {
            var output = sourceUri.MakeRelativeUri(destinationUri);
            return output;
        }

        public string To_String(Uri uri)
        {
            var output = uri.ToString();
            return output;
        }

        /// <summary>
        /// Quality-of-life overload of <see cref="From(string)"/>.
        /// </summary>
        public Uri To_Uri(string uriText)
            => this.From(uriText);

        public string UnescapeDataString(string uri)
        {
            var output = Uri.UnescapeDataString(uri);
            return output;
        }
    }
}
