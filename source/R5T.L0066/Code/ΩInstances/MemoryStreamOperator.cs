using System;


namespace R5T.L0066
{
    public class MemoryStreamOperator : IMemoryStreamOperator
    {
        #region Infrastructure

        public static IMemoryStreamOperator Instance { get; } = new MemoryStreamOperator();


        private MemoryStreamOperator()
        {
        }

        #endregion
    }
}
