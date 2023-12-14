using System;


namespace R5T.L0066
{
    public class Actions : IActions
    {
        #region Infrastructure

        public static IActions Instance { get; } = new Actions();


        private Actions()
        {
        }

        #endregion
    }
}
