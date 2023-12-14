using System;


namespace R5T.L0066
{
    public class Indices : IIndices
    {
        #region Infrastructure

        public static IIndices Instance { get; } = new Indices();


        private Indices()
        {
        }

        #endregion
    }
}
