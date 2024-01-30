using System;

using R5T.T0132;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface ITypeNameOperator : IFunctionalityMarker
    {
        public string Get_TypeNameOf<T>(T instance)
        {
            var output = Instances.TypeOperator.Get_TypeNameOf(instance);
            return output;
        }
    }
}
