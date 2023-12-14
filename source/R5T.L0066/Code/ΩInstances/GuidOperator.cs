using System;


namespace R5T.L0066
{
    public class GuidOperator : IGuidOperator
    {
        #region Infrastructure

        public static IGuidOperator Instance { get; } = new GuidOperator();


        private GuidOperator()
        {
        }

        #endregion
    }
}
