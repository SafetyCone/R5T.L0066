using System;


namespace R5T.L0066
{
    public class PropertyNames : IPropertyNames
    {
        #region Infrastructure

        public static IPropertyNames Instance { get; } = new PropertyNames();


        private PropertyNames()
        {
        }

        #endregion
    }
}
