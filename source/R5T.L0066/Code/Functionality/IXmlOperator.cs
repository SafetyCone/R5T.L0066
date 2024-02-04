using System;
using System.Xml.Linq;

using R5T.T0132;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface IXmlOperator : IFunctionalityMarker
    {
        public XDocument Load_XDocument_Synchronous(string xmlFilePath)
        {
            var output = Instances.XDocumentOperator.Load_Synchronous(xmlFilePath);
            return output;
        }

        public XElement New_Element(string elementName)
        {
            var output = Instances.XElementOperator.New(elementName);
            return output;
        }

        /// <inheritdoc cref="IXmlTextOperator.StandardizeNewLines(string)"/>
        public string StandardizeNewLines(string xmlText)
        {
            var output = Instances.XmlTextOperator.StandardizeNewLines(xmlText);
            return output;
        }
    }
}
