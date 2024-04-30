using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

using R5T.T0132;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface IXAttributeOperator : IFunctionalityMarker
    {
        /// <summary>
        /// Uses the <see cref="XName.LocalName"/> property to avoid the crazed namespace BS.
        /// </summary>
        public bool Is_Name(XAttribute attribute, string attributeName)
        {
            var output = attribute.Name.LocalName == attributeName;
            return output;
        }

        /// <inheritdoc cref="Is_Name(XAttribute, string)"/>
        public bool Name_Is(XAttribute attribute, string attributeName)
        {
            return this.Is_Name(attribute, attributeName);
        }

        public XAttribute New_Attribute(string attributeName, object value)
        {
            var output = new XAttribute(attributeName, value);
            return output;
        }

        public XAttribute New_Attribute(string attributeName)
        {
            var output = this.New_Attribute(
                attributeName,
                // Use the empty string for the attribute value, since a value must be specified when creating an XAttribute,
                // but we don't want to specify the value just yet.
                Instances.Strings.Empty);

            return output;
        }

        public string Get_Value(XAttribute attribute)
        {
            var output = attribute.Value;
            return output;
        }

        /// <summary>
        /// A helpfully named wrapper for <see cref="XAttribute.SetValue(object)"/>.
        /// </summary>
        public void Set_Value(XAttribute attribute, object value)
        {
            attribute.SetValue(value);
        }

        public IEnumerable<XAttribute> Where_NameIs(IEnumerable<XAttribute> attributes, string attributeName)
        {
            var output = attributes
                .Where(attribute => this.Is_Name(attribute, attributeName))
                ;

            return output;
        }
    }
}
