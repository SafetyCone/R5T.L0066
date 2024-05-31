using System;


namespace R5T.L0066
{
    public class XmlWriterOperator : IXmlWriterOperator
    {
        #region Infrastructure

        public static IXmlWriterOperator Instance { get; } = new XmlWriterOperator();


        private XmlWriterOperator()
        {
        }

        #endregion
    }
}
