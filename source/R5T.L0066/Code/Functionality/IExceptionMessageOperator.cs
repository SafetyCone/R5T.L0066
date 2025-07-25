using System;

using R5T.T0132;
using R5T.T0143;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface IExceptionMessageOperator : IFunctionalityMarker,
        F10Y.L0000.IExceptionMessageOperator
    {
#pragma warning disable IDE1006 // Naming Styles

        [Ignore]
        public F10Y.L0000.IExceptionMessageOperator _F10Y_L0000 => F10Y.L0000.ExceptionMessageOperator.Instance;

#pragma warning restore IDE1006 // Naming Styles


        public string Get_Message_IfMessageIsNull(
            string message,
            string messageIfNull)
        {
            var output = message ?? messageIfNull;
            return output;
        }

        /// <summary>
        /// Given a value (and its type), get an exception message descrbing how the value of the type is unhandled.
        /// </summary>
        public string Get_UnhandledValueExceptionMessage<TValue>(TValue value)
        {
            var typeName = Instances.TypeOperator.Get_TypeNameOf(value);

            var output = this.Get_UnhandledValueExceptionMessage(
                value,
                typeName);

            return output;
        }

        /// <summary>
        /// Given a value and its type name, get an exception message descrbing how the value of the type is unhandled.
        /// </summary>
        public string Get_UnhandledValueExceptionMessage<TValue>(
            TValue value,
            string typeName)
        {
            var valueName = value is null
                ? "null"
                : value.ToString()
                ;

            var message = $"Unhandled value:\n\t'{valueName}': value\n\t{typeName}: type name";
            return message;
        }
    }
}
