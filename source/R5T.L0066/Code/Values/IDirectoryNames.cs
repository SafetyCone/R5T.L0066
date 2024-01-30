using System;

using R5T.T0131;


namespace R5T.L0066
{
    [ValuesMarker]
    public partial interface IDirectoryNames : IValuesMarker
    {
        /// <inheritdoc cref="IStrings.Period"/>
        public string CurrentDirectory => Instances.Strings.Period;

        /// <inheritdoc cref="IStrings.DoubleDot"/>
        public string ParentDirectory => Instances.Strings.DoubleDot;
    }
}
