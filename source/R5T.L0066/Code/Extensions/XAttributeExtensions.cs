using System;
using System.Collections.Generic;
using System.Xml.Linq;

using Instances = R5T.L0066.Instances;


namespace R5T.Extensions
{
    public static class XAttributeExtensions
    {
        public static IEnumerable<XAttribute> Where_NameIs(this IEnumerable<XAttribute> attributes,
            string attributeName)
        {
            return Instances.XAttributeOperator.Where_NameIs(
                attributes,
                attributeName);
        }
    }
}
