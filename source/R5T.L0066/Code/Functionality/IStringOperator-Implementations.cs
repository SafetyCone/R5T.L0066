using System;

using R5T.T0132;


namespace R5T.L0066.Implementations
{
    [FunctionalityMarker]
    public partial interface IStringOperator : IFunctionalityMarker
    {
        /// <inheritdoc cref="L0066.IStringOperator.Get_NewLine_ForEnvironment" path="/summary"/>
        /// <remarks>
        /// Returns the value from <see cref="System.Environment.NewLine"/>.
        /// </remarks>
        public string Get_NewLine_ForEnvironment_FromSystem()
            => Instances.EnvironmentOperator.Get_NewLine();

        /// <inheritdoc cref="L0066.IStringOperator.Get_NewLine_ForEnvironment" path="/summary"/>
        /// <remarks>
        /// Switch on the OSPlatform value from <see cref="IOperatingSystemOperator.Get_OSPlatform"/>.
        /// </remarks>
        public string Get_NewLine_ForEnvironment_FromOsPlatformSwitch()
        {
            var output = Instances.OperatingSystemOperator.SwitchOn_OSPlatform(
                Instances.Strings.NewLine_Windows,
                Instances.Strings.NewLine_NonWindows);

            return output;
        }

        /// <inheritdoc cref="L0066.IStringOperator.Is_WhitespaceOnly(string)" path="/summary"/>
        /// <remarks>
        /// Works by testing each character against <see cref="ICharacterOperator.Is_NotWhitespace(char)"/>,
        /// and if any are not whitespacer, returns false.
        /// Otherwise, returns true.
        /// </remarks>
        public bool Is_WhitespaceOnly_CheckCharacters(string @string)
        {
            foreach (var character in @string)
            {
                var isNotWhitespace = Instances.CharacterOperator.Is_NotWhitespace(character);
                if (isNotWhitespace)
                {
                    return false;
                }
            }

            return true;
        }

        /// <inheritdoc cref="L0066.IStringOperator.Is_WhitespaceOnly(string)" path="/summary"/>
        /// <remarks>
        /// Works by trimming the string, then testing if the trimmed string equals the empty string.
        /// </remarks>
        public bool Is_WhitespaceOnly_Trim(string @string)
        {
            var trimmedString = @string.Trim();

            var output = trimmedString == String.Empty;
            return output;
        }
    }
}
