using System;


namespace R5T.L0066
{
    public class ObjectOperator : IObjectOperator
    {
        #region Infrastructure

        public static IObjectOperator Instance { get; } = new ObjectOperator();


        private ObjectOperator()
        {
        }

        #endregion
    }
}
