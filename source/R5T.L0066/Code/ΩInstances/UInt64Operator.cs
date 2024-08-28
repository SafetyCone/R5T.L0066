using System;


namespace R5T.L0066
{
    public class UInt64Operator : IUInt64Operator
    {
        #region Infrastructure

        public static IUInt64Operator Instance { get; } = new UInt64Operator();


        private UInt64Operator()
        {
        }

        #endregion
    }
}
