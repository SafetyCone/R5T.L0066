using System;
using System.Xml.Linq;

using Instances = R5T.L0066.Instances;


namespace R5T.Extensions
{
    public static class XContainerExtensions
    {
        public static bool HasChild_Single<TElement>(this TElement element,
            string childName,
            out XElement childOrDefault)
            where TElement : XElement
        {
            var wasFound = Instances.XContainerOperator.Has_Child_Single(
                element,
                childName,
                out childOrDefault);

            return wasFound;
        }

        /// <summary>
		/// Chooses <see cref="HasChild_Single{TElement}(TElement, string, out XElement)"/> as the default.
		/// </summary>
        public static bool HasChild<TElement>(this TElement element,
            string childName,
            out XElement childOrDefault)
            where TElement : XElement
            => element.HasChild_Single(
                childName,
                out childOrDefault);
    }
}
