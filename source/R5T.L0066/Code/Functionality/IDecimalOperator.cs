using System;

using R5T.T0132;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface IDecimalOperator : IFunctionalityMarker
    {
        public Decimal Parse(string decimalString)
        {
            var output = Decimal.Parse(decimalString);
            return output;
        }
    }
}
