using System;


namespace R5T.L0066
{
    public class ActionOperator : IActionOperator
    {
        #region Infrastructure

        public static IActionOperator Instance { get; } = new ActionOperator();


        private ActionOperator()
        {
        }

        #endregion
    }
}
