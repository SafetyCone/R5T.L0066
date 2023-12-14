using System;


namespace R5T.L0066
{
    public class XTextOperator : IXTextOperator
    {
        #region Infrastructure

        public static IXTextOperator Instance { get; } = new XTextOperator();


        private XTextOperator()
        {
        }

        #endregion
    }
}
