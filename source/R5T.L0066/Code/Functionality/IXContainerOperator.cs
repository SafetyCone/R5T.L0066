using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

using F10Y.T0011;

using R5T.Extensions;

using R5T.T0132;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface IXContainerOperator : IFunctionalityMarker,
        F10Y.L0000.IXContainerOperator
    {
#pragma warning disable IDE1006 // Naming Styles

        [Ignore]
        public F10Y.L0000.IXContainerOperator _F10Y_L0000 => F10Y.L0000.XContainerOperator.Instance;

#pragma warning restore IDE1006 // Naming Styles


        /// <summary>
        /// Creates a child with the given name and text value, adds the child to the container, then returns the newly created child element.
        /// </summary>
        public XElement Add_Child(XContainer container,
            string childName,
            string childValue)
        {
            var child = Instances.XElementOperator.New(childName);

            child.Value = childValue;

            container.Add(child);

            return child;
        }

        public void Add_Children(
            XContainer parent,
            IEnumerable<XElement> children)
        {
            foreach (var child in children)
            {
                this.Append_Child(
                    parent,
                    child);
            }
        }

        public void Add_Children(
            XContainer parent,
            params XElement[] children)
        {
            this.Add_Children(
                parent,
                children.AsEnumerable());
        }

        public bool Has_Child_Single(XContainer container, string childName, out XElement childOrDefault)
        {
            childOrDefault = this.Enumerate_Children(container)
                .Where_NameIs(childName)
                .SingleOrDefault();

            var output = Instances.DefaultOperator.Is_NotDefault(childOrDefault);
            return output;
        }
    }
}
