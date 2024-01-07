using System;


namespace R5T.L0066
{
    public class ListOperator : IListOperator
    {
        #region Infrastructure

        public static IListOperator Instance { get; } = new ListOperator();


        private ListOperator()
        {
        }

        #endregion
    }
}


namespace R5T.L0066.Implementations
{
    public class ListOperator : IListOperator
    {
        #region Infrastructure

        public static IListOperator Instance { get; } = new ListOperator();


        private ListOperator()
        {
        }

        #endregion
    }
}
