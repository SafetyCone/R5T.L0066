using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

using R5T.Extensions;

using R5T.N0000;
using R5T.T0132;


namespace R5T.L0066.Implementations
{
    [FunctionalityMarker]
    public partial interface IXElementOperator : IFunctionalityMarker
    {
        /// <summary>
        /// Strips all insignificant formatting from the element, then indents it.
        /// </summary>
        public XElement Indent(XElement element)
        {
            // Remove all formatting from the element.
            var formattedElement = Instances.XElementOperator.Remove_InsignificantWhitespace(element);

            // Now recursively indent.
            var indentationTracker = new IndentationTracker()
            {
                IndentationUnit = Instances.Strings.DoubleSpaces,
            };

            static void Recurse(
                XElement element,
                IndentationTracker indentationTracker,
                string outerIndentation)
            {
                if (Instances.XElementOperator.Has_ChildElements(
                    element,
                    out var children))
                {
                    indentationTracker.Indent(() =>
                    {
                        var indentationOnly = indentationTracker.Get_Indentation();

                        var indentation = Instances.NewLineOperator.Prefix(indentationOnly);

                        // Use get(), not enumerate(), since we will be adding text nodes.
                        foreach (var child in children)
                        {
                            var indentationText = Instances.XTextOperator.New(indentation);

                            child.AddBeforeSelf(indentationText);

                            // Recurse.
                            Recurse(
                                child,
                                indentationTracker,
                                indentation);
                        }
                    });

                    // Don't forget to indent the closing tag, if present due to the presence of child nodes.
                    var outerIndentationText = Instances.XTextOperator.New(outerIndentation);

                    element.Add(outerIndentationText);
                }
            }

            var indentationOnly = indentationTracker.Get_Indentation();

            var indentation = Instances.NewLineOperator.Prefix(indentationOnly);

            Recurse(
                formattedElement,
                indentationTracker,
                indentation);

            return formattedElement;
        }
    }
}
