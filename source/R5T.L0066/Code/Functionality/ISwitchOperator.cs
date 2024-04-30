using System;

using R5T.T0132;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface ISwitchOperator : IFunctionalityMarker
    {
        public ArgumentException Get_UnrecognizedSwitchTypeExpression<T>(T value)
        {
            var typeName = Instances.TypeOperator.Get_TypeNameOf(value);

            var exception = new ArgumentException($"{typeName} - Unrecognized type.");
            return exception;
        }

        /// <summary>
        /// <para>Quality-of-life overload for <see cref="Get_UnexpectedEnumerationValueException{TEnum}(TEnum)"/></para>
        /// Produces an exception for use in the default case of a switch statement based on values of the <typeparamref name="TEnum"/> enumeration.
        /// Note: there is no method just throwing the exception, as the VS linter does not detect that a method call will always produce an exception, and thus demands that switch default case behavior cannot fall through one default case to another. The throw keyword in the switch default case must be present.
        /// </summary>
        public Exception Get_DefaultCaseException<TEnum>(TEnum value)
            where TEnum : Enum
        {
            var exception = this.Get_UnexpectedEnumerationValueException(value);
            return exception;
        }

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
