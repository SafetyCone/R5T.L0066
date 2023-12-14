using System;

using R5T.T0131;


namespace R5T.L0066
{
    [ValuesMarker]
    public partial interface ISeeds : IValuesMarker
    {
        /// <inheritdoc cref="Pi_Constant"/>
        public const int Default_Constant = ISeeds.Pi_Constant;

        /// <inheritdoc cref="Default_Constant"/>
        public int Default => ISeeds.Default_Constant;

        /// <summary>
        /// 31415, the first five digits of pi, as an integer.
        /// </summary>
        public const int Pi_Constant = 31415;

        /// <inheritdoc cref="Pi_Constant"/>
        public int Pi => ISeeds.Pi_Constant;
    }
}
