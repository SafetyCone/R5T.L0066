using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

using R5T.Extensions;

using R5T.T0132;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface IXContainerOperator : IFunctionalityMarker
    {
        public XElement Acquire_Child(
            XContainer container,
            string elementName)
        {
            var hasChild = this.Has_Child(container, elementName, out var child);
            if (!hasChild)
            {
                child = this.Append_Child(
                    container,
                    elementName);
            }

            return child;
        }

        public void Add_Child(
            XContainer parent,
            XElement child)
        {
            this.Append_Child(
                parent,
                child);
        }

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

        public void Append_Child(
            XContainer parent,
            XElement child)
        {
            parent.Add(child);
        }

        public XElement Append_Child(
            XContainer parent,
            string childName)
        {
            var child = Instances.XElementOperator.New(childName);

            this.Append_Child(
                parent,
                child);

            return child;
        }

        /// <summary>
        /// A better named quality-of-life method for <see cref="XContainer.Elements()"/>.
        /// </summary>
        public IEnumerable<XElement> Enumerate_Children(XContainer container)
        {
            return container.Elements();
        }

        public XElement[] Get_Children(XContainer container)
        {
            var output = this.Enumerate_Children(container)
                .Now();

            return output;
        }

        /// <summary>
        /// Chooses <see cref="Has_Child_First(XContainer, string, out XElement)"/> as the default.
        /// </summary>
        public bool Has_Child(XContainer container, string childName, out XElement child)
        {
            return this.Has_Child_First(container, childName, out child);
        }

        public bool Has_Child_First(XContainer container, string childName, out XElement childOrDefault)
        {
            childOrDefault = this.Enumerate_Children(container)
                .Where_NameIs(childName)
                .FirstOrDefault();

            var output = Instances.DefaultOperator.Is_NotDefault(childOrDefault);
            return output;
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
