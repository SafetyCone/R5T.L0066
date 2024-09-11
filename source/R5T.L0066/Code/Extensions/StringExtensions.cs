using System;
using System.Collections.Generic;

using Instances = R5T.L0066.Instances;


namespace System.Linq
{
    public static class StringExtensions
    {
        public static IEnumerable<string> OrderAlphabetically(this IEnumerable<string> strings)
        {
            var output = Instances.StringOperator.Order_Alphabetically(strings);
            return output;
        }

        public static IEnumerable<string> OrderAlphabetically_OnlyIfDebug(this IEnumerable<string> strings)
        {
            var output = Instances.StringOperator.Order_Alphabetically_OnlyIfDebug(strings);
            return output;
        }

        /// <inheritdoc cref="R5T.L0066.IStringOperator.Trim(string)"/>
        public static IEnumerable<string> Trim(this IEnumerable<string> strings)
        {
            var output = Instances.StringOperator.Trim(strings);
            return output;
        }

        public static string Join_Lines(this IEnumerable<string> strings)
            => Instances.TextOperator.Join_Lines(strings);
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


namespace R5T.L0066.Extensions
{
    public static class StringExtensions
    {
        public static char Get_Character_First(this string @string)
            => Instances.StringOperator.Get_Character_First(@string);

        public static char Get_Character_Last(this string @string)
            => Instances.StringOperator.Get_Character_Last(@string);

        public static char Get_Character_Last(this string @string,
            int indexOfLast)
            => Instances.StringOperator.Get_Character_Last(
                @string,
                indexOfLast);

        public static string Join_ToString(this IEnumerable<string> strings)
            => Instances.StringOperator.Join_ToString(strings);

        public static string Join_ToString(this string[] strings)
            => Instances.StringOperator.Join_ToString(strings);
    }
}
