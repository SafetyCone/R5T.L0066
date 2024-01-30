using System;


namespace R5T.L0066
{
    public class TupleOperator : ITupleOperator
    {
        #region Infrastructure

        public static ITupleOperator Instance { get; } = new TupleOperator();


        private TupleOperator()
        {
        }

        #endregion
    }
}
