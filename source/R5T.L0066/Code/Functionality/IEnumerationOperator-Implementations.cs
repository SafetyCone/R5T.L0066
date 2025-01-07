using System;
using System.Linq;

using R5T.T0132;


namespace R5T.L0066.Implementations
{
    [FunctionalityMarker]
    public partial interface IEnumerationOperator : IFunctionalityMarker
    {
#pragma warning disable IDE1006 // Naming Styles
        private static L0066.IEnumerationOperator _Root => L0066.EnumerationOperator.Instance;
#pragma warning restore IDE1006 // Naming Styles


        public TEnum[] Get_Values_InstanceMethodsSyntax<TEnum>()
            where TEnum : Enum
        {
            var enumerationType = _Root.Get_EnumerationType<TEnum>();

            var array = _Root.Get_Values(enumerationType);

            var output = Instances.ObjectOperator.As<Array, TEnum[]>(array);
            return output;
        }

        public TEnum[] Get_Values_SimpleSyntax<TEnum>()
        {
            var array = Enum.GetValues(typeof(TEnum));

            var values = array as TEnum[];
            return values;
        }
    }
}
