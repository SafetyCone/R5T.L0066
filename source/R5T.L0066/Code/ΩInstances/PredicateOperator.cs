using System;


namespace R5T.L0066
{
    public class PredicateOperator : IPredicateOperator
    {
        #region Infrastructure

        public static IPredicateOperator Instance { get; } = new PredicateOperator();


        private PredicateOperator()
        {
        }

        #endregion
    }
}
