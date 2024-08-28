using System;


namespace R5T.L0066
{
    public class NamespacedTypeNames : INamespacedTypeNames
    {
        #region Infrastructure

        public static INamespacedTypeNames Instance { get; } = new NamespacedTypeNames();


        private NamespacedTypeNames()
        {
        }

        #endregion
    }
}
