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
    using System.Linq;


    public static class StringExtensions
    {
        public static IEnumerable<string> Append_BlankLine(this IEnumerable<string> lines)
            => Instances.StringOperator.Append_BlankLine(lines);

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

        public static IEnumerable<IEnumerable<string>> OrderBy_First(this IEnumerable<IEnumerable<string>> values)
            => Instances.StringOperator.OrderBy_First(values);

        public static IEnumerable<string> Separate_Lines(this IEnumerable<string> lines)
            => Instances.StringOperator.Separate_Lines(lines);

        public static IEnumerable<string> SeparateMany_Lines(this IEnumerable<IEnumerable<string>> values)
            => Instances.StringOperator.SeparateMany_Lines(values);

        public static IEnumerable<string> SeparateMany_Lines<T>(this IEnumerable<T> values,
            Func<T, IEnumerable<string>> selector)
            => Instances.StringOperator.SeparateMany_Lines(
                values,
                selector);
    }
}
