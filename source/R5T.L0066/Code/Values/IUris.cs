using System;

using R5T.T0131;


namespace R5T.L0066
{
    [ValuesMarker]
    public partial interface IUris : IValuesMarker
    {
        public Uri FileScheme => Instances.UriOperator.From(
            Instances.UriSchemes.File);
    }
}
