using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

using R5T.Extensions;

using R5T.T0132;
using R5T.T0143;

using IXElementOperator_Common = F10Y.L0000.IXElementOperator;

using XmlDocumentation = R5T.Y0006.Documentation.For_Xml;


namespace R5T.L0066
{
    /// <summary>
    /// Strictly-framework, common, unopinionated <see cref="XElement"/>-related operators.
    /// </summary>
    /// <remarks>
    /// Conventions:
    /// <list type="bullet">
    /// <item>All input <see cref="XElement"/> parameters should have the name "element" (not "xElement).</item>
    /// </list>
    /// </remarks>
    [FunctionalityMarker]
    public partial interface IXElementOperator : IFunctionalityMarker,
        F10Y.L0000.IXElementOperator
    {
#pragma warning disable IDE1006 // Naming Styles

        [Ignore]
        public Implementations.IXElementOperator _Implementations => Implementations.XElementOperator.Instance;


        [Ignore]
        public F10Y.L0000.IXElementOperator _F10Y_L0000 => F10Y.L0000.XElementOperator.Instance;

#pragma warning restore IDE1006 // Naming Styles


        public string Get_AttributeValue(
            XElement element,
            string attributeName)
        {
            var attribute = this.Get_Attribute(
                element,
                attributeName);

            var output = Instances.XAttributeOperator.Get_Value(attribute);
            return output;
        }

        /// <summary>
		/// Creates an <see cref="XElement"/> with the child name, adds it to the parent, and returns the child.
		/// </summary>
		/// <returns>The child <see cref="XElement"/>.</returns>
		public XElement Add_Child(XElement parentElement, string childName)
        {
            var child = this.Create_Element_FromName(childName);

            parentElement.Add(child);

            return child;
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

        /// <summary>
        /// Quality-of-life overload for <see cref="IXElementOperator_Common.Parse(string, LoadOptions)"/>.
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

        public IEnumerable<XElement> Enumerate_Children(
            XElement element,
            string childName)
            => this.Enumerate_Children(element)
                .Where_NameIs(childName)
                ;

        public IEnumerable<XElement> Enumerate_ChildrenOfChildren(
            XElement element,
            string childName,
            string grandchildName)
        {
            var output = this.Enumerate_Children(
                element,
                childName)
                .SelectMany(childElement => this.Enumerate_Children(
                    childElement,
                    grandchildName))
                ;

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

        public IEnumerable<XElement> Enumerate_DescendantElements(XElement element)
        {
            var output = element.Descendants();
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

        /// <summary>
        /// Chooses <see cref="Get_ChildElement_ByLocalName(XElement, string)"/> as the default.
        /// </summary>
        public XElement Get_ChildElement(
            XElement element,
            string childName)
        {
            var output = this.Get_ChildElement_ByLocalName(
                element,
                childName);
            
            return output;
        }

        public XElement Get_ChildElement_ByLocalName(
            XElement element,
            string childName)
        {
            var output = this.Enumerate_ChildElements(element)
                .Where_NameIs(childName)
                .FirstOrDefault();

            return output;
        }

        /// <summary>
        /// Requires the namespace node name if the element in a namespace.
        /// </summary>
        /// <remarks>
        /// This is the default behavior of <see cref="XContainer.Element(XName)"/>.
        /// </remarks>
        public XElement Get_ChildElement_ByGlobalName(
            XElement element,
            string childName)
        {
            var output = element.Element(childName);
            return output;
        }

        public string Get_ChildElementValue(
            XElement element,
            string childName)
        {
            var childElement = this.Get_ChildElement(
                element,
                childName);

            var output = this.Get_Value(childElement);
            return output;
        }

        public XElement[] Get_ChildElements(
            XElement element,
            string childName)
        {
            var output = this.Enumerate_ChildElements(element)
                .Where_NameIs(childName)
                .ToArray();

            return output;
        }

        public XElement[] Get_ChildElements(XElement element)
        {
            var output = this.Enumerate_ChildElements(element)
                .ToArray();

            return output;
        }

        /// <summary>
        /// Quality-of-life for <see cref="Get_ChildElements(XElement)"/>.
        /// </summary>
        public XElement[] Get_Children(XElement element)
        {
            var output = this.Enumerate_Children(element)
                .ToArray();

            return output;
        }

        public XNode[] Get_ChildNodes(XElement element)
        {
            var output = this.Enumerate_ChildNodes(element)
                .ToArray();

            return output;
        }

        public TNode[] Get_ChildNodesOfType<TNode>(XElement element)
            where TNode : XNode
        {
            var output = this.Enumerate_ChildNodesOfType<TNode>(element)
                .ToArray();

            return output;
        }

        public TNode[] Get_DescendantNodesOfType<TNode>(XElement element)
            where TNode : XNode
        {
            var output = this.Enumerate_DescendantNodesOfType<TNode>(element)
                .ToArray();

            return output;
        }

        public XText[] Get_DescendantTextNodes(XElement element)
        {
            var output = this.Enumerate_DescendantTextNodes(element)
                .ToArray();

            return output;
        }

        public XNode Get_FirstChildNode(XElement element)
        {
            var hasFirstChildNode = this.Has_FirstChildNode(
                element,
                out var firstChildNode_OrDefault);

            if(!hasFirstChildNode)
            {
                throw new Exception("Element did not have a first child node.");
            }

            return firstChildNode_OrDefault;
        }

        public bool Has_FirstChildNode(
            XElement element,
            out XNode firstChildNode_OrDefault)
        {
            firstChildNode_OrDefault = this.Enumerate_ChildNodes(element)
                .FirstOrDefault();

            var output = Instances.DefaultOperator.Is_NotDefault(firstChildNode_OrDefault);
            return output;
        }

        public bool Has_FirstDescendantElement_OfName(
            XElement element,
            string descendantElementName,
            out XElement firstDescendantNode_OrDefault)
        {
            firstDescendantNode_OrDefault = this.Enumerate_DescendantElements(element)
                .Where_NameIs(descendantElementName)
                .FirstOrDefault();

            var output = Instances.DefaultOperator.Is_NotDefault(firstDescendantNode_OrDefault);
            return output;
        }

        public bool HasChild_Any<TElement>(TElement element, string childName)
            where TElement : XElement
        {
            // If empty, shortcut.
            if (!element.HasElements)
            {
                return false;
            }

            var output = element.Elements()
                .Where(element => element.Name.LocalName == childName)
                .Any();

            return output;
        }

        public bool Has_ChildElements(
            XElement element,
            out IEnumerable<XElement> childrenOrEmpty)
        {
            childrenOrEmpty = this.Enumerate_ChildElements(element);

            var output = childrenOrEmpty.Any();
            return output;
        }

        public bool Has_ChildElements(XElement element)
        {
            return this.Has_ChildElements(
                element,
                out _);
        }

        public bool HasChildOfChild_Single<TElement>(TElement element,
            string childName,
            string grandChildName,
            out XElement grandChildOrDefault)
            where TElement : XElement
        {
            grandChildOrDefault = element.Elements()
                .Where_NameIs(childName)
                .SelectMany(childElement => childElement.Elements()
                    .Where_NameIs(grandChildName))
                .SingleOrDefault();

            var output = Instances.DefaultOperator.Is_NotDefault(grandChildOrDefault);
            return output;
        }

        public bool HasChildWithChild_Single<TElement>(TElement element,
            string childName,
            string grandChildName,
            out XElement grandChildOrDefault)
            where TElement : XElement
        {
            grandChildOrDefault = element.Elements()
                .Where_NameIs(childName)
                .Where(element => element.HasChild_Any(grandChildName))
                .SingleOrDefault();

            var output = Instances.DefaultOperator.Is_NotDefault(grandChildOrDefault);
            return output;
        }

        /// <summary>
        /// Uses the <see cref="XName.LocalName"/> property to avoid the crazed namespace BS.
        /// </summary>
        public bool Is_Name(XElement element, string elementName)
            => this.Is_LocalName(element, elementName);

        /// <inheritdoc cref="Is_Name(XElement, string)"/>
        public bool Name_Is(XElement element, string elementName)
        {
            return this.Is_Name(element, elementName);
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
        /// Quality-of-life overload for <see cref="IXElementOperator_Common.New()"/>.
        /// </summary>
        public XElement Get_New()
            => this.New();

        /// <summary>
        /// Quality-of-life overload for <see cref="IXElementOperator_Common.New(string)"/>.
        /// </summary>
        public XElement Get_New(string elementName)
            => this.New(elementName);

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

        public IEnumerable<XElement> SelectElements_ByXPath(
            XElement element,
            string xPath)
            => element.XPathSelectElements(xPath);

        public XElement SelectElement_ByXPath(
            XElement element,
            string xPath)
            => element.XPathSelectElement(
                xPath);

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

        /// <summary>
        /// Quality-of-life overload for <see cref="IXElementOperator_Common.Parse(string, LoadOptions)"/>.
        /// </summary>
        public XElement From_Text(
            string xmlText,
            LoadOptions loadOptions = LoadOptions.None)
            => this.Parse(
                xmlText,
                loadOptions);

        /// <summary>
        /// Quality-of-life overload for <see cref="Parse_AsIs(string)"/>.
        /// </summary>
        public XElement From_Text_AsIs(string xmlText)
            => this.Parse_AsIs(xmlText);

        public async Task<XElement> From_File(
            string xmlFilePath,
            LoadOptions loadOptions)
        {
            var fileStream = Instances.FileStreamOperator.Open_Read(xmlFilePath);

            var output = await XElement.LoadAsync(
                fileStream,
                loadOptions,
                Instances.CancellationTokens.None);

            return output;
        }

        public Task<XElement> From_File(string xmlFilePath)
            => this.From_File(
                xmlFilePath,
                LoadOptions.None);

        /// <summary>
        /// Writes an <see cref="XElement"/> to a file, using the provided <see cref="XmlWriterSettings"/>.
        /// </summary>
        public async Task To_File(
            string xmlFilePath,
            XElement element,
            XmlWriterSettings xmlWriterSettings)
        {
            xmlWriterSettings.Async = true;

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

        /// <summary>
        /// Quality-of-life overload for <see cref="To_File(string, XElement)"/>.
        /// <para><inheritdoc cref="To_File(string, XElement)" path="descendant::summary-base"/></para>
        /// </summary>
        public Task Save(
            string xmlFilePath,
            XElement element)
            => this.To_File(
                xmlFilePath,
                element);

        /// <summary>
        /// Quality-of-life overload for <see cref="To_File(string, XElement)"/>.
        /// <para><inheritdoc cref="To_File(string, XElement)" path="descendant::summary-base"/></para>
        /// </summary>
        public Task Serialize_ToFile(
            string xmlFilePath,
            XElement element)
            => this.To_File(
                xmlFilePath,
                element);

        /// <summary>
        /// Quality-of-life overload for <see cref="To_File_AsIs(string, XElement)"/>.
        /// <para><description><summary-base><inheritdoc cref="To_File_AsIs(string, XElement)" path="/summary"/></summary-base></description></para>
        /// </summary>
        public Task To_File(
            string xmlFilePath,
            XElement element)
            => this.To_File_AsIs(
                xmlFilePath,
                element);

        /// <summary>
        /// Writes an <see cref="XElement"/> to a file using the "as-is" XML writer settings (<see cref="IXmlWriterSettingsSet.AsIs"/>).
        /// </summary>
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

        public string To_Text_PrettyPrint(XElement element)
            => this.To_Text(
                element,
                Instances.XmlWriterSettingsSets.Indented);

        public void Verify_NameIs(
            XElement element,
            string name)
        {
            var nameIs = this.Name_Is(
                element,
                name);

            if(!nameIs)
            {
                var actualName = this.Get_Name(element);

                throw new Exception($"Element did not have expected name '{name}'; name was '{actualName}'.");
            }
        }

        public void To_Writer_AsIs_Synchronous(
            TextWriter writer,
            IEnumerable<XElement> elements)
        {
            var texts = elements
                .Select(this.To_Text_AsIs)
                ;

            foreach (var text in texts)
            {
                writer.WriteLine(text);
            }
        }
    }
}
