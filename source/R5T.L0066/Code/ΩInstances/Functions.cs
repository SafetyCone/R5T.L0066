using System;


namespace R5T.L0066
{
    public class Functions : IFunctions
    {
        #region Infrastructure

        public static IFunctions Instance { get; } = new Functions();


        private Functions()
        {
        }

        #endregion
    }
}
