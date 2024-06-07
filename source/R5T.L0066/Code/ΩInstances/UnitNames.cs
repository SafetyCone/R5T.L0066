using System;


namespace R5T.L0066
{
    public class UnitNames : IUnitNames
    {
        #region Infrastructure

        public static IUnitNames Instance { get; } = new UnitNames();


        private UnitNames()
        {
        }

        #endregion
    }
}


namespace R5T.L0066.Raw
{
    public class UnitNames : IUnitNames
    {
        #region Infrastructure

        public static IUnitNames Instance { get; } = new UnitNames();


        private UnitNames()
        {
        }

        #endregion
    }
}