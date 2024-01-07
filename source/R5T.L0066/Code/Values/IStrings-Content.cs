using System;

using R5T.T0131;

using StringsDocumentation = R5T.Y0006.Documentation.ForStrings;


namespace R5T.L0066.Content
{
    /// <summary>
    /// Contains strings that are common content strings (ex: "Hello World!").
    /// </summary>
    /// <remarks>
    /// There really shouldn't be content strings in the strictly platform library.
    /// However, some strings are really just common! (Like "Hello World!")
    /// In the future, maybe there will be a separate library for these values.
    /// </remarks>
    [ValuesMarker]
    public partial interface IStrings : IValuesMarker
    {
        /// <summary>
        /// <para><value>Hello World!</value></para>
        /// </summary>
        public string HelloWorld => "Hello World!";
    }
}
