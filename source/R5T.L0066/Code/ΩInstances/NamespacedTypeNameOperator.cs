using System;


namespace R5T.L0066
{
    public class NamespacedTypeNameOperator : INamespacedTypeNameOperator
    {
        #region Infrastructure

        public static INamespacedTypeNameOperator Instance { get; } = new NamespacedTypeNameOperator();


        private NamespacedTypeNameOperator()
        {
        }

        #endregion
    }
}
