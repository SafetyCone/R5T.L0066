using System;


namespace R5T.L0066
{
    public class EnumerationOperator : IEnumerationOperator
    {
        #region Infrastructure

        public static IEnumerationOperator Instance { get; } = new EnumerationOperator();


        private EnumerationOperator()
        {
        }

        #endregion
    }
}
