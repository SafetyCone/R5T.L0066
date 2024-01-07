using System;
using System.Collections.Generic;

using R5T.T0132;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface IReadOnlyListOperator : IFunctionalityMarker
    {
        public int Get_Count<T>(IReadOnlyList<T> list)
        {
            var output = list.Count;
            return output;
        }

        public T Get_Element<T>(
            IReadOnlyList<T> list,
            int index)
        {
            var output = list[index];
            return output;
        }

        public T Get_Last<T>(IReadOnlyList<T> list)
        {
            var lastIndex = this.Get_LastIndex(list);

            var output = this.Get_Element(
                list,
                lastIndex);

            return output;
        }

        public int Get_LastIndex<T>(IReadOnlyList<T> list)
        {
            var count = this.Get_Count(list);

            var output = Instances.IndexOperator.Get_IndexFromCount(count);
            return output;
        }
    }
}
