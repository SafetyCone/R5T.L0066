using System;
using System.IO;
using System.Net.Http;

using R5T.T0132;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface IHttpRequestMessageOperator : IFunctionalityMarker
    {
        /// <inheritdoc cref="Write_ToTextWriter(HttpRequestMessage, TextWriter)"/>
        public void Write_ToConsole(HttpRequestMessage httpRequestMessage)
        {
            var textWriter = Console.Out;

            this.Write_ToTextWriter(
                httpRequestMessage,
                textWriter);
        }

        /// <inheritdoc cref="Write_ToText(HttpRequestMessage)"/>
        public void Write_ToTextWriter(HttpRequestMessage httpRequestMessage,
            TextWriter textWriter)
        {
            var line = this.Write_ToText(httpRequestMessage);

            textWriter.WriteLine(line);
        }

        /// <summary>
        /// Outputs: <output>{HTTP Method} {Request URI} HTTP/{HTTP Version}</output>
        /// </summary>
        public string Write_ToText(HttpRequestMessage httpRequestMessage)
        {
            var method = httpRequestMessage.Method;
            var requestUri = httpRequestMessage.RequestUri;
            var version = httpRequestMessage.Version;

            var line = $"{method} {requestUri} HTTP/{version}";

            return line;
        }
    }
}
