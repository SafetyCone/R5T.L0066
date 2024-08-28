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

        /// <summary>
        /// Gets a message indicating that the input string representation of an enumeration value was not recognized among the string representations of a possible values of the enumeration type.
        /// </summary>
        public string Get_UnrecognizedEnumerationValueMessage(string enumerationTypeFullName, string unrecognizedValue)
        {
            var output = $@"Unrecognized enumeration value string '{unrecognizedValue}' for enumeration type {enumerationTypeFullName}";
            return output;
        }

        public string Get_UnrecognizedEnumerationValueMessage(Type enumerationType, string unrecognizedValue)
        {
            var enumerationTypeFullName = enumerationType.FullName;

            var output = this.Get_UnrecognizedEnumerationValueMessage(enumerationTypeFullName, unrecognizedValue);
            return output;
        }

        /// <summary>
        /// Produces an exception in the case where the string representation of a enumeration value is unrecognizable as one of the values of the <paramref name="enumerationTypeFullName"/> enumeration.
        /// Useful in the default case of a switch statement for parsing a string to an enumeration.
        /// </summary>
        public Exception Get_UnrecognizedEnumerationValueException(string enumerationTypeFullName, string unrecognizedValue)
        {
            var message = this.Get_UnrecognizedEnumerationValueMessage(enumerationTypeFullName, unrecognizedValue);

            var unrecognizedEnumerationValueException = new Exception(message);
            return unrecognizedEnumerationValueException;
        }

        /// <summary>
        /// Produces an exception in the case where the string representation of a enumeration value is unrecognizable as one of the values of the <paramref name="enumerationType"/> enumeration.
        /// Useful in the default case of a switch statement for parsing a string to an enumeration.
        /// </summary>
        public Exception Get_UnrecognizedEnumerationValueException(Type enumerationType, string unrecognizedValue)
        {
            var enumerationTypeFullName = enumerationType.FullName;

            var unrecognizedEnumerationValueException = this.Get_UnrecognizedEnumerationValueException(enumerationTypeFullName, unrecognizedValue);
            return unrecognizedEnumerationValueException;
        }

        /// <summary>
        /// Produces an exception in the case where the string representation of a enumeration value is unrecognizable as one of the values of the <typeparamref name="TEnum"/> enumeration.
        /// Useful in the default case of a switch statement for parsing a string to an enumeration.
        /// </summary>
        public Exception Get_UnrecognizedEnumerationValueException<TEnum>(string unrecognizedValue)
            where TEnum : Enum
        {
            var enumerationType = typeof(TEnum);

            var unrecognizedEnumerationValueException = this.Get_UnrecognizedEnumerationValueException(enumerationType, unrecognizedValue);
            return unrecognizedEnumerationValueException;
        }

        /// <inheritdoc cref="L0066.ISwitchOperator.Get_DefaultCaseException{TEnum}(TEnum)"/>
        public Exception Get_DefaultCaseException<TEnum>(TEnum value)
            where TEnum : Enum
            => Instances.SwitchOperator.Get_DefaultCaseException(value);
    }
}
