using System;
using System.IO;
using System.Net.Http;


namespace R5T.L0066.Extensions
{
    public static class HttpReponseMessageExtensions
    {
        /// <inheritdoc cref="IHttpResponseMessageOperator.Write_RequestOfResponse_ToConsole(HttpResponseMessage)"/>
        public static void Write_RequestOfResponse_ToConsole(this HttpResponseMessage httpResponseMessage)
            => Instances.HttpResponseMessageOperator.Write_RequestOfResponse_ToConsole(httpResponseMessage);

        /// <inheritdoc cref="IHttpResponseMessageOperator.Write_RequestOfResponse_ToConsole(HttpResponseMessage)"/>
        public static void Write_RequestOfResponse_ToTextWriter(this HttpResponseMessage httpResponseMessage,
            TextWriter textWriter)
            => Instances.HttpResponseMessageOperator.Write_RequestOfResponse_ToTextWriter(
                httpResponseMessage,
                textWriter);
    }
}
