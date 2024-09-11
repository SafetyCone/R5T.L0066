using System;


namespace R5T.L0066
{
    public class Predicates : IPredicates
    {
        #region Infrastructure

        public static IPredicates Instance { get; } = new Predicates();


        private Predicates()
        {
        }

        #endregion
    }



    public class Predicates<T> : IPredicates<T>
    {
        #region Infrastructure

        public static IPredicates<T> Instance { get; } = new Predicates<T>();


        private Predicates()
        {
        }

        #endregion
    }
}
