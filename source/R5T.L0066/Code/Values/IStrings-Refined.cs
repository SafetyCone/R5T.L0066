using System;


namespace R5T.L0066
{
    public partial interface IStrings
    {
        /// <inheritdoc cref="Period_Constant"/>
        public const string Dot_Constant = IStrings.Period_Constant;

        /// <inheritdoc cref="Dot_Constant"/>
        public string Dot => IStrings.Dot_Constant;
    }
}
