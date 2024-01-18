using System;


namespace R5T.L0066
{
    public class ContextOperations : IContextOperations
    {
        #region Infrastructure

        public static IContextOperations Instance { get; } = new ContextOperations();


        private ContextOperations()
        {
        }

        #endregion
    }
}
