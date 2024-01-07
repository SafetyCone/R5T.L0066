using System;
using System.Collections.Generic;
using System.Linq;

using R5T.T0132;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface IStringOperator : IFunctionalityMarker
    {
#pragma warning disable IDE1006 // Naming Styles
        private static Implementations.IStringOperator _Implementations => Implementations.StringOperator.Instance;
#pragma warning restore IDE1006 // Naming Styles


        public string Append(
            string @string,
            char character)
        {
            var output = @string + character;
            return output;
        }

        public string Append(
            string @string,
            string appendix)
        {
            var output = @string + appendix;
            return output;
        }

        /// <summary>
        /// Converts \r\n and \r to \n.
        /// </summary>
        /// <remarks>
        /// This is useful in several contexts (file new line conversion, string to XML text conversion - where the XML reader converts \r and \r\n to \n because the XML standard
        /// demands it, etc.).
        /// <para>For the reverse operation, see <see cref="Convert_NewLines_ToCarriageReturnNewLines(string)"/>.</para>
        /// </remarks>
        public string Convert_CarriageReturns_ToNewLines(string @string)
        {
            var output = @string
                // Replace \r\n first before lone \r values to avoid adding multiple new lines.
                .Replace("\r\n", "\n")
                // Replace \r second after \r\n values to avoid adding multiple new lines.
                .Replace("\r", "\n")
                ;

            return output;
        }

        /// <summary>
        /// Converts \n to \r\n.
        /// </summary>
        /// <remarks>
        /// This is useful in the context of converting non-Windows file line-endings to Windows file line-endings.
        /// <para>For the reverse operation, see <see cref="Convert_CarriageReturns_ToNewLines(string)"/>.</para>
        /// </remarks>
        public string Convert_NewLines_ToCarriageReturnNewLines(string @string)
        {
            var output = @string
                .Replace("\n", "\r\n")
                ;

            return output;
        }

        public string Enquote(string @string)
        {
            var output = $"\"{@string}\"";
            return output;
        }

        /// <summary>
        /// Returns the character at the provided index.
        /// </summary>
        public char Get_Character(
            string @string,
            int index)
        {
            var output = @string[index];
            return output;
        }

        /// <summary>
        /// The default <see cref="System.String.GetHashCode()"/> is non-deterministic.
        /// This method just calls that method.
        /// </summary>
        public int GetHashCode_NonDeterministic(string @string)
        {
            var output = @string.GetHashCode();
            return output;
        }

        /// <summary>
        /// The default <see cref="System.String.GetHashCode()"/> is non-deterministic.
        /// This method provides a deterministic implementation.
        /// </summary>
        /// <remarks>
        /// Source: https://andrewlock.net/why-is-string-gethashcode-different-each-time-i-run-my-program-in-net-core/#a-deterministic-gethashcode-implementation
        /// </remarks>
        public int GetHashCode_Deterministic(string @string)
        {
            unchecked
            {
                int hash1 = (5381 << 16) + 5381;
                int hash2 = hash1;

                for (int i = 0; i < @string.Length; i += 2)
                {
                    hash1 = ((hash1 << 5) + hash1) ^ @string[i];

                    if (i == @string.Length - 1)
                        break;

                    hash2 = ((hash2 << 5) + hash2) ^ @string[i + 1];
                }

                return hash1 + (hash2 * 1566083941);
            }
        }

        /// <summary>
        /// Gets the first index at which one of the provided characters is found.
        /// </summary>
        public int Get_IndexOfAny_OrNotFound(
            string @string,
            params char[] characters)
        {
            var output = @string.IndexOfAny(characters);
            return output;
        }

        public int Get_IndexOfAny_OrNotFound(
            string @string,
            string[] searchStrings)
        {
            foreach (var searchString in searchStrings)
            {
                var index = @string.IndexOf(searchString);

                var wasFound = this.Was_Found(index);
                if (wasFound)
                {
                    return index;
                }
            }

            return Instances.Indices.NotFound;
        }

        public int Get_IndexOf(
            string @string,
            char character)
        {
            var indexOfOrNotFound = this.Get_IndexOf_OrNotFound(
                @string,
                character);

            this.Verify_IsFound(indexOfOrNotFound, character);

            return indexOfOrNotFound;
        }

        public int Get_IndexOf_OrNotFound(
            string @string,
            char character)
        {
            var output = @string.IndexOf(character);
            return output;
        }

        public string Get_LastNCharacters(
            string @string,
            int numberOfCharacters)
        {
            var output = @string[^numberOfCharacters..];
            return output;
        }

        /// <summary>
        /// Gets the new line string for the currently executing environment.
        /// </summary>
        public string Get_NewLine_ForEnvironment()
        {
            var output = _Implementations.Get_NewLine_ForEnvironment_FromSystem();
            return output;
        }

        public string Get_Substring_From_Inclusive_To_Inclusive(
            int startIndex,
            int endIndex,
            string @string)
        {
            var length = Instances.IndexOperator.Get_Count_Inclusive_Inclusive(
                startIndex,
                endIndex);

            var output = this.Get_Substring_From_Inclusive(
                startIndex,
                length,
                @string);

            return output;
        }

        public string Get_Substring_From_Exclusive_To_Exclusive(
            int startIndex,
            int endIndex,
            string @string)
        {
            var length = Instances.IndexOperator.Get_Count_Exclusive_Exclusive(
                startIndex,
                endIndex);

            var output = this.Get_Substring_From_Exclusive(
                startIndex,
                length,
                @string);

            return output;
        }

        public string Get_Substring_From_Inclusive(
            int startIndex,
            int length,
            string @string)
        {
            var output = @string.Substring(startIndex, length);
            return output;
        }

        public string Get_Substring_From_Exclusive(
            int startIndex,
            int length,
            string @string)
        {
            var actualStartIndex = startIndex + 1;

            var output = this.Get_Substring_From_Inclusive(
                actualStartIndex,
                length,
                @string);

            return output;
        }

        public string Get_Substring_From_Exclusive(
            char character,
            string @string)
        {
            var indexOfCharacter = this.Get_IndexOf(
                @string,
                character);

            var output = this.Get_Substring_From_Exclusive(
                indexOfCharacter,
                @string);

            return output;
        }

        /// <summary>
        /// Gets a substring, starting at an index and going to the end.
        /// </summary>
        public string Get_Substring_From_Exclusive(
            int startIndex_Exclusive,
            string @string)
        {
            var output = @string[(startIndex_Exclusive + 1)..];
            return output;
        }

        public string Get_Substring_From_Inclusive(
            int startIndex_Exclusive,
            string @string)
        {
            var output = @string[startIndex_Exclusive..];
            return output;
        }

        public string Get_Substring_Upto_Inclusive(
            int endIndex_Inclusive,
            string @string)
        {
            var output = @string[..(endIndex_Inclusive + 1)];
            return output;
        }

        public string Get_Substring_Upto_Exclusive(
            int endIndex_Exclusive,
            string @string)
        {
            var output = @string[..endIndex_Exclusive];
            return output;
        }

        /// <summary>
        /// Gets the last character of a string.
        /// </summary>
        public char Get_LastCharacter(string @string)
        {
            var output = @string[^1];
            return output;
        }

        /// <summary>
        /// Returns the last index of the specified character within the string,
        /// or if the character is not found, throws an exception.
        /// </summary>
        public int Get_LastIndexOf(char character, string @string)
        {
            var indexOrNotFound = this.Get_LastIndexOf_OrNotFound(
                character,
                @string);

            this.Verify_IsFound(indexOrNotFound, character);

            return indexOrNotFound;
        }

        /// <summary>
        /// Returns the last index of the specified character within the string,
        /// or if the character is not found, returns <see cref="IIndices.NotFound"/>.
        /// </summary>
        public int Get_LastIndexOf_OrNotFound(
            char character,
            string @string)
        {
            var output = @string.LastIndexOf(character);
            return output;
        }

        /// <summary>
        /// Gets the last index at which one of the provided characters is found.
        /// </summary>
        public int Get_LastIndexOfAny_OrNotFound(
            string @string,
            params char[] characters)
        {
            var output = @string.LastIndexOfAny(characters);
            return output;
        }

        public int Get_LastIndexOfAny(
            string @string,
            params char[] characters)
        {
            var lastIndexOfAny_OrNotFound = this.Get_LastIndexOfAny_OrNotFound(
                @string,
                characters);

            this.Verify_IsFound_Any(lastIndexOfAny_OrNotFound, characters);

            return lastIndexOfAny_OrNotFound;
        }

        /// <summary>
        /// Returns the last index of the specified character within the string,
        /// or if the character is not found, returns <see cref="IIndices.NotFound"/>.
        /// </summary>
        public int Get_LastIndexOf_OrNotFound(
            char character,
            string @string,
            int startIndexInclusive)
        {
            var subString = this.Get_Substring_From_Inclusive(
                startIndexInclusive,
                @string);

            var indexInSubstring = this.Get_LastIndexOf_OrNotFound(
                character,
                subString);
            if (!this.Is_Found(indexInSubstring))
            {
                return Instances.Indices.NotFound;
            }

            var output = startIndexInclusive + indexInSubstring;
            return output;
        }

        /// <summary>
        /// Determines if the input is specifically the <see cref="IStrings.Empty"/> string.
        /// </summary>
        public bool Is_Empty(string value)
        {
            var isEmpty = value == Instances.Strings.Empty;
            return isEmpty;
        }

        public bool Is_Found(int index)
        {
            return Instances.IndexOperator.Is_Found(index);
        }

        public bool Is_Null(string @string)
        {
            // Use  instead of:
            // * == null - Equality operator eventually just uses Object.ReferenceEquals().
            // * Object.Equals() - Should be Object.ReferenceEquals() instead.
            // * Object.ReferenceEquals() - IDE0041 message is produced, indicating preference for "is null".
            var output = @string is null;
            return output;
        }

        public bool Is_NotNullOrEmpty(string @string)
        {
            var isNullOrEmpty = this.Is_NullOrEmpty(@string);

            var output = !isNullOrEmpty;
            return output;
        }

        public bool Is_NullOrEmpty(string @string)
        {
            var output = System.String.IsNullOrEmpty(@string);
            return output;
        }

        /// <summary>
        /// Quality-of-life overload for <see cref="Is_WhitespaceOnly(string)"/>.
        /// </summary>
        public bool Is_Whitespace(string @string)
        {
            var output = this.Is_WhitespaceOnly(@string);
            return output;
        }

        public bool Is_WhitespaceOnly(string @string)
        {
            var output = _Implementations.Is_WhitespaceOnly_Trim(@string);
            return output;
        }

        public string Join(
            char separator,
            IEnumerable<char> characters)
        {
            var output = System.String.Join(separator, characters);
            return output;
        }

        public string Join(
            char separator,
            params char[] characters)
        {
            var output = this.Join(
                separator,
                characters.AsEnumerable());

            return output;
        }

        public string Join(
            char separator,
            IEnumerable<string> strings)
        {
            var output = System.String.Join(separator, strings);
            return output;
        }

        public string Join(
            char separator,
            params string[] strings)
        {
            var output = this.Join(separator, strings.AsEnumerable());
            return output;
        }

        public string Join(
            string separator,
            IEnumerable<string> strings)
        {
            var output = System.String.Join(separator, strings);
            return output;
        }

        public string Join(
            string separator,
            params string[] strings)
        {
            var output = this.Join(separator, strings.AsEnumerable());
            return output;
        }

        public string Join(
            string separator,
            IEnumerable<char> characters)
        {
            var output = System.String.Join(separator, characters);
            return output;
        }

        public string Join(
            string separator,
            params char[] characters)
        {
            var output = this.Join(
                separator,
                characters.AsEnumerable());

            return output;
        }

        public string Join(IEnumerable<string> strings)
        {
            var output = this.Join(
                Instances.Strings.Empty,
                strings);

            return output;
        }

        public string Join(params string[] strings)
        {
            var output = this.Join(strings.AsEnumerable());
            return output;
        }

        public string Join_AsList(IEnumerable<char> characters)
        {
            var output = this.Join(
                Instances.Strings.CommaSpaceSeparatedListSeparator,
                characters);

            return output;
        }

        public string Join_AsList(params char[] characters)
        {
            var output = this.Join_AsList(characters.AsEnumerable());
            return output;
        }

        public string PrefixWith(
            string prefix,
            string @string)
        {
            var output = prefix + @string;
            return output;
        }

        public string Repeat(char character, int count)
        {
            var output = new string(character, count);
            return output;
        }

        public string Repeat(string @string, int count)
        {
            var strings = Instances.EnumerableOperator.Repeat(
                @string,
                count);

            var output = this.Join(strings);
            return output;
        }

        public string[] Split(
            char separator,
            string @string,
            StringSplitOptions options = StringSplitOptions.None)
        {
            var output = @string.Split(separator, options);
            return output;
        }

        public string[] Split(
            string separator,
            string @string,
            StringSplitOptions options = StringSplitOptions.None)
        {
            var output = @string.Split(separator, options);
            return output;
        }

        public void Verify_IsFound(
            int index,
            char character)
        {
            var isFound = Instances.IndexOperator.Is_Found(index);
            if (!isFound)
            {
                throw new Exception($"'{character}' was not found.");
            }
        }

        public void Verify_IsFound_Any(
            int index,
            params char[] characters)
        {
            var isFound = Instances.IndexOperator.Is_Found(index);
            if (!isFound)
            {
                var charactersList = this.Join_AsList(characters);

                throw new Exception($"None of the characters [{charactersList}] were found.");
            }
        }

        public void Verify_IsFound<TException>(
            int index,
            Func<TException> exceptionConstructor)
            where TException : Exception
        {
            var isFound = Instances.IndexOperator.Is_Found(index);
            if (!isFound)
            {
                var exception = exceptionConstructor();

                throw exception;
            }
        }

        public void Verify_IsNotNullOrEmpty(string value)
        {
            var isNullOrEmpty = this.Is_NullOrEmpty(value);
            if(isNullOrEmpty)
            {
                throw new Exception("String was null or empty.");
            }
        }

        public bool Was_Found(int index)
        {
            return Instances.IndexOperator.Was_Found(index);
        }
    }
}
