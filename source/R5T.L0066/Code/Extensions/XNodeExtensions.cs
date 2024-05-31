using System;
using System.Xml.Linq;

using Instances = R5T.L0066.Instances;


namespace R5T.Extensions
{
    public static class XNodeExtensions
    {
        public static bool HasElement<TNode>(this TNode node,
            Func<TNode, XElement> elementOrDefaultSelector,
            out XElement elementOrDefault)
            where TNode : XNode
        {
            elementOrDefault = elementOrDefaultSelector(node);

            var output = Instances.DefaultOperator.Is_NotDefault(elementOrDefault);
            return output;
        }
    }
}
