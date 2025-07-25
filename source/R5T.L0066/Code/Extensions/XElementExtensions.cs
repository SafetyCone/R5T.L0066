using System;
using System.Collections.Generic;
using System.Xml.Linq;

using IXElementOperator_Common = F10Y.L0000.IXElementOperator;

using Instances = R5T.L0066.Instances;


namespace R5T.Extensions
{
    public static class XElementExtensions
    {
        /// <inheritdoc cref="IXElementOperator_Common.Acquire_Attribute(XElement, string)"/>
        public static XAttribute Acquire_Attribute(this XElement element, string attributeName)
        {
            return Instances.XElementOperator.Acquire_Attribute(element, attributeName);
        }

        public static IEnumerable<XElement> Enumerate_Children(this XElement element)
            => Instances.XElementOperator.Enumerate_Children(element);

        public static bool HasChild_Any<TElement>(this TElement element, string childName)
            where TElement : XElement
        {
            var output = Instances.XElementOperator.HasChild_Any(element, childName);
            return output;
        }

        public static bool HasChildOfChild_Single<TElement>(this TElement element,
            string childName,
            string grandChildName,
            out XElement grandChildOrChild)
            where TElement : XElement
            => Instances.XElementOperator.HasChildOfChild_Single(
                element,
                childName,
                grandChildName,
                out grandChildOrChild);

        public static bool HasChildWithChild_Single<TElement>(this TElement element,
            string childName,
            string grandChildName,
            out XElement childOrDefault)
            where TElement : XElement
            => Instances.XElementOperator.HasChildWithChild_Single(
                element,
                childName,
                grandChildName,
                out childOrDefault);

        /// <inheritdoc cref="L0066.IXElementOperator.Is_Name(XElement, string)"/>
        public static bool Is_Name(this XElement element,
            string elementName)
        {
            return Instances.XElementOperator.Is_Name(element, elementName);
        }

        /// <inheritdoc cref="L0066.IXElementOperator.Name_Is(XElement, string)"/>
        public static bool Name_Is(this XElement element,
            string elementName)
        {
            return Instances.XElementOperator.Name_Is(element, elementName);
        }

        public static IEnumerable<XElement> Where_NameIs(this IEnumerable<XElement> elements,
            string elementName)
        {
            return Instances.XElementOperator.Where_NameIs(
                elements,
                elementName);
        }
    }
}

namespace R5T.L0066.Extensions
{
    public static class XElementExtensions
    {
        public static XElement Set_Name(this XElement element,
            string name)
        {
            Instances.XElementOperator.Set_Name(
                element,
                name);

            return element;
        }
    }
}
