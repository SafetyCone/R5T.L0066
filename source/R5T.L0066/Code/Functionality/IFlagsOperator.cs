using System;

using R5T.T0132;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface IFlagsOperator : IFunctionalityMarker
    {
#pragma warning disable IDE1006 // Naming Styles
        private Implementations.IFlagsOperator _Implementations => Implementations.FlagsOperator.Instance;
#pragma warning restore IDE1006 // Naming Styles



        /// <summary>
        /// Works for an enumeration value of a single flag.
        /// </summary>
        public bool Has_Flag<TEnum>(TEnum value, TEnum flag)
            where TEnum : Enum
        {
            // Use the standard library's implementation, it works for both flag and flags (since both are actually just an integer value).
            var output = _Implementations.Has_Flag_StandardLibrary(
                value,
                flag);

            return output;
        }

        /// <summary>
        /// Works for an enumeration value of combined flags.
        /// </summary>
        public bool Has_Flags<TEnum>(TEnum value, TEnum flags)
            where TEnum : Enum
        {
            // Use the standard library's implementation, it works for both flag and flags (since both are actually just an integer value).
            var output = _Implementations.Has_Flag_StandardLibrary(
                value,
                flags);

            return output;
        }

        ///// <summary>
        ///// Replaces the C# idiom of "output = value | flag".
        ///// </summary>
        //public TEnum Combine<TEnum>(TEnum value, TEnum flags)
        //    where TEnum : Enum
        //{
        //    // The implementation contains a significant amount of overhead, since the Enum type does not contain bitwise operators.
        //    IConvertible

        //    var output = value | flags;

        //    //Instances.EnumerationOperator.Verify_IsInt32Based<TEnum>();

        //    //var valueAsInt32 = Unchecked.To_Int32(value);
        //    //var flagsAsInt32 = Unchecked.To_Int32(flags);

        //    //var outputAsInt32 = valueAsInt32 | flagsAsInt32;

        //    //var output = Unchecked.From_Int32<TEnum>(outputAsInt32);
        //    //return output;

        //    var output = value | flags;
        //    return output;
        //}
    }
}
