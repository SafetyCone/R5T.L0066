using System;

using R5T.T0132;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface IDateTimeOperator : IFunctionalityMarker
    {
        public int Get_Year(DateTime dateTime)
        {
            var output = dateTime.Year;
            return output;
        }
    }
}
