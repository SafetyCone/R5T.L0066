using System;


namespace R5T.L0066
{
    public class XmlTextOperator : IXmlTextOperator
    {
        #region Infrastructure

        public static IXmlTextOperator Instance { get; } = new XmlTextOperator();


        private XmlTextOperator()
        {
        }

        #endregion
    }
}
