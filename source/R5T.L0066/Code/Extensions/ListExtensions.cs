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

        public static void Replace_Contents_With<T>(this IList<T> list,
            IEnumerable<T> newValues)
            => Instances.ListOperator.Replace_Contents_With(
                list,
                newValues);

        public static void Replace_Contents_With<T>(this IList<T> list,
            params T[] newValues)
            => Instances.ListOperator.Replace_Contents_With(
                list,
                newValues);

        public static void Replace_Contents_With<T>(this List<T> list,
            IEnumerable<T> newValues)
            => Instances.ListOperator.Replace_Contents_With(
                list,
                newValues);

        public static void Replace_Contents_With<T>(this List<T> list,
            params T[] newValues)
            => Instances.ListOperator.Replace_Contents_With(
                list,
                newValues);
    }
}
