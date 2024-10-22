using System;
using System.Xml.Linq;

using R5T.T0132;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface IXTextOperator : IFunctionalityMarker
    {
        public string Get_Value(XText text)
        {
            var output = text.Value;
            return output;
        }

        /// <summary>
        /// Quality-of-life overload for <see cref="Is_WhitespaceOnly(XText)"/>.
        /// </summary>
        public bool Is_Whitespace(XText text)
        {
            var output = this.Is_WhitespaceOnly(text);
            return output;
        }

        public bool Is_WhitespaceOnly(XText text)
        {
            var value = this.Get_Value(text);

            var output = Instances.StringOperator.Is_WhitespaceOnly(value);
            return output;
        }

        /// <summary>
        /// Determines whether an text node is insignificant whitespace.
        /// </summary>
        /// <remarks>
        /// <inheritdoc cref="Y0006.Documentation.For_Xml.InsignificantWhitespace" path="/summary"/>
        /// </remarks>
        public bool Is_InsignificantWhitespace(XText text)
        {
            // A text node is insignificant whitespace if it contains only whitespace.
            var output = this.Is_WhitespaceOnly(text);
            return output;
        }

        public XText New(string value)
        {
            var output = new XText(value);
            return output;
        }
    }
}
