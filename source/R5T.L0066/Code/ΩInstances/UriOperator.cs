using System;


namespace R5T.L0066
{
    public class UriOperator : IUriOperator
    {
        #region Infrastructure

        public static IUriOperator Instance { get; } = new UriOperator();


        private UriOperator()
        {
        }

        #endregion
    }
}
