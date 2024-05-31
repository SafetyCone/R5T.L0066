using System;


namespace R5T.L0066
{
    public class OSPlatforms : IOSPlatforms
    {
        #region Infrastructure

        public static IOSPlatforms Instance { get; } = new OSPlatforms();


        private OSPlatforms()
        {
        }

        #endregion
    }
}
