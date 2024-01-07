using System;


namespace R5T.L0066
{
    public class ReadOnlyListOperator : IReadOnlyListOperator
    {
        #region Infrastructure

        public static IReadOnlyListOperator Instance { get; } = new ReadOnlyListOperator();


        private ReadOnlyListOperator()
        {
        }

        #endregion
    }
}
