using System;


namespace R5T.L0066
{
    public class HttpResponseMessageOperator : IHttpResponseMessageOperator
    {
        #region Infrastructure

        public static IHttpResponseMessageOperator Instance { get; } = new HttpResponseMessageOperator();


        private HttpResponseMessageOperator()
        {
        }

        #endregion
    }
}
