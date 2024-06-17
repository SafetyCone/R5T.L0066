using System;


namespace R5T.L0066
{
    public class TypeInfoOperator : ITypeInfoOperator
    {
        #region Infrastructure

        public static ITypeInfoOperator Instance { get; } = new TypeInfoOperator();


        private TypeInfoOperator()
        {
        }

        #endregion
    }
}
