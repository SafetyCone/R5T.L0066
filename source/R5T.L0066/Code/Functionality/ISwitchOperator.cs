using System;

using F10Y.T0011;

using R5T.T0132;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface ISwitchOperator : IFunctionalityMarker,
        F10Y.L0000.ISwitchOperator
    {
#pragma warning disable IDE1006 // Naming Styles

        [Ignore]
        F10Y.L0000.ISwitchOperator _F10Y_L0000 => F10Y.L0000.SwitchOperator.Instance;

#pragma warning restore IDE1006 // Naming Styles


        public ArgumentException Get_UnrecognizedSwitchTypeExpression<T>(T value)
        {
            var typeName = Instances.TypeOperator.Get_TypeNameOf(value);

            var exception = new ArgumentException($"{typeName} - Unrecognized type.");
            return exception;
        }

        public Exception Get_UnrecognizedEnumerationValueException<TEnum>(string representation)
            where TEnum : Enum
        {
            var enumerationTypeName = Instances.TypeOperator.Get_TypeNameOf<TEnum>();

            var message = $"Unrecognized representation '{representation}' for enumeration type {enumerationTypeName}.";

            var output = new Exception(message);
            return output;
        }

        /// <inheritdoc cref="IExceptionMessageOperator.Get_UnhandledValueExceptionMessage{TValue}(TValue)"/>
        public Exception Get_DefaultCaseException_ForType<T>(T value)
        {
            var message = Instances.ExceptionMessageOperator.Get_UnhandledValueExceptionMessage(value);

            return new Exception(message);
        }

        public ArgumentException Get_DefaultCaseException(string value)
            => new ArgumentException($"Unrecognized switch value: '{value}'.");

        public ArgumentException Get_DefaultCaseException(char value)
            => new ArgumentException($"Unrecognized switch value: '{value}'.");

        public ArgumentException Get_DefaultCaseException(
            string valueA,
            string valueB)
            => new ArgumentException($"Unrecognized switch values: '{valueA}', '{valueB}'.");

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

        /// <summary>
        /// Returns an exception indicating the value is unrecognized within a switch construct.
        /// </summary>
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
    }
}
