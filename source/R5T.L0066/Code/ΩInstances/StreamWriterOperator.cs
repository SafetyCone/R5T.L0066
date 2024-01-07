using System;


namespace R5T.L0066
{
    public class StreamWriterOperator : IStreamWriterOperator
    {
        #region Infrastructure

        public static IStreamWriterOperator Instance { get; } = new StreamWriterOperator();


        private StreamWriterOperator()
        {
        }

        #endregion
    }
}
