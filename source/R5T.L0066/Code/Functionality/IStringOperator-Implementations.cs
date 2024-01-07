using System;

using R5T.T0132;


namespace R5T.L0066.Implementations
{
    [FunctionalityMarker]
    public partial interface IStringOperator : IFunctionalityMarker
    {
        /// <summary>
        /// Returns the value from <see cref="System.Environment.NewLine"/>.
        /// </summary>
        public string Get_NewLine_ForEnvironment_FromSystem()
        {
            var output = Environment.NewLine;
            return output;
        }

        /// <summary>
        /// Switch on the OSPlatform value from <see cref="IOperatingSystemOperator.Get_OSPlatform"/>.
        /// </summary>
        public string Get_NewLine_ForEnvironment_FromOsPlatformSwitch()
        {
            var output = Instances.OperatingSystemOperator.SwitchOn_OSPlatform(
                Instances.Strings.NewLine_Windows,
                Instances.Strings.NewLine_NonWindows);

            return output;
        }

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

        public bool Is_WhitespaceOnly_Trim(string @string)
        {
            var trimmedString = @string.Trim();

            var output = trimmedString == String.Empty;
            return output;
        }
    }
}
