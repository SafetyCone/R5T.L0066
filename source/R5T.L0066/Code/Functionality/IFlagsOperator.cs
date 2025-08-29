using System;

using R5T.T0132;
using R5T.T0143;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface IFlagsOperator : IFunctionalityMarker,
        F10Y.L0000.IFlagsOperator
    {
#pragma warning disable IDE1006 // Naming Styles

        [Ignore]
        public new Implementations.IFlagsOperator _Implementations => Implementations.FlagsOperator.Instance;

        [Ignore]
        public F10Y.L0000.IFlagsOperator _F10Y_L0000 => F10Y.L0000.FlagsOperator.Instance;

#pragma warning restore IDE1006 // Naming Styles


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
