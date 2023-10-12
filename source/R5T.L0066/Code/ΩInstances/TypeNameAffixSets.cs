using System;


namespace R5T.L0066
{
    public class TypeNameAffixSets : ITypeNameAffixSets
    {
        #region Infrastructure

        public static ITypeNameAffixSets Instance { get; } = new TypeNameAffixSets();


        private TypeNameAffixSets()
        {
        }

        #endregion
    }
}
