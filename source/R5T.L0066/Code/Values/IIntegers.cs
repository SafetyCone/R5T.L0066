using System;

using R5T.T0131;


namespace R5T.L0066
{
    [ValuesMarker]
    public partial interface IIntegers : IValuesMarker
    {
        public int Zero => 0;

        public int One => 1;

        public int NegativeOne => -1;
    }
}
