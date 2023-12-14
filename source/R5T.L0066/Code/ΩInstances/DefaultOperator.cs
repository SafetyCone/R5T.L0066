using System;


namespace R5T.L0066
{
    public class DefaultOperator : IDefaultOperator
    {
        #region Infrastructure

        public static IDefaultOperator Instance { get; } = new DefaultOperator();


        private DefaultOperator()
        {
        }

        #endregion
    }
}
