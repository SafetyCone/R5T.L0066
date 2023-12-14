using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

using R5T.Extensions;

using R5T.T0132;

using XmlDocumentation = R5T.Y0006.Documentation.ForXml;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface IXElementOperator : IFunctionalityMarker
    {
#pragma warning disable IDE1006 // Naming Styles
        public Implementations.IXElementOperator _Implementations => Implementations.XElementOperator.Instance;
#pragma warning restore IDE1006 // Naming Styles


        public XAttribute Acquire_Attribute(
            XElement element,
            string attributeName)
        {
            var hasAttribute = this.Has_Attribute(element, attributeName, out var attribute);
            if (!hasAttribute)
            {
                attribute = this.Add_Attribute(element, attributeName);
            }

            return attribute;
        }

        public XElement Acquire_Child(
            XElement element,
            string elementName)
        {
            var output = Instances.XContainerOperator.Acquire_Child(
                element,
                elementName);

            return output;
        }

        public XAttribute Add_Attribute(XElement element, string attributeName)
        {
            var attribute = Instances.XAttributeOperator.New_Attribute(attributeName);

            element.Add(attribute);

            return attribute;
        }

        public void Add_Child(
            XElement parent,
            XElement child)
        {
            Instances.XContainerOperator.Add_Child(
                parent,
                child);
        }

        public void Add_Children(
            XElement parent,
            IEnumerable<XElement> children)
        {
            Instances.XContainerOperator.Add_Children(
                parent,
                children);
        }

        public void Add_Children(
            XElement parent,
            params XElement[] children)
        {
            Instances.XContainerOperator.Add_Children(
                parent,
                children);
        }

        public void Add(
            XElement parent,
            XElement child)
        {
            this.Append_Child(
                parent,
                child);
        }

        public void Append_Child(
            XElement parent,
            XElement child)
        {
            Instances.XContainerOperator.Append_Child(
                parent,
                child);
        }

        public XElement Append_Child(
            XElement parent,
            Func<XElement> childConstructor)
        {
            var child = childConstructor();

            this.Append_Child(
                parent,
                child);

            return child;
        }

        public void Add_BeforeElementEndTag(
            XElement element,
            object content)
        {
            var lastNodeOrDefault = element.LastNode;

            var isDefault = lastNodeOrDefault == default;
            if (isDefault)
            {
                element.Add(content);
            }
            else
            {
                lastNodeOrDefault.AddAfterSelf(content);
            }
        }

        /// <summary>
        /// Creates a separate, but identical instance.
        /// <para>Same as <see cref="Deep_Copy(XElement)"/></para>
        /// </summary>
        /// <remarks>
        /// <inheritdoc cref="XmlDocumentation.WhichXObjectsAreCloneable" path="/summary"/>
        /// </remarks>
        public XElement Clone(XElement element)
        {
            // Use the constructor.
            var output = new XElement(element);
            return output;
        }

        public XElement Clone_OnlyName(XElement element)
        {
            var output = new XElement(element.Name);
            return output;
        }

        public XElement Create_Element_FromName(string elementName)
        {
            var output = new XElement(elementName);
            return output;
        }

        /// <summary>
        /// Quality-of-life overload for <see cref="Parse(string, LoadOptions)"/>.
        /// </summary>
        public XElement Create_Element_FromText(
            string xmlText,
            LoadOptions loadOptions = LoadOptions.None)
        {
            var output = this.Parse(
                xmlText,
                loadOptions);

            return output;
        }

        public XElement Create_Element(string elementName)
        {
            var output = this.Create_Element_FromName(elementName);
            return output;
        }

        /// <summary>
        /// Creates a copy of the element, and all child-nodes.
        /// <para>Same as <see cref="Clone(XElement)"/></para>
        /// </summary>
        /// <remarks>
        /// <inheritdoc cref="XmlDocumentation.WhichXObjectsAreCloneable" path="/summary"/>
        /// </remarks>
        public XElement Deep_Copy(XElement element)
        {
            return this.Clone(element);
        }

        public IEnumerable<XElement> Enumerate_ChildElements(XElement element)
        {
            var output = element.Elements();
            return output;
        }

        /// <summary>
        /// Quality-of-life overload for <see cref="Enumerate_ChildElements(XElement)"/>
        /// </summary>
        public IEnumerable<XElement> Enumerate_Children(XElement element)
        {
            var output = this.Enumerate_ChildElements(element);
            return output;
        }

        public IEnumerable<XNode> Enumerate_ChildNodes(XElement element)
        {
            var output = element.Nodes();
            return output;
        }

        public IEnumerable<TNode> Enumerate_ChildNodesOfType<TNode>(XElement element)
            where TNode : XNode
        {
            var output = this.Enumerate_ChildNodes(element)
                .OfType<TNode>()
                ;

            return output;
        }

        public IEnumerable<XNode> Enumerate_DescendantNodes(XElement element)
        {
            var output = element.DescendantNodes();
            return output;
        }

        public IEnumerable<TNode> Enumerate_DescendantNodesOfType<TNode>(XElement element)
            where TNode : XNode
        {
            var output = this.Enumerate_DescendantNodes(element)
                .OfType<TNode>()
                ;

            return output;
        }

        public IEnumerable<XText> Enumerate_DescendantTextNodes(XElement element)
        {
            var output = this.Enumerate_DescendantNodesOfType<XText>(element);
            return output;
        }

        public IEnumerable<XAttribute> Get_Attributes(XElement element)
        {
            return element.Attributes();
        }

        public XElement[] Get_ChildElements(XElement element)
        {
            var output = this.Enumerate_ChildElements(element)
                .Now();

            return output;
        }

        /// <summary>
        /// Quality-of-life for <see cref="Get_ChildElements(XElement)"/>.
        /// </summary>
        public XElement[] Get_Children(XElement element)
        {
            var output = this.Enumerate_Children(element)
                .Now();

            return output;
        }

        public XNode[] Get_ChildNodes(XElement element)
        {
            var output = this.Enumerate_ChildNodes(element)
                .Now();

            return output;
        }

        public TNode[] Get_ChildNodesOfType<TNode>(XElement element)
            where TNode : XNode
        {
            var output = this.Enumerate_ChildNodesOfType<TNode>(element)
                .Now();

            return output;
        }

        public TNode[] Get_DescendantNodesOfType<TNode>(XElement element)
            where TNode : XNode
        {
            var output = this.Enumerate_DescendantNodesOfType<TNode>(element)
                .Now();

            return output;
        }

        public XText[] Get_DescendantTextNodes(XElement element)
        {
            var output = this.Enumerate_DescendantTextNodes(element)
                .Now();

            return output;
        }

        public bool Has_Attribute_First(XElement element, string attributeName, out XAttribute attributeOrDefault)
        {
            attributeOrDefault = this.Get_Attributes(element)
                .Where_NameIs(attributeName)
                .FirstOrDefault();

            var output = Instances.DefaultOperator.Is_NotDefault(attributeOrDefault);
            return output;
        }

        /// <summary>
        /// Chooses <see cref="Has_Attribute_First(XElement, string, out XAttribute)"/> as the default.
        /// </summary>
        public bool Has_Attribute(XElement element, string attributeName, out XAttribute attributeOrDefault)
        {
            return this.Has_Attribute_First(element, attributeName, out attributeOrDefault);
        }

        public bool Has_ChildElements(XElement element)
        {
            return this.Has_ChildElements(
                element,
                out _);
        }

        public bool Has_ChildElements(
            XElement element,
            out IEnumerable<XElement> childrenOrEmpty)
        {
            childrenOrEmpty = this.Enumerate_ChildElements(element);

            var output = childrenOrEmpty.Any();
            return output;
        }

        /// <summary>
        /// Uses the <see cref="XName.LocalName"/> property to avoid the crazed namespace BS.
        /// </summary>
        public bool Is_Name(XElement element, string elementName)
        {
            var output = element.Name.LocalName == elementName;
            return output;
        }

        /// <inheritdoc cref="Is_Name(XElement, string)"/>
        public bool Name_Is(XElement element, string elementName)
        {
            return this.Is_Name(element, elementName);
        }

        public XElement Parse(
            string xmlText,
            LoadOptions loadOptions = LoadOptions.None)
        {
            var output = XElement.Parse(
                xmlText,
                loadOptions);

            return output;
        }

        public XElement New(string elementName)
        {
            var output = new XElement(elementName);
            return output;
        }

        public XElement New(
            string elementName,
            string value)
        {
            var output = this.New(elementName);

            this.Set_Value(
                output,
                value);

            return output;
        }

        /// <summary>
        /// Parses the XML text as it is, without changes.
        /// </summary>
        public XElement Parse_AsIs(string xmlText)
        {
            var loadOptions = LoadOptions.PreserveWhitespace;

            var output = this.Parse(
                xmlText,
                loadOptions);

            return output;
        }

        /// <summary>
        /// Clones the input element, then modifies and return the cloned element.
        /// </summary>
        public XElement Remove_InsignificantWhitespace(XElement element)
        {
            var output = this.Clone(element);

            this.Remove_InsignificantWhitespace_Modify(output);

            return output;
        }

        /// <summary>
        /// Removes all insignificant whitespace (among descendants).
        /// <para>Note: modifies the input element.</para>
        /// </summary>
        public void Remove_InsignificantWhitespace_Modify(XElement element)
        {
            var descendantTextNodes = this.Get_DescendantTextNodes(element);

            foreach (var textNode in descendantTextNodes)
            {
                var isInsignificantWhitespace = Instances.XTextOperator.Is_InsignificantWhitespace(textNode);
                if(isInsignificantWhitespace)
                {
                    textNode.Remove();
                }
            }
        }

        public void Set_Value(XElement element, string value)
        {
            element.Value = value;
        }

        public XElement Set_ChildValue(
            XElement propertyGroupElement,
            string childName,
            string value)
        {
            var childElement = this.Acquire_Child(
                propertyGroupElement,
                childName);

            this.Set_Value(
                childElement,
                value);

            return childElement;
        }

        public async Task To_File(
            string xmlFilePath,
            XElement element,
            XmlWriterSettings xmlWriterSettings)
        {
            using var fileStream = Instances.FileStreamOperator.Open_Write(xmlFilePath);
            using var xmlWriter = XmlWriter.Create(fileStream, xmlWriterSettings);

            await element.WriteToAsync(
                xmlWriter,
                Instances.CancellationTokens.None);
        }

        public void To_File_Synchronous(
            string xmlFilePath,
            XElement element,
            XmlWriterSettings xmlWriterSettings)
        {
            using var fileStream = Instances.FileStreamOperator.Open_Write(xmlFilePath);
            using var xmlWriter = XmlWriter.Create(fileStream, xmlWriterSettings);

            element.WriteTo(xmlWriter);
        }

        public Task To_File_AsIs(
            string xmlFilePath,
            XElement element)
        {
            return this.To_File(
                xmlFilePath,
                element,
                Instances.XmlWriterSettingsSets.AsIs);
        }

        public void To_File_AsIs_Synchronous(
            string xmlFilePath,
            XElement element)
        {
            this.To_File_Synchronous(
                xmlFilePath,
                element,
                Instances.XmlWriterSettingsSets.AsIs);
        }

        public Task To_File_Indented(
            string xmlFilePath,
            XElement element)
        {
            return this.To_File(
                xmlFilePath,
                element,
                Instances.XmlWriterSettingsSets.Indented);
        }

        public void To_File_Indented_Synchronous(
            string xmlFilePath,
            XElement element)
        {
            this.To_File_Synchronous(
                xmlFilePath,
                element,
                Instances.XmlWriterSettingsSets.Indented);
        }

        public Task To_File_Unadorned(
            string xmlFilePath,
            XElement element)
        {
            return this.To_File_Unadorned_PreserveElement(
                xmlFilePath,
                element);
        }

        public void To_File_Unadorned_Synchronous(
            string xmlFilePath,
            XElement element)
        {
            this.To_File_Unadorned_PreserveElement_Synchronous(
                xmlFilePath,
                element);
        }

        public Task To_File_Unadorned_PreserveElement(
            string xmlFilePath,
            XElement element)
        {
            var trimmedElement = this.Remove_InsignificantWhitespace(element);

            return this.To_File_AsIs(
                xmlFilePath,
                trimmedElement);
        }

        public void To_File_Unadorned_PreserveElement_Synchronous(
            string xmlFilePath,
            XElement element)
        {
            var trimmedElement = this.Remove_InsignificantWhitespace(element);

            this.To_File_AsIs_Synchronous(
                xmlFilePath,
                trimmedElement);
        }

        /// <summary>
        /// It can be hard to get a text representation of an XElement that shows the XElement exactly as it is, without modifications.
        /// (For example, if the indent XML writer setting is set to true, then you will get extra text output that is not present as XText nodes in the element.)
        /// </summary>
        public string To_Text_AsIs(XElement element)
        {
            var output = this.To_Text(
                element,
                Instances.XmlWriterSettingsSets.AsIs);

            return output;
        }

        /// <summary>
        /// Chooses <see cref="To_Text_Unadorned_PreserveElement(XElement)"/> as the default.
        /// </summary>
        public string To_Text_Unadorned(XElement element)
        {
            var output = this.To_Text_Unadorned_PreserveElement(element);
            return output;
        }

        /// <summary>
        /// <para>Note: preserves the input element by making a copy, then trimming insignificant whitespace from the copy.</para>
        /// </summary>
        public string To_Text_Unadorned_PreserveElement(XElement element)
        {
            var trimmedElement = this.Remove_InsignificantWhitespace(element);

            var output = this.To_Text_AsIs(trimmedElement);
            return output;
        }

        public string To_Text(
            XElement element,
            XmlWriterSettings writerSettings)
        {
            var stringBuilder = new StringBuilder();

            using (var xmlWriter = XmlWriter.Create(stringBuilder, writerSettings))
            {
                element.WriteTo(xmlWriter);
            }

            var output = stringBuilder.ToString();
            return output;
        }

        public IEnumerable<XElement> Where_NameIs(IEnumerable<XElement> elements, string elementName)
        {
            var output = elements
                .Where(element => this.Is_Name(element, elementName))
                ;

            return output;
        }
    }
}
