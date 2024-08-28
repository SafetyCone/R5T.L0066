using System;


namespace R5T.L0066
{
    public class FormatProviders : IFormatProviders
    {
        #region Infrastructure

        public static IFormatProviders Instance { get; } = new FormatProviders();


        private FormatProviders()
        {
        }

        #endregion
    }
}
