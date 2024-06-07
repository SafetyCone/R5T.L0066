using System;


namespace R5T.L0066
{
    public class BytesOperator : IBytesOperator
    {
        #region Infrastructure

        public static IBytesOperator Instance { get; } = new BytesOperator();


        private BytesOperator()
        {
        }

        #endregion
    }
}
