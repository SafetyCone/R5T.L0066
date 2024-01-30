using System;

using R5T.T0131;


namespace R5T.L0066
{
    [ValuesMarker]
    public partial interface IPathSeparators : IValuesMarker
    {
        /// <inheritdoc cref="ICharacters.Colon"/>
        public char VolumeSeparator => Instances.Characters.Colon;
    }
}
