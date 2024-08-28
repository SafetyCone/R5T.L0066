using System;


namespace R5T.L0066
{
    public class HttpRequestMessageOperator : IHttpRequestMessageOperator
    {
        #region Infrastructure

        public static IHttpRequestMessageOperator Instance { get; } = new HttpRequestMessageOperator();


        private HttpRequestMessageOperator()
        {
        }

        #endregion
    }
}
