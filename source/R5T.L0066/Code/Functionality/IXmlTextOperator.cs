using System;

using R5T.T0132;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface IXmlTextOperator : IFunctionalityMarker
    {
        /// <summary>
        /// Converts carriage return-new lines ("\r\n") and lone carriage returns ('\r') to new lines ('\n') to meet the XML specification.
        /// </summary>
        /// <remarks>
        /// The XML standard (<inheritdoc cref="Y0006.Documentation.ForXml.Links.XmlStandardEndOfLineHandling" path="/summary"/>) specifies that all end-of-lines must be new lines ('\n').
        /// Thus carriage return-new lines ("\r\n") and lone carriage returns ('\r') should be converted to new lines ('\n').
        /// </remarks>
        public string StandardizeNewLines(string xmlText)
        {
            var output = Instances.StringOperator.Convert_CarriageReturns_ToNewLines(xmlText);
            return output;
        }
    }
}
