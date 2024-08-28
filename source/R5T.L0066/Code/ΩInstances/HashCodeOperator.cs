using System;


namespace R5T.L0066
{
    public class HashCodeOperator : IHashCodeOperator
    {
        #region Infrastructure

        public static IHashCodeOperator Instance { get; } = new HashCodeOperator();


        private HashCodeOperator()
        {
        }

        #endregion
    }
}
