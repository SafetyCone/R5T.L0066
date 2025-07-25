using System;
using System.Collections.Generic;
using System.Diagnostics;

using R5T.T0132;
using R5T.T0143;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface IExceptionOperator : IFunctionalityMarker,
        F10Y.L0000.IExceptionOperator
    {
#pragma warning disable IDE1006 // Naming Styles

        [Ignore]
        public F10Y.L0000.IExceptionOperator _F10Y_L0000 => F10Y.L0000.ExceptionOperator.Instance;

#pragma warning restore IDE1006 // Naming Styles


        public Exception Get_ErrorDataReceivedException(DataReceivedEventArgs eventArgs)
        {
            var exception = new Exception(
                Instances.ExceptionMessageOperator.Get_Message_IfMessageIsNull(
                    eventArgs.Data,
                    Instances.Messages.EventDataReceivedWasNull));

            return exception;
        }

        public Exception Get_UnhandledValueException<TValue>(TValue value)
        {
            var message = Instances.ExceptionMessageOperator.Get_UnhandledValueExceptionMessage(value);

            var output = new Exception(message);
            return output;
        }

        /// <summary>
		/// <inheritdoc cref="Documentation.ListCountsNotActuallyChecked" path="/summary"/>
		/// Just gets the exception assuming that is the case.
		/// </summary>
		public Exception GetListCountsUnequalException<T>(
            IList<T> a,
            IList<T> b)
        {
            var message = MessageOperator.Instance.Get_UnequalListCountsMessage(a, b);

            var output = new Exception(message);
            return output;
        }

        public Exception New(string message)
        {
            var output = new Exception(message);
            return output;
        }
    }
}
