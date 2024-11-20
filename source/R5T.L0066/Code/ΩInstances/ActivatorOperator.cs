using System;


namespace R5T.L0066
{
    public class ActivatorOperator : IActivatorOperator
    {
        #region Infrastructure

        public static IActivatorOperator Instance { get; } = new ActivatorOperator();


        private ActivatorOperator()
        {
        }

        #endregion
    }
}
