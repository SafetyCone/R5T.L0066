using System;


namespace R5T.L0066
{
    public class ConstructionOperator : IConstructionOperator
    {
        #region Infrastructure

        public static IConstructionOperator Instance { get; } = new ConstructionOperator();


        private ConstructionOperator()
        {
        }

        #endregion
    }
}
