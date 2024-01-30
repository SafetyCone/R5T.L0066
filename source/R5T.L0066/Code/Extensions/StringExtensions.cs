using System;
using System.Collections.Generic;

using Instances = R5T.L0066.Instances;


namespace System.Linq
{
    public static class StringExtensions
    {
        /// <inheritdoc cref="R5T.L0066.IStringOperator.Trim(string)"/>
        public static IEnumerable<string> Trim(this IEnumerable<string> strings)
        {
            var output = Instances.StringOperator.Trim(strings);
            return output;
        }
    }
}

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
