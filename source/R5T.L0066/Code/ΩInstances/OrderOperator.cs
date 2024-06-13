using System;


namespace R5T.L0066
{
    public class OrderOperator : IOrderOperator
    {
        #region Infrastructure

        public static IOrderOperator Instance { get; } = new OrderOperator();


        private OrderOperator()
        {
        }

        #endregion
    }
}
