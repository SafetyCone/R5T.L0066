using System;
using System.IO;
using System.Net.Http;

using R5T.T0132;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface IHttpResponseMessageOperator : IFunctionalityMarker
    {
        /// <inheritdoc cref="IHttpRequestMessageOperator.Write_ToConsole(HttpRequestMessage)"/>
        public void Write_RequestOfResponse_ToConsole(HttpResponseMessage httpResponseMessage)
            => Instances.HttpRequestMessageOperator.Write_ToConsole(
                httpResponseMessage.RequestMessage);

        /// <inheritdoc cref="IHttpRequestMessageOperator.Write_ToTextWriter(HttpRequestMessage, TextWriter)"/>
        public void Write_RequestOfResponse_ToTextWriter(
            HttpResponseMessage httpResponseMessage,
            TextWriter textWriter)
            => Instances.HttpRequestMessageOperator.Write_ToTextWriter(
                httpResponseMessage.RequestMessage,
                textWriter);
    }
}