using System;


namespace R5T.L0066
{
    public class GuidStrings : IGuidStrings
    {
        #region Infrastructure

        public static IGuidStrings Instance { get; } = new GuidStrings();


        private GuidStrings()
        {
        }

        #endregion
    }
}


namespace R5T.L0066.Raw
{
    public class GuidStrings : IGuidStrings
    {
        #region Infrastructure

        public static IGuidStrings Instance { get; } = new GuidStrings();


        private GuidStrings()
        {
        }

        #endregion
    }
}