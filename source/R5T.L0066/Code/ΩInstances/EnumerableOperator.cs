using System;


namespace R5T.L0066
{
    public class EnumerableOperator : IEnumerableOperator
    {
        #region Infrastructure

        public static IEnumerableOperator Instance { get; } = new EnumerableOperator();


        private EnumerableOperator()
        {
        }

        #endregion
    }
}


namespace R5T.L0066.Implementations
{
    public class EnumerableOperator : IEnumerableOperator
    {
        #region Infrastructure

        public static IEnumerableOperator Instance { get; } = new EnumerableOperator();


        private EnumerableOperator()
        {
        }

        #endregion
    }
}