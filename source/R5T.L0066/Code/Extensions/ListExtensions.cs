using System;
using System.Collections.Generic;

using Instances = R5T.L0066.Instances;


namespace System
{
    public static class ListExtensions
    {
        public static void Add_Range<T>(this IList<T> list,
            IEnumerable<T> items)
        {
            Instances.ListOperator.Add_Range(list, items);
        }

        public static void Add_Range<T>(this IList<T> list,
            params T[] items)
        {
            Instances.ListOperator.Add_Range(list, items);
        }
    }
}
