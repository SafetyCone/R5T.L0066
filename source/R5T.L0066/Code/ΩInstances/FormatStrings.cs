using System;


namespace R5T.L0066
{
    public class FormatStrings : IFormatStrings
    {
        #region Infrastructure

        public static IFormatStrings Instance { get; } = new FormatStrings();


        private FormatStrings()
        {
        }

        #endregion
    }
}


namespace R5T.L0066.Raw
{
    public class FormatStrings : IFormatStrings
    {
        #region Infrastructure

        public static IFormatStrings Instance { get; } = new FormatStrings();


        private FormatStrings()
        {
        }

        #endregion
    }
}