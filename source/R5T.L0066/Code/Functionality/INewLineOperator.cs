using System;

using R5T.T0132;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface INewLineOperator : IFunctionalityMarker
    {
        public string Prefix(string line)
        {
            var output = Instances.StringOperator.PrefixWith(
                Instances.Strings.NewLine,
                line);

            return output;
        }
    }
}
