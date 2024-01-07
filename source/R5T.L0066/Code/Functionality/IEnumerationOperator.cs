using System;

using R5T.T0132;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface IEnumerationOperator : IFunctionalityMarker
    {
        /// <summary>
        /// Gets a message indicating the the input value of the <typeparamref name="TEnum"/> enumeration was unexpected.
        /// This is useful in producing an error in the default case for switch statements based on enumeration values.
        /// </summary>
        /// <remarks>
        /// See: https://stackoverflow.com/questions/13645149/what-is-the-correct-exception-to-throw-for-unhandled-enum-values
        /// </remarks>
        public string Get_UnexpectedEnumerationValueExceptionMessage<TEnum>(TEnum unexpectedValue)
            where TEnum : Enum
        {
            var output = $"Unexpected enumeration value: '{unexpectedValue}' for enumeration type {typeof(TEnum).FullName}";
            return output;
        }

        public Exception Get_UnexpectedEnumerationValueException<TEnum>(TEnum unexpectedValue)
            where TEnum : Enum
        {
            var message = this.Get_UnexpectedEnumerationValueExceptionMessage(unexpectedValue);

            var output = new Exception(message);
            return output;
        }
    }
}
