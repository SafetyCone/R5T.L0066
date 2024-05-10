using System;


namespace R5T.L0066
{
    public class HashSetOperator : IHashSetOperator
    {
        #region Infrastructure

        public static IHashSetOperator Instance { get; } = new HashSetOperator();


        private HashSetOperator()
        {
        }

        #endregion
    }
}
