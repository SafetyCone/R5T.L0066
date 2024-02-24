using System;
using System.Collections.Generic;
using System.Diagnostics;

using R5T.T0132;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface IExceptionOperator : IFunctionalityMarker
    {
        public Exception Get_ErrorDataReceivedException(DataReceivedEventArgs eventArgs)
        {
            var exception = new Exception(
                Instances.ExceptionMessageOperator.Get_Message_IfMessageIsNull(
                    eventArgs.Data,
                    Instances.Messages.EventDataReceivedWasNull));

            return exception;
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

        public Exception Get_UnhandledValueException<TValue>(TValue value)
        {
            var message = Instances.ExceptionMessageOperator.Get_UnhandledValueExceptionMessage(value);

            return new Exception(message);
        }

        public Exception New(string message)
        {
            var output = new Exception(message);
            return output;
        }
    }
}
