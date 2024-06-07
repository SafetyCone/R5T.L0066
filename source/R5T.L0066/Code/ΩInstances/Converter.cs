using System;


namespace R5T.L0066
{
    public class Converter : IConverter
    {
        #region Infrastructure

        public static IConverter Instance { get; } = new Converter();


        private Converter()
        {
        }

        #endregion
    }
}
