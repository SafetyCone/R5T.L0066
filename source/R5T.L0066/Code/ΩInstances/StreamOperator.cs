using System;


namespace R5T.L0066
{
    public class StreamOperator : IStreamOperator
    {
        #region Infrastructure

        public static IStreamOperator Instance { get; } = new StreamOperator();


        private StreamOperator()
        {
        }

        #endregion
    }
}
