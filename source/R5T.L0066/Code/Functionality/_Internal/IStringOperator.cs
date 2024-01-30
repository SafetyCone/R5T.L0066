using System;

using R5T.T0132;


namespace R5T.L0066.Internal
{
    [FunctionalityMarker]
    public partial interface IStringOperator : IFunctionalityMarker
    {
        /// <summary>
        /// String length is unchecked.
        /// </summary>
        public string Except_First_Unchecked(string @string)
        {
            var output = @string[1..];
            return output;
        }

        /// <summary>
        /// If the string is null, the value <see cref="IValues.NullStringLength"/> is returned.
        /// </summary>
        public int Get_Length_CheckNull(string @string)
        {
            var isNull = Instances.NullOperator.Is_Null(@string);
            if (isNull)
            {
                return Instances.Values.NullStringLength;
            }

            var output = this.Get_Length_Unchecked(@string);
            return output;
        }

        /// <summary>
        /// Simply returns the length property of the string.
        /// <para>
        /// Unchecked in the sense that no check is performed as to whether the string is null before getting the length.
        /// </para>
        /// </summary>
        public int Get_Length_Unchecked(string @string)
        {
            var output = @string.Length;
            return output;
        }
    }
}
