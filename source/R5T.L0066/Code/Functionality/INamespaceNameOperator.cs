using System;

using R5T.T0132;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface INamespaceNameOperator : IFunctionalityMarker
    {
        public string[] Get_Tokens(string namespaceName)
        {
            var output = Instances.StringOperator.Split(
                Instances.Values.NamespaceNameTokenSeparator,
                namespaceName);

            return output;
        }
    }
}
