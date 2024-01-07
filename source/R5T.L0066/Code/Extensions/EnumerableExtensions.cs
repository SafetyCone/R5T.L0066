using System;
using System.Collections.Generic;

using Instances = R5T.L0066.Instances;


namespace System.Linq
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> Append<T>(this IEnumerable<T> enumerable,
            IEnumerable<T> appendix)
        {
            return Instances.EnumerableOperator.Append(enumerable, appendix);
        }

        public static IEnumerable<T> Append<T>(this IEnumerable<T> enumerable,
            params T[] appendix)
        {
            return Instances.EnumerableOperator.Append(enumerable, appendix);
        }

        public static T[] Now<T>(this IEnumerable<T> items)
        {
            var output = Instances.EnumerableOperator.Now(items);
            return output;
        }

        public static IEnumerable<T> Prepend<T>(this IEnumerable<T> items,
            IEnumerable<T> prependix)
        {
            return Instances.EnumerableOperator.Prepend(
                items,
                prependix);
        }

        public static IEnumerable<T> Prepend<T>(this IEnumerable<T> items,
            params T[] prependix)
        {
            return Instances.EnumerableOperator.Prepend(
                items,
                prependix);
        }
    }
}
