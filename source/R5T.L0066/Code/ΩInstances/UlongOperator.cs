using System;


namespace R5T.L0066
{
    public class UlongOperator : IUlongOperator
    {
        #region Infrastructure

        public static IUlongOperator Instance { get; } = new UlongOperator();


        private UlongOperator()
        {
        }

        #endregion
    }
}
