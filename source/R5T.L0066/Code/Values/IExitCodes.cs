using System;

using R5T.T0131;


namespace R5T.L0066
{
    [ValuesMarker]
    public partial interface IExitCodes : IValuesMarker
    {
        public int Failure => 1;
        public int Success => 0;
    }
}
