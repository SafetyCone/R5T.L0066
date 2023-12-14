using System;


namespace R5T.L0066
{
    public class IndexOperator : IIndexOperator
    {
        #region Infrastructure

        public static IIndexOperator Instance { get; } = new IndexOperator();


        private IndexOperator()
        {
        }

        #endregion
    }
}
