using System;

using R5T.T0132;


namespace R5T.L0066.Implementations
{
    [FunctionalityMarker]
    public partial interface IStringOperator : IFunctionalityMarker
    {
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
