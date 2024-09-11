using System;
using System.Collections.Generic;
using System.Linq;

using R5T.T0132;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface IListOperator : IFunctionalityMarker
    {
#pragma warning disable IDE1006 // Naming Styles
        private Implementations.IListOperator _Implementations => Implementations.ListOperator.Instance;
#pragma warning restore IDE1006 // Naming Styles


        public void Add_Range<T>(
            IList<T> list,
            IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                list.Add(item);
            }
        }

        public void Add_Range<T>(
            IList<T> list,
            params T[] items)
        {
            this.Add_Range(
                list,
                items.AsEnumerable());
        }

        public bool Equal_Counts<T>(
            IList<T> a,
            IList<T> b)
        {
            var lengthsAreEqual = a.Count == b.Count;
            return lengthsAreEqual;
        }

        public bool Is_Empty<T>(IList<T> values)
        {
            var output = values.Count == 0;
            return output;
        }

        public T Get_Item_Last<T>(IList<T> list)
        {
            var indexOfLast = this.Get_Index_Last(list);

            var output = this.Get_Item(
                list,
                indexOfLast);

            return output;
        }

        public int Get_Count<T>(IList<T> list)
        {
            var output = list.Count;
            return output;
        }

        public T Get_Item<T>(
            IList<T> list,
            int index)
        {
            var output = list[index];
            return output;
        }

        /// <summary>
        /// Quality-of-life overload for <see cref="Get_Item{T}(IList{T}, int)"/>.
        /// </summary>
        public T Get_Element<T>(
            IList<T> list,
            int index)
            => this.Get_Item(
                list,
                index);

        public T Get_First<T>(IList<T> list)
        {
            var output = list[0];
            return output;
        }

        public T Get_Second<T>(IList<T> list)
        {
            var output = _Implementations.Get_Second_ViaIndex(list);
            return output;
        }

        public bool Has_Nth<T>(
            IList<T> list,
            int n,
            out T nthOrDefault)
        {
            var count = list.Count;

            if (n > count)
            {
                nthOrDefault = default;

                return false;
            }

            nthOrDefault = list[n - 1];

            return true;
        }

        public bool Has_Second<T>(
            IList<T> list,
            out T secondOrDefault)
        {
            var output = this.Has_Nth(
                list,
                2,
                out secondOrDefault);

            return output;
        }

        /// <summary>
        /// Quality-of-life overload for <see cref="Get_Item_Last{T}(IList{T})"/>.
        /// </summary>
        public T Get_Last<T>(IList<T> list)
            => this.Get_Item_Last(list);

        public T Get_Last<T>(IReadOnlyList<T> list)
        {
            var output = Instances.ReadOnlyListOperator.Get_Last(list);
            return output;
        }

        public int Get_Index_Last<T>(IList<T> list)
        {
            var count = this.Get_Count(list);

            var output = Instances.IndexOperator.Get_IndexFromCount(count);
            return output;
        }

        /// <summary>
        /// Quality-of-life overload for <see cref="Get_Index_Last{T}(IList{T})"/>.
        /// </summary>
        public int Get_LastIndex<T>(IList<T> list)
            => this.Get_Index_Last(list);

        public T Get_Nth<T>(IList<T> list, int n)
        {
            var wasFound = this.Has_Nth(
                list,
                n,
                out var nth);

            if (!wasFound)
            {
                throw new InvalidOperationException($"List did not have an Nth (N = {n}) element.");
            }

            return nth;
        }

        public T Get_NthOrDefault<T>(IList<T> list, int n)
        {
            _ = this.Has_Nth(
                list,
                n,
                out var nthOrDefault);

            return nthOrDefault;
        }

        public T Get_SecondOrDefault<T>(IList<T> list)
        {
            var output = this.Get_NthOrDefault(list, 2);
            return output;
        }

        /// <summary>
        /// Clear the list, then add the new values.
        /// </summary>=
        public void Replace_Contents_With<T>(
            IList<T> list,
            IEnumerable<T> newValues)
        {
            list.Clear();
            list.Add_Range(newValues);
        }

        /// <inheritdoc cref="Replace_Contents_With{T}(IList{T}, IEnumerable{T})"/>
        public void Replace_Contents_With<T>(
            IList<T> list,
            params T[] newValues)
            => this.Replace_Contents_With(
                list,
                newValues.AsEnumerable());

        /// <inheritdoc cref="Replace_Contents_With{T}(IList{T}, IEnumerable{T})"/>
        public void Replace_Contents_With<T>(
            List<T> list,
            IEnumerable<T> newValues)
        {
            list.Clear();
            list.AddRange(newValues);
        }

        /// <inheritdoc cref="Replace_Contents_With{T}(IList{T}, IEnumerable{T})"/>
        public void Replace_Contents_With<T>(
            List<T> list,
            params T[] newValues)
            => this.Replace_Contents_With(
                list,
                newValues.AsEnumerable());

        public void Verify_EqualCounts<T>(
            IList<T> a,
            IList<T> b)
        {
            var lengthsAreEqual = this.Equal_Counts(a, b);
            if (!lengthsAreEqual)
            {
                throw ExceptionOperator.Instance.GetListCountsUnequalException(a, b);
            }
        }
    }
}
