using System;


namespace R5T.L0066
{
    public class StreamReaderOperator : IStreamReaderOperator
    {
        #region Infrastructure

        public static IStreamReaderOperator Instance { get; } = new StreamReaderOperator();


        private StreamReaderOperator()
        {
        }

        #endregion
    }
}
