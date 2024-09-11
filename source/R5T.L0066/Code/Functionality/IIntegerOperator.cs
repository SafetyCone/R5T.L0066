using System;

using R5T.T0132;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface IIntegerOperator : IFunctionalityMarker
    {
        public string To_String(int integer)
            => integer.ToString();
    }
}
