using System;
using System.Collections.Generic;

using R5T.T0132;


namespace R5T.L0066.Implementations
{
    [FunctionalityMarker]
    public partial interface IListOperator : IFunctionalityMarker
    {
        public T Get_Second_ViaIndex<T>(IList<T> list)
        {
            var output = list[1];
            return output;
        }

        public T Get_Second_ViaNth<T>(IList<T> list)
        {
            var output = Instances.ListOperator.Get_Nth(list, 2);
            return output;
        }
    }
}
