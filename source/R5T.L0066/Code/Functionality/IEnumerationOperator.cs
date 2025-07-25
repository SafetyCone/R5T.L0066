using System;
using System.Linq;

using R5T.T0132;
using R5T.T0143;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface IEnumerationOperator : IFunctionalityMarker,
        F10Y.L0000.IEnumerationOperator
    {
#pragma warning disable IDE1006 // Naming Styles

        [Ignore]
        public F10Y.L0000.IEnumerationOperator _F10Y_L0000 => F10Y.L0000.EnumerationOperator.Instance;

        [Ignore]
        public Implementations.IEnumerationOperator _Implementations => Implementations.EnumerationOperator.Instance;

#pragma warning restore IDE1006 // Naming Styles


        public TEnum[] Get_Values<TEnum>()
            where TEnum : Enum
            => _Implementations.Get_Values_SimpleSyntax<TEnum>();

        public Array Get_Values(Type enumerationType)
        {
            var output = Enum.GetValues(enumerationType);
            return output;
        }

        public Type Get_EnumerationType<TEnum>()
            where TEnum : Enum
        {
            var output = Instances.TypeOperator.Get_TypeOf<TEnum>();
            return output;
        }

        public Type Get_EnumerationType<TEnum>(TEnum enumerationValue)
            where TEnum : Enum
            => this.Get_EnumerationType<TEnum>();

        public Type Get_UnderlyingType(Enum value)
        {
            var enumerationType = value.GetType();

            var output = this.Get_UnderlyingType(enumerationType);
            return output;
        }

        public Type Get_UnderlyingType<TEnum>(TEnum enumerationValue)
            where TEnum : Enum
        {
            var enumerationType = Instances.TypeOperator.Get_TypeOf(enumerationValue);

            var output = this.Get_UnderlyingType(enumerationType);
            return output;
        }

        public Type Get_UnderlyingType<TEnum>()
            where TEnum : Enum
        {
            var enumerationType = typeof(TEnum);

            var output = this.Get_UnderlyingType(enumerationType);
            return output;
        }

        public Type Get_UnderlyingType(Type enumerationType)
        {
            var output = Enum.GetUnderlyingType(enumerationType);
            return output;
        }

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

        public int Get_ValueOf_Integer32_Unchecked<TEnum>(TEnum enumerationValue)
        {
            var output = Convert.ToInt32(enumerationValue);
            return output;
        }

        public int Get_ValueOf_Integer32_Checked<TEnum>(TEnum enumerationValue)
            where TEnum : Enum
        {
            this.Verify_UnderlyingType_IsInteger32(enumerationValue);

            var output = this.Get_ValueOf_Integer32_Unchecked(enumerationValue);
            return output;
        }

        /// <summary>
        /// Chooses <see cref="Get_ValueOf_Integer32_Unchecked{TEnum}(TEnum)"/> as the default.
        /// (Because an exception wil be thrown anyway.)
        /// </summary>
        public int Get_ValueOf_Integer32<TEnum>(TEnum enumerationValue)
            where TEnum : Enum
            => this.Get_ValueOf_Integer32_Unchecked(enumerationValue);

        public bool Is_UnderlyingType_Integer32<TEnum>()
            where TEnum : Enum
        {
            var underlyingType = this.Get_UnderlyingType<TEnum>();

            var integer32Type = Instances.TypeOperator.Get_TypeOf<int>();

            var output = Instances.TypeOperator.Equals(
                underlyingType,
                integer32Type);

            return output;
        }

        //public bool Is<T>(Enum value, Enum flag)
        //    where T : Enum
        //{

        //}

        public bool Is_UnderlyingType_Integer32<TEnum>(TEnum enumerationValue)
            where TEnum : Enum
            => this.Is_UnderlyingType_Integer32<TEnum>();

        public void Verify_UnderlyingType_IsInteger32<TEnum>()
            where TEnum : Enum
        {
            var is_Interger32 = this.Is_UnderlyingType_Integer32<TEnum>();
            if(!is_Interger32)
            {
                var underlyingType = this.Get_UnderlyingType<TEnum>();

                var enumerationType = Instances.TypeOperator.Get_TypeOf<TEnum>();

                var message = Instances.EnumerableOperator.From("Underlying type for enumeration type was not Integer32")
                    .Append($"{Instances.TypeOperator.Get_NamespacedTypeName(underlyingType)}: underlying type found")
                    .Append($"{Instances.TypeOperator.Get_NamespacedTypeName(enumerationType): enumertion type}")
                    .Join_Lines();

                throw new Exception(message);
            }
        }

        public void Verify_UnderlyingType_IsInteger32<TEnum>(TEnum enuemrationVaue)
            where TEnum : Enum
            => this.Verify_UnderlyingType_IsInteger32<TEnum>();
    }
}
