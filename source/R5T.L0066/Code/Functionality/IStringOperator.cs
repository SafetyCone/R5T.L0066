using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using R5T.T0132;
using R5T.T0143;

using R5T.L0066.Extensions;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface IStringOperator : IFunctionalityMarker,
        F10Y.L0001.L000.IStringOperator
    {
#pragma warning disable IDE1006 // Naming Styles

        [Ignore]
        public F10Y.L0001.L000.IStringOperator _F10Y_L0001_L000 => F10Y.L0001.L000.StringOperator.Instance;

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
            => this.Get_CountOf(
                character,
                @string);

        /// <summary>
        /// Note: supports endings that are longer than the string (returns false).
        /// </summary>
        public bool EndsWith(
            string @string,
            string ending)
            => this.Ends_With(
                @string,
                ending);


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
        /// Chooses <see cref="Except_First_Strict(string)"/> as the default.
        /// Check your string lengths!
        /// </summary>
        public new string Except_First(string @string)
        {
            var output = this.Except_First_Strict(@string);
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

        public int Get_FirstIndexOf_OrNotFound(
            string @string,
            string testString)
        {
            var output = @string.IndexOf(testString);
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

        /// <summary>
        /// Gets the last character of a string.
        /// </summary>
        public char Get_LastCharacter(string @string)
        {
            var output = @string[^1];
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
    }
}
