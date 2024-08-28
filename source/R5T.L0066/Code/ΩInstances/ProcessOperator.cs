using System;


namespace R5T.L0066
{
    public class ProcessOperator : IProcessOperator
    {
        #region Infrastructure

        public static IProcessOperator Instance { get; } = new ProcessOperator();


        private ProcessOperator()
        {
        }

        #endregion
    }
}
