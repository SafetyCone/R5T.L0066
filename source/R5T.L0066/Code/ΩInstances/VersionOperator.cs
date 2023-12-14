using System;


namespace R5T.L0066
{
    public class VersionOperator : IVersionOperator
    {
        #region Infrastructure

        public static IVersionOperator Instance { get; } = new VersionOperator();


        private VersionOperator()
        {
        }

        #endregion
    }
}
