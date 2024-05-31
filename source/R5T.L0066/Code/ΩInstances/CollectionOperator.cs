using System;


namespace R5T.L0066
{
    public class CollectionOperator : ICollectionOperator
    {
        #region Infrastructure

        public static ICollectionOperator Instance { get; } = new CollectionOperator();


        private CollectionOperator()
        {
        }

        #endregion
    }
}
