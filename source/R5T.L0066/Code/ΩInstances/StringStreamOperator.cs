using System;


namespace R5T.L0066
{
    public class StringStreamOperator : IStringStreamOperator
    {
        #region Infrastructure

        public static IStringStreamOperator Instance { get; } = new StringStreamOperator();


        private StringStreamOperator()
        {
        }

        #endregion
    }
}
