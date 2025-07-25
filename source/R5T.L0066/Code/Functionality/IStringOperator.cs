using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using R5T.T0132;
using R5T.T0143;

using R5T.L0066.Extensions;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface IStringOperator : IFunctionalityMarker,
        F10Y.L0000.IStringOperator
    {
#pragma warning disable IDE1006 // Naming Styles

        [Ignore]
        public F10Y.L0000.IStringOperator _F10Y_L0000 => F10Y.L0000.StringOperator.Instance;

        [Ignore]
        public Internal.IStringOperator _Internal => Internal.StringOperator.Instance;

        [Ignore]
        public new Implementations.IStringOperator _Implementations => Implementations.StringOperator.Instance;

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

        public IEnumerable<string> Append_BlankLine(IEnumerable<string> lines)
            => Instances.EnumerableOperator.Append(
                lines,
                Instances.Strings.Empty);

        /// <summary>
        /// Quality-of-life overload for <see cref="StartsWith(string, string)"/>.
        /// </summary>
        public bool BeginsWith(string @string, string start)
        {
            var output = this.StartsWith(@string, start);
            return output;
        }

        public string Concatenate(
            string a,
            string b)
        {
            var output = a + b;
            return output;
        }

        public bool Contains(
            string @string,
            string subString,
            bool ignoreCapitalization)
            => ignoreCapitalization
            ? this.Contains_IgnoreCase(
                @string,
                subString)
            : this.Contains_ConsiderCase(
                @string,
                subString)
            ;

        public bool ContainsAny(
            string @string,
            string[] searchStrings)
        {
            var index = this.Get_IndexOfAny_OrNotFound(
                @string,
                searchStrings);

            var wasFound = this.Was_Found(index);
            return wasFound;
        }

        public bool ContainsAny(
            string @string,
            char[] searchCharacters)
        {
            var index = this.Get_IndexOfAny_OrNotFound(
                @string,
                searchCharacters);

            var wasFound = this.Was_Found(index);
            return wasFound;
        }

        /// <summary>
        /// Chooses <see cref="F10Y.L0000.IStringOperator.Contains_ConsiderCase(string, string)"/> as the default.
        /// </summary>
        public bool Contains(
            string @string,
            string subString)
            => this.Contains_ConsiderCase(
                @string,
                subString);

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

        public int CountOf(
            char character,
            string @string)
        {
            var output = @string
                .Where(c => c == character)
                .Count();

            return output;
        }

        public string Empty_IfNull(string @string)
        {
            var isNull = this.Is_Null(@string);

            var output = isNull
                ? Instances.Strings.Empty
                : @string
                ;

            return output;
        }

        /// <summary>
        /// Note: supports endings that are longer than the string (returns false).
        /// </summary>
        public bool EndsWith(
            string @string,
            string ending)
        {
            var endingLength = ending.Length;

            var stringLength = @string.Length;
            var stringIsLongEnough = stringLength >= endingLength;
            if (!stringIsLongEnough)
            {
                return false;
            }

            var stringEnding = this.Get_LastNCharacters(
                @string,
                endingLength);

            var output = stringEnding == ending;
            return output;
        }

        public string Enquote(string @string)
        {
            var output = $"\"{@string}\"";
            return output;
        }

        public string Ensure_StartsWith(
            string @string,
            char start)
        {
            var firstChar = @string.Get_Character_First();

            var hasStart = firstChar == start;

            var output = hasStart
                ? @string
                : start + @string
                ;

            return output;  
        }

        public string Ensure_EndsWith(
            string @string,
            char end)
        {
            var lastChar = @string.Get_Character_Last();

            var hasEnd = lastChar == end;

            var output = hasEnd
                ? @string
                : @string + end
                ;

            return output;
        }

        public string Ensure_WrappedWith(
            string @string,
            char character)
        {
            var output = this.Ensure_StartsWith(
                @string,
                character);

            output = this.Ensure_EndsWith(
                output,
                character);

            return output;
        }

        public bool Equals_CaseInsensitive(
            string a,
            string b)
        {
            var a_Invariant = this.To_Lower(a);
            var b_Invariant = this.To_Lower(b);

            var output = this.Equals_CaseSensitive(a_Invariant, b_Invariant);
            return output;
        }

        public bool Equals_CaseSensitive(
            string a,
            string b)
        {
            var output = a == b;
            return output;
        }

        /// <summary>
        /// A quality-of-life over for <see cref="Equals_CaseSensitive(string, string)"/>.
        /// </summary>
        public bool Equals_Exact(
            string a,
            string b)
            => this.Equals_CaseSensitive(
                a,
                b);

        /// <summary>
        /// Robustly returns null or empty for null or empty (respectively).
        /// </summary>
        public string ExceptFirst_Robust(string @string)
        {
            var isNullOrEmpty = this.Is_NullOrEmpty(@string);
            if (isNullOrEmpty)
            {
                return @string;
            }

            var output = _Internal.Except_First_Unchecked(@string);
            return output;
        }

        /// <summary>
        /// Similar to the String.Length property and the LINQ Count() extension, throws an exception if the string is null or empty.
        /// </summary>
        public string Except_First_Strict(string @string)
        {
            var isNull = this.Is_Null(@string);
            if (isNull)
            {
                throw new ArgumentNullException(nameof(@string));
            }

            var isEmpty = this.Is_Empty(@string);
            if (isEmpty)
            {
                throw new ArgumentOutOfRangeException(nameof(@string), "Input string was empty.");
            }

            var output = _Internal.Except_First_Unchecked(@string);
            return output;
        }

        /// <summary>
        /// Returns the string, without the beginning.
        /// Strict in terms of the function throws an exception if the string does <strong>not</strong> start with the specified beginning.
        /// </summary>
        public string Except_Beginning_Strict(
            string @string,
            string beginning)
        {
            var startsWithBeginning = this.BeginsWith(
                @string,
                beginning);

            if (!startsWithBeginning)
            {
                throw new ArgumentException($"String '{@string}' did not start with beginning '{beginning}'.", nameof(@string));
            }

            var output = @string[beginning.Length..];
            return output;
        }

        /// <summary>
        /// Quality-of-life overload for <see cref="Except_Beginning_Strict(string, string)"/>.
        /// </summary>
        public string Except_Beginning(
            string @string,
            string beginning)
        {
            var output = this.Except_Beginning_Strict(
                @string,
                beginning);

            return output;
        }

        /// <summary>
        /// Returns the string, without the ending.
        /// Robust in terms of the function does not care if the input actually ends with the ending.
        /// </summary>
        public string Except_Ending_Robust(
            string @string,
            string ending)
        {
            var output = @string[..^ending.Length];
            return output;
        }

        /// <summary>
        /// Returns the string, without the ending.
        /// Strict in terms of the function throws an exception if the string does <strong>not</strong> end with the specified ending.
        /// </summary>
        public string Except_Ending_Strict(
            string @string,
            string ending)
        {
            var endsWithEnding = this.EndsWith(
                @string,
                ending);

            if (!endsWithEnding)
            {
                throw new ArgumentException($"String '{@string}' did not end with ending '{ending}'.", nameof(@string));
            }

            var output = this.Except_Ending_Robust(
                @string,
                ending);

            return output;
        }

        /// <summary>
        /// Quality-of-life overload for <see cref="Except_Ending_Strict(string, string)"/>.
        /// </summary>
        public string Except_Ending(
            string @string,
            string ending)
        {
            var output = this.Except_Ending_Strict(
                @string,
                ending);

            return output;
        }

        /// <summary>
        /// Chooses <see cref="Except_First_Strict(string)"/> as the default.
        /// Check your string lengths!
        /// </summary>
        public new string Except_First(string @string)
        {
            var output = this.Except_First_Strict(@string);
            return output;
        }

        public string Except_FirstTwo(string @string)
        {
            var output = @string[2..];
            return output;
        }

        public string Get_FormatTemplate(string formatString)
        {
            var formatTemplate = $"{{0:{formatString}}}";
            return formatTemplate;
        }

        /// <summary>
        /// Note: singular.
        /// </summary>
        public string Format_WithFormatString(
            string formatString,
            object @object)
        {
            var formatTemplate = this.Get_FormatTemplate(formatString);

            var output = this.Format_WithTemplate(
                formatTemplate,
                @object);

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

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Needed in addition to <see cref="IListOperator.Get_Index_Last{T}(IList{T})"/>, since <see cref="string"/> does not implement <see cref="IList{T}"/>.
        /// </remarks>
        public int Get_Index_Last(string @string)
        {
            var length = this.Get_Length(@string);

            var output = Instances.IndexOperator.Get_LastIndexFromLength(length);
            return output;
        }

        public char Get_Character_Last(
            string @string,
            int indexOfLast)
        {
            var output = this.Get_Character(
                @string,
                indexOfLast);

            return output;
        }

        public int Get_IndexOf_OrNotFound(
            string @string,
            char character)
        {
            var output = @string.IndexOf(character);
            return output;
        }

        public int Get_FirstIndexOf_OrNotFound(
            string @string,
            string testString)
        {
            var output = @string.IndexOf(testString);
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
        /// Quality-of-life overload for <see cref="F10Y.L0000.IStringOperator.Length_IsAtLeast(string, int)"/> 
        /// </summary>
        public bool Is_Length_AtLeast(
            string @string,
            int length)
            => this.Length_IsAtLeast(
                @string,
                length);

        /// <summary>
        /// Quality-of-life overload for <see cref="F10Y.L0000.IStringOperator.Length_IsGreaterThan(string, int)"/> 
        /// </summary>
        public bool Is_Length_GreaterThan(
            string @string,
            int length)
            => this.Length_IsGreaterThan(
                @string,
                length);

        /// <summary>
        /// Quality-of-life overload for <see cref="F10Y.L0000.IStringOperator.Length_IsGreaterThan(string, int)"/> 
        /// </summary>
        public bool Is_Length_LessThan(
            string @string,
            int length)
            => this.Length_IsLessThan(
                @string,
                length);

        public IEnumerable<string> Get_NonWhitespaceStrings(IEnumerable<string> strings)
        {
            var output = strings
                .Where(this.Is_NotWhitespace)
                ;

            return output;
        }

        public IEnumerable<string> Get_NotNullOrEmptyStrings(IEnumerable<string> strings)
        {
            var output = strings
                .Where(this.Is_NotNullOrEmpty)
                ;

            return output;
        }

        public Func<string, bool> Get_Predicate_ForEquals(string value)
            => Instances.PredicateOperator.Get_Predicate_ForEquals(value);

        public string Get_String(
            StringBuilder stringBuilder,
            Action<StringBuilder> modifier)
        {
            modifier(stringBuilder);

            var output = stringBuilder.ToString();
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

        public bool Has_IndexOf(
            string @string,
            char character,
            out int indexOfCharacter_OrNotFound)
        {
            indexOfCharacter_OrNotFound = this.Get_IndexOf_OrNotFound(
                @string,
                character);

            var output = this.Was_Found(indexOfCharacter_OrNotFound);
            return output;
        }

        /// <summary>
        /// Given a string, get the index (zero-based index) of the first digit (0-9),
        /// or if there is none, not found.
        /// </summary>
        public bool Has_IndexOfFirstDigitCharacter(
            string @string,
            out int indexOfFirstDigitCharacter_OrNotFound)
        {
            var index = 0;

            foreach (var character in @string)
            {
                var isDigit = Instances.CharacterOperator.Is_Digit(character);
                if(isDigit)
                {
                    indexOfFirstDigitCharacter_OrNotFound = index;

                    return true;
                }

                index++;
            }

            // Else, not found.
            indexOfFirstDigitCharacter_OrNotFound = Instances.Indices.NotFound;

            return false;
        }

        public bool Is_Found(int index)
        {
            return Instances.IndexOperator.Is_Found(index);
        }

        public bool Is_NotNullOrEmpty(string @string)
        {
            var isNullOrEmpty = this.Is_NullOrEmpty(@string);

            var output = !isNullOrEmpty;
            return output;
        }

        public bool Is_NotWhitespace(string @string)
        {
            var isWhitespace = this.Is_Whitespace(@string);

            var output = !isWhitespace;
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

        /// <summary>
        /// Determines whether the string contains only whitespace characters.
        /// </summary>
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
            params string[] strings)
        {
            var output = this.Join(separator, strings.AsEnumerable());
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

        /// <summary>
        /// Uses the <see cref="F10Y.L0000.IStrings.Empty"/> value as a separator.
        /// </summary>
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

        public string Join_AsList(IEnumerable<string> strings)
        {
            var output = this.Join(
                Instances.Strings.CommaSpaceSeparatedListSeparator,
                strings);

            return output;
        }

        public string Join_AsList(params string[] strings)
        {
            var output = this.Join_AsList(strings.AsEnumerable());
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

        /// <summary>
        /// Quality-of-life overload for <see cref="F10Y.L0000.IStringOperator.To_Lower(string)"/>.
        /// </summary>
        /// <inheritdoc cref="F10Y.L0000.IStringOperator.To_Lower(string)" path="/remarks"/>
        public string Lower(string @string)
            => this.To_Lower(@string);

        public IEnumerable<string> Order_Alphabetically_OnlyIfDebug(IEnumerable<string> items)
        {
            var output = items
#if DEBUG
                .OrderAlphabetically()
#endif
                ;

            return output;
        }

        public IEnumerable<IEnumerable<string>> OrderBy_First(IEnumerable<IEnumerable<string>> values)
            => Instances.EnumerableOperator.OrderBy_First(values);

        public string PrefixWith(
            string prefix,
            string @string)
        {
            var output = prefix + @string;
            return output;
        }

        public string PrefixWith(
            char prefix,
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

        public string Replace_Character(
            string @string,
            char oldCharacter,
            char newCharacter)
        {
            var output = @string.Replace(
                oldCharacter,
                newCharacter);

            return output;
        }

        public string Replace(
            string @string,
            char newCharacter,
            IEnumerable<char> oldCharacters)
        {
            var currentString = @string;

            foreach (var oldCharacter in oldCharacters)
            {
                currentString = this.Replace_Character(
                    currentString,
                    oldCharacter,
                    newCharacter);
            }

            return currentString;
        }

        public string Replace_Characters(
            string @string,
            char newCharacter,
            params char[] oldCharacters)
        {
            var output = this.Replace(
                @string,
                newCharacter,
                oldCharacters.AsEnumerable());

            return output;
        }

        public string Replace(
            string @string,
            char newCharacter,
            params char[] oldCharacters)
        {
            var output = this.Replace_Characters(
                @string,
                newCharacter,
                oldCharacters);

            return output;
        }

        public string Replace_String(
            string @string,
            string oldString,
            string newString)
        {
            var output = @string.Replace(
                oldString,
                newString);

            return output;
        }

        public string Replace(
            string @string,
            string newString,
            IEnumerable<string> oldStrings)
        {
            var currentString = @string;

            foreach (var oldString in oldStrings)
            {
                currentString = this.Replace_String(
                    currentString,
                    oldString,
                    newString);
            }

            return currentString;
        }

        public string Replace_Strings(
            string @string,
            string newString,
            params string[] oldStrings)
        {
            var output = this.Replace(
                @string,
                newString,
                oldStrings.AsEnumerable());

            return output;
        }

        public string Replace(
            string @string,
            string newString,
            params string[] oldStrings)
        {
            var output = this.Replace_Strings(
                @string,
                newString,
                oldStrings);

            return output;
        }

        public IEnumerable<string> Separate(
            IEnumerable<string> strings,
            string separator)
            => Instances.EnumerableOperator.Separate(
                strings,
                separator);

        public IEnumerable<string> Separate_Lines(IEnumerable<string> lines)
            => this.Separate(
                lines,
                Instances.Strings.Empty);

        public IEnumerable<string> SeparateMany_Lines(
            IEnumerable<IEnumerable<string>> enumerable_OfLines,
            string separator)
            => Instances.EnumerableOperator.SeparateMany(
                enumerable_OfLines,
                separator);

        public IEnumerable<string> SeparateMany_Lines(IEnumerable<IEnumerable<string>> enumerable_OfLines)
            => this.SeparateMany_Lines(
                enumerable_OfLines,
                Instances.Strings.Empty);

        public IEnumerable<string> SeparateMany_Lines<T>(
            IEnumerable<T> values,
            Func<T, IEnumerable<string>> selector,
            string separator)
            => Instances.EnumerableOperator.SeparateMany<T, string>(
                values,
                selector,
                separator);

        public IEnumerable<string> SeparateMany_Lines<T>(
            IEnumerable<T> values,
            Func<T, IEnumerable<string>> selector)
            => this.SeparateMany_Lines(
                values,
                selector,
                Instances.Strings.Empty);

        public string[] Split_On(
            string @string,
            int index)
        {
            var firstToken = this.Get_Substring_Upto_Exclusive(
                index,
                @string);

            var secondToken = this.Get_Substring_From_Exclusive(
                index,
                @string);

            var output = new[]
            {
                firstToken,
                secondToken
            };

            return output;
        }

        public bool StartsWith(
            string @string,
            char character)
        {
            var output = @string[0] == character;
            return output;
        }

        public bool StartsWith(string @string, string start)
        {
            var isNull = @string is null;
            var startIsNull = start is null;

            if (isNull)
            {
                // If the string is null, then it all depends on the start. If the start is null, then true, else false.
                return startIsNull;
            }
            // Now we know the string is not null.

            if (startIsNull)
            {
                // If the string is not null, but the start is null, then false.
                return false;
            }
            // Now we know the start is not null.

            var isTooShort = @string.Length < start.Length;
            if (isTooShort)
            {
                return false;
            }
            // Now we know it is at least of the right length.

            // Use a span to avoid creating an extra string on the heap.
            var output = MemoryExtensions.Equals(
                @string.AsSpan(0, start.Length),
                start,
                StringComparison.Ordinal);

            return output;
        }

        /// <inheritdoc cref="System.String.Trim()"/>
        public string Trim(string @string)
        {
            var output = @string.Trim();
            return output;
        }

        /// <inheritdoc cref="Trim(string)"/>
        public IEnumerable<string> Trim(IEnumerable<string> strings)
        {
            var output = strings
                .Select(@string => this.Trim(@string))
                ;

            return output;
        }

        /// <inheritdoc cref="System.String.Trim(char[])"/>
        public string Trim(
            string @string,
            params char[] characters)
        {
            var output = @string.Trim(characters);
            return output;
        }

        public string Trim_End(
            string value,
            params char[] characters)
        {
            var output = value.TrimEnd(
                characters);

            return output;
        }

        /// <summary>
        /// Trims the ending (if it exists) from the end of the provided value.
        /// </summary>
        public string Trim_End(
            string value,
            string ending)
        {
            var output = value;

            while (true)
            {
                bool valueEndsWithEnding = this.EndsWith(
                    output,
                    ending);

                if (valueEndsWithEnding)
                {
                    output = this.Except_Ending(
                        output,
                        ending);
                }
                else
                {
                    break;
                }
            }

            return output;
        }

        /// <summary>
        /// Trims new-lines (both Windows and Non-Windows) from the start and end of a string.
        /// Does not trim tabs.
        /// </summary>
        /// <remarks>
        /// Useful for creating string-literal code fragments on their own lines (meaning the new-lines between the start-line and end-line must be removed.
        /// </remarks>
        public string Trim_NewLines(string value)
        {
            var output = value.Trim(
                Instances.Characters.NewLine,
                Instances.Characters.CarriageReturn);

            return output;
        }

        public string Trim_Start(
            string value,
            params char[] trimCharacters)
        {
            var output = value.TrimStart(
                trimCharacters);

            return output;
        }

        /// <summary>
        /// Trims the beginning (if it exists) from the start of the provided value.
        /// </summary>
        public string Trim_Start(
            string value,
            string beginning)
        {
            var output = value;

            while (true)
            {
                bool valueStartsWithBeginning = this.StartsWith(
                    output,
                    beginning);

                if (valueStartsWithBeginning)
                {
                    output = this.Except_Beginning(
                        output,
                        beginning);
                }
                else
                {
                    break;
                }
            }

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

        public string Wrap(
            string @string,
            string prefix,
            string suffix)
        {
            var output = $"{prefix}{@string}{suffix}";
            return output;
        }

        public string Wrap(
            string @string,
            char prefix,
            char suffix)
        {
            var output = this.Wrap(
                @string,
                prefix.ToString(),
                suffix.ToString());

            return output;
        }
    }
}
