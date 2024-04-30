using System;

using R5T.T0132;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface IExceptionMessageOperator : IFunctionalityMarker
    {
        public string Get_AttributeNotFoundMessage(string attributeName)
        {
            var output = $"Attribute '{attributeName}' not found.";
            return output;
        }

        public string Get_Message_IfMessageIsNull(
            string message,
            string messageIfNull)
        {
            var output = message ?? messageIfNull;
            return output;
        }

        public string Get_UnhandledValueExceptionMessage<TValue>(TValue value)
        {
            var typeName = Instances.TypeOperator.Get_TypeNameOf(value);

            var output = this.Get_UnhandledValueExceptionMessage(
                value,
                typeName);

            return output;
        }

        public string Get_UnhandledValueExceptionMessage<TValue>(
            TValue value,
            string typeName)
        {
            var message = $"Unhandled value:\nt'{value}': value\nt{typeName}: type name";
            return message;
        }
    }
}
