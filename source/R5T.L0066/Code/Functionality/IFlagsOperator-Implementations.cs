using System;

using R5T.T0132;


namespace R5T.L0066.Implementations
{
    [FunctionalityMarker]
    public partial interface IFlagsOperator : IFunctionalityMarker
    {
        /// <summary>
        /// Uses the standard library's <see cref="Enum.HasFlag(Enum)"/> method.
        /// </summary>
        /// <remarks>
        /// For source, see: <see href="https://source.dot.net/#System.Private.CoreLib/src/libraries/System.Private.CoreLib/src/System/Enum.cs,9cd73f33d2df3074"/>.
        /// </remarks>
        public bool Has_Flag_StandardLibrary<TEnum>(TEnum value, TEnum flags)
            where TEnum : Enum
        {
            var output = value.HasFlag(flags);
            return output;
        }
    }
}
