using System;


namespace R5T.L0066
{
    public class UnitSymbols : IUnitSymbols
    {
        #region Infrastructure

        public static IUnitSymbols Instance { get; } = new UnitSymbols();


        private UnitSymbols()
        {
        }

        #endregion
    }
}


namespace R5T.L0066.Raw
{
    public class UnitSymbols : IUnitSymbols
    {
        #region Infrastructure

        public static IUnitSymbols Instance { get; } = new UnitSymbols();


        private UnitSymbols()
        {
        }

        #endregion
    }
}