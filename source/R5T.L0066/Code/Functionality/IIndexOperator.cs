using System;

using R5T.T0132;
using R5T.T0143;

using Glossary = R5T.Y0006.Glossary;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface IIndexOperator : IFunctionalityMarker,
        F10Y.L0000.IIndexOperator
    {
#pragma warning disable IDE1006 // Naming Styles

        [Ignore]
        public F10Y.L0000.IIndexOperator _F10Y_L0000 => F10Y.L0000.IndexOperator.Instance;

#pragma warning restore IDE1006 // Naming Styles


        /// <summary>
        /// Gets the count of elements starting at the start index (inclusive) and ending at the end index (inclusive).
        /// </summary>
        public int Get_Count_Inclusive_Inclusive(
            int startIndex,
            int endIndex)
        {
            var output = endIndex - startIndex + 1;
            return output;
        }

        public int Get_Count_Exclusive_Exclusive(
            int startIndex,
            int endIndex)
        {
            var output = endIndex - startIndex - 1;
            return output;
        }

        /// <summary>
        /// Assuming a zero-based index, the current index is one less than the current count.
        /// </summary>
        public int Get_IndexFromCount(int count)
        {
            var output = count - 1;
            return output;
        }

        public int Get_LastIndexFromLength(int length)
        {
            var output = length - 1;
            return output;
        }

        /// <summary>
        /// If you have a list with a known length, and an index within that list, if you reverse the list, what would be the new index?
        /// </summary>
        /// <remarks>
        /// Note: works for indices outside of the list as well.
        /// </remarks>
        public int Get_IndexFromEnd(
            int index,
            int length)
        {
            var output = (length - 1) - index;
            return output;
        }

        /// <summary>
        /// Returns true of the index is the first index in a zero-based indexing system (is <see cref="L0066.IIndices.Zero"/>).
        /// </summary>
        public bool Is_First(int index)
        {
            var output = Instances.Indices.Zero == index;
            return output;
        }
    }
}
