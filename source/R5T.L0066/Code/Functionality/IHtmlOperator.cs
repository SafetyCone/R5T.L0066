using System;
using System.Net;

using R5T.T0132;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface IHtmlOperator : IFunctionalityMarker
    {
        public string Decode(string html)
        {
            var output = WebUtility.HtmlDecode(html);
            return output;
        }

        public string Encode(string text)
        {
            var output = WebUtility.HtmlEncode(text);
            return output;
        }
    }
}
