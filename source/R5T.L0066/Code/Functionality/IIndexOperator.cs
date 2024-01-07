using System;

using R5T.T0132;

using Glossary = R5T.Y0006.Glossary;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface IIndexOperator : IFunctionalityMarker
    {
        /// <summary>
        /// Given a zero-based index value, get the count of elements that index represents.
        /// Exclusive in the sense that the element at the index is not included.
        /// (Basically, just return the index.)
        /// </summary>
        public int Get_Count_Exclusive(int index)
        {
            var output = index;
            return output;
        }

        /// <summary>
        /// Given a zero-based index value, get the count of elements that index represents.
        /// Inclusive in the sense that the element at the index is included.
        /// (Basically, just add one to the index.)
        /// </summary>
        public int Get_Count_Inclusive(int index)
        {
            var output = index + 1;
            return output;
        }

        /// <summary>
        /// Chooses <see cref="Get_Count_Inclusive(int)"/> as the default.
        /// </summary>
        public int Get_Count(int index)
        {
            return this.Get_Count_Inclusive(index);
        }

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
        /// Gets the last <inheritdoc cref="Glossary.ForIndex.Exclusive" path="/name"/> index from a last <inheritdoc cref="Glossary.ForIndex.Inclusive" path="/name"/> index by adding one.
        /// <para><inheritdoc cref="Glossary.ForIndex.ExclusiveInclusiveRelationship" path="/definition"/></para>
        /// </summary>
        public int Get_ExclusiveIndex(int inclusiveIndex)
        {
            var output = inclusiveIndex + 1;
            return output;
        }

        public int Get_InclusiveIndex(int exclusiveIndex)
        {
            var output = exclusiveIndex - 1;
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

        public bool Is_Found(int index)
        {
            var output = Instances.Indices.NotFound != index;
            return output;
        }

        public bool Was_Found(int index)
        {
            return this.Is_Found(index);
        }

        /// <summary>
        /// Note: somewhat useless, since it's usually better to say what was being searched for was not found,
        /// instead of just that the result of searching was not found.
        /// But here anyway.
        /// </summary>
        public void Verify_IsFound(int index)
        {
            var isFound = this.Is_Found(index);
            if (!isFound)
            {
                throw new Exception("Index is not found.");
            }
        }
    }
}
