using System;

using R5T.T0132;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface IExceptionMessageOperator : IFunctionalityMarker
    {
        public string Get_Message_IfMessageIsNull(
            string message,
            string messageIfNull)
        {
            var output = message ?? messageIfNull;
            return output;
        }
    }
}
