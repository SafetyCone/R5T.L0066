using System;

using Instances = R5T.L0066.Instances;


namespace R5T.Extensions.Xml
{
    public static class StringExtensions
    {
        /// <inheritdoc cref="L0066.IXmlTextOperator.StandardizeNewLines(string)"/>
        public static string StandardizeNewLines(this string xmlText)
        {
            var output = Instances.XmlTextOperator.StandardizeNewLines(xmlText);
            return output;
        }
    }
}
