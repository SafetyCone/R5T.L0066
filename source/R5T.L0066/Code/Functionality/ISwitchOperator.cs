using System;

using R5T.T0132;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface ISwitchOperator : IFunctionalityMarker
    {
        /// <summary>
        /// Does not take a value, useful for when a type's to-string method uses a switch statement
        /// (so calling the to-string method to get a string representation of the value would result in an infinite loop).
        /// </summary>
        /// <returns></returns>
        public ArgumentException Get_UnrecognizedSwitchValueException()
        {
            var exception = new ArgumentException("Unrecognized switch value.");
            return exception;
        }

        public ArgumentException Get_UnrecognizedSwitchValueException(string value)
        {
            var exception = new ArgumentException($"{value} - Unrecognized switch value.");
            return exception;
        }

        public ArgumentException Get_UnrecognizedSwitchValueException<T>(T value)
        {
            var exception = new ArgumentException($"{value} - Unrecognized switch value.");
            return exception;
        }

        public ArgumentException Get_UnrecognizedSwitchValueException(string value, string categoryName)
        {
            var exception = new ArgumentException($"{value}:{categoryName} - Unrecognized switch value for category.");
            return exception;
        }

        /// <inheritdoc cref="IEnumerationOperator.Get_UnexpectedEnumerationValueException{TEnum}(TEnum)"/>
        public Exception Get_UnexpectedEnumerationValueException<TEnum>(TEnum unexpectedValue)
            where TEnum : Enum
        {
            var output = Instances.EnumerationOperator.Get_UnexpectedEnumerationValueException(unexpectedValue);
            return output;
        }
    }
}
