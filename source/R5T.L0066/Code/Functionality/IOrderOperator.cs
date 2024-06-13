using System;
using System.Collections.Generic;
using System.Linq;

using R5T.T0132;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface IOrderOperator : IFunctionalityMarker
    {
        /// <summary>
        /// Used in ordering objects by explicit name order.
        /// </summary>
        public Dictionary<string, int> Get_OrderIndicesByName(IEnumerable<string> orderedNames)
        {
            var counter = 0;

            var orderIndicesByName = orderedNames
                .ToDictionary(
                    x => x,
                    x => counter++);

            return orderIndicesByName;
        }

        public int Get_Index<TElement>(
            TElement element,
            Dictionary<string, int> orderIndicesByName,
            Func<TElement, string> nameSelector)
        {
            var name = nameSelector(element);

            var isSpecified = orderIndicesByName.ContainsKey(name);

            var index = isSpecified
                ? orderIndicesByName[name]
                : Instances.Indices.NotFound
                ;

            return index;
        }

        /// <summary>
        /// Orders elements by name, given names in order.
        /// Any elements whose name is not in the list are appended to the ordered list, in encountered order.
        /// </summary>
        public IEnumerable<TElement> Order_ByNames<TElement>(
            IEnumerable<TElement> elements,
            Func<TElement, string> nameSelector,
            IEnumerable<string> orderedNames)
        {
            var orderIndicesByName = this.Get_OrderIndicesByName(orderedNames);

            var orderableNodes = new List<(int, TElement)>();
            var unorderableNodes = new List<TElement>();

            foreach (var element in elements)
            {
                var index = this.Get_Index(
                    element,
                    orderIndicesByName,
                    nameSelector);

                var indexIsFound = IndexOperator.Instance.Is_Found(index);
                if (indexIsFound)
                {
                    orderableNodes.Add((index, element));
                }
                else
                {
                    unorderableNodes.Add(element);
                }
            }

            var orderedNodes = orderableNodes
                .OrderBy(x => x.Item1)
                .Select(x => x.Item2)
                .AppendRange(unorderableNodes)
                ;

            return orderedNodes;
        }

        /// <inheritdoc cref="Order_ByNames{TElement}(IEnumerable{TElement}, Func{TElement, string}, IEnumerable{string})"/>
        public IEnumerable<TElement> Order_ByNames<TElement>(
            IEnumerable<TElement> elements,
            Func<TElement, string> nameSelector,
            params string[] orderedNames)
        {
            return this.Order_ByNames(
                elements,
                nameSelector,
                orderedNames.AsEnumerable());
        }
    }
}
