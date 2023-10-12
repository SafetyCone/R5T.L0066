using System;

using R5T.T0131;


namespace R5T.L0066
{
    [ValuesMarker]
    public partial interface ITypeNameAffixSets : IValuesMarker
    {
        public string[] All_Strings => new[]
        {
            Instances.TypeNameAffixes.Array_Suffix,
            Instances.TypeNameAffixes.ByReference_Suffix_String,
            Instances.TypeNameAffixes.Pointer_Suffix_String
        };
    }
}
