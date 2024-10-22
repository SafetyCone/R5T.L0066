using System;

using R5T.T0132;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface IIntegerOperator : IFunctionalityMarker
    {
        public bool Is_LessThanZero(int integer)
            => integer < 0;

        public bool Is_Negative(int integer)
            => this.Is_LessThanZero(integer);

        public string To_String(int integer)
            => integer.ToString();
    }
}
