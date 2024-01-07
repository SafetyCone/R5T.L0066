using System;


namespace R5T.L0066
{
    public class MessageOperator : IMessageOperator
    {
        #region Infrastructure

        public static IMessageOperator Instance { get; } = new MessageOperator();


        private MessageOperator()
        {
        }

        #endregion
    }
}
