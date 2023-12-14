using System;


namespace R5T.L0066
{
    public class NewLineOperator : INewLineOperator
    {
        #region Infrastructure

        public static INewLineOperator Instance { get; } = new NewLineOperator();


        private NewLineOperator()
        {
        }

        #endregion
    }
}
