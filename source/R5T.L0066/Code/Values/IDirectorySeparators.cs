using System;

using R5T.T0131;


namespace R5T.L0066
{
    [ValuesMarker]
    public partial interface IDirectorySeparators : IValuesMarker
    {
        /// <inheritdoc cref="F10Y.L0000.IEnvironmentOperator.Get_DirectorySeparator"/>
        public char Environment => Instances.EnvironmentOperator.Get_DirectorySeparator();

        /// <inheritdoc cref="IEnvironmentOperator.Get_AlternateDirectorySeparator"/>
        public char Environment_Alternate => Instances.EnvironmentOperator.Get_AlternateDirectorySeparator();

        /// <summary>
        /// <para><inheritdoc cref="ICharacters.Slash" path="/summary/descendant::description"/></para>
        /// The non-Windows path directory separator (for Linux and Mac).
        /// </summary>
        public char NonWindows => Instances.Characters.Slash;

        /// <summary>
        /// <para><inheritdoc cref="ICharacters.Backslash" path="/summary/descendant::description"/></para>
        /// The Windows path directory separator.
        /// </summary>
        public char Windows => Instances.Characters.Backslash;


        /// <summary>
        /// The standard is <see cref="Windows"/>.
        /// </summary>
        public char Standard => this.Windows;

        /// <summary>
        /// Both Windows and Non-Windows directory separators.
        /// (<see cref="Windows"/>, <see cref="NonWindows"/>)
        /// </summary>
        private static readonly char[] zBoth = new[] {
            Instances.Characters.Backslash,
            Instances.Characters.Slash
        };

        /// <inheritdoc cref="zBoth"/>
        public char[] Both => IDirectorySeparators.zBoth;
    }
}
