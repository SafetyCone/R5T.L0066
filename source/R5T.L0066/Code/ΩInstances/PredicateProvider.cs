using System;


namespace R5T.L0066
{
    public class PredicateProvider : IPredicateProvider
    {
        #region Infrastructure

        public static IPredicateProvider Instance { get; } = new PredicateProvider();


        private PredicateProvider()
        {
        }

        #endregion
    }
}
