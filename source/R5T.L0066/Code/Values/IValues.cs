using System;
using System.Collections.Generic;

using R5T.T0131;
using R5T.T0143;


namespace R5T.L0066
{
    [ValuesMarker]
    public partial interface IValues : IValuesMarker,
        F10Y.L0000.IValues,
        F10Y.L0001.L000.IValues
    {
#pragma warning disable IDE1006 // Naming Styles

        [Ignore]
        new Raw.IValues _Raw => Raw.Values.Instance;

#pragma warning restore IDE1006 // Naming Styles

        #region Static

        private static readonly Lazy<byte[]> zByteOrderMark = new Lazy<byte[]>(() => new byte[]
        {
            239,
            187,
            191
        });

        private static readonly Lazy<Dictionary<int, int>> zLastDaysOfMonth_Instance = new Lazy<Dictionary<int, int>>(
            Instances.Values.LastDaysOfMonth);

        static Dictionary<int, int> LastDaysOfMonth_Instance => zLastDaysOfMonth_Instance.Value;

        #endregion


        /// <summary>
        /// <para><value>7</value></para>
        /// </summary>
        const int DaysInWeek_Constant = 7;

        /// <inheritdoc cref="DaysInWeek_Constant"/>
        int DaysInWeek => DaysInWeek_Constant;

        int Days_InWeek => DaysInWeek_Constant;

        /// <summary>
        /// <para><value>24</value></para>
        /// </summary>
        const int Hours_InDay_Constant = 24;

        /// <inheritdoc cref="Hours_InDay_Constant"/>
        int Hours_InDay => Hours_InDay_Constant;

        /// <summary>
        /// <para><value>60</value></para>
        /// </summary>
        const int Minutes_InHour_Constant = 60;

        /// <inheritdoc cref="Minutes_InHour_Constant"/>
        int Minutes_InHour => Minutes_InHour_Constant;

        /// <summary>
        /// <para><value>60</value></para>
        /// </summary>
        const int Seconds_InMinute_Constant = 60;

        /// <inheritdoc cref="Seconds_InMinute_Constant"/>
        int Seconds_InMinute => Seconds_InMinute_Constant;

        /// <summary>
        /// <para><value>100</value></para>
        /// </summary>
        const int Nanoseconds_InTick_Constant = 100;

        /// <inheritdoc cref="Nanoseconds_InTick_Constant"/>
        int Nanoseconds_InTick => Nanoseconds_InTick_Constant;


        Dictionary<int, int> LastDaysOfMonth => new Dictionary<int, int>()
        {
            { 1, 31 },
            { 2, 28 }, // Note: requires leap-year adjustment elsewhere.
            { 3, 31 },
            { 4, 30 },
            { 5, 31 },
            { 6, 30 },
            { 7, 31 },
            { 8, 31 },
            { 9, 30 },
            { 10, 31 },
            { 11, 30 },
            { 12, 31 }
        };

        /// <summary>
        /// <inheritdoc cref="F10Y.L0001.L000.Raw.IValues.DEFAULT" path="descendant::value"/>
        /// </summary>
        /// <remarks>
        /// <see cref="System.Xml.Linq.XElement"/>s cannot be constructed without a name,
        /// but you can change the element's name after construction.
        /// You might want to just construct an element, and then set its name.
        /// This value is used by <see cref="F10Y.L0000.IXElementOperator.New()"/> to do this.
        /// </remarks>
        string Default_XElementName => _Raw.DEFAULT;

        /// <summary>
        /// The byte-order-mark is a series of three bytes:
        /// 0xEF, 239, ï
        /// 0xBB, 187, »
        /// 0xBF, 191, ¿
        /// </summary>
        byte[] ByteOrderMark => IValues.zByteOrderMark.Value;

        /// <summary>
        /// 1024, the default for <see cref="System.IO.StreamReader"/>.
        /// </summary>
        const int Default_StreamReaderBufferSize_Constant = 1024;

        /// <inheritdoc cref="Default_StreamReaderBufferSize_Constant"/>.
        int Default_StreamReaderBufferSize => IValues.Default_StreamReaderBufferSize_Constant;

        /// <summary>
		/// The value for the command line to have no arguments is null.
		/// </summary>
		new string EmptyCommandArguments => F10Y.L0000.IValues.EmptyCommandArguments_Constant;

        /// <inheritdoc cref="ICharacters.Period_Constant"/>
        const char NamespaceNameTokenSeparator_Constant = ICharacters.Period_Constant;

        /// <inheritdoc cref="NamespaceNameTokenSeparator_Constant"/>
        char NamespaceNameTokenSeparator => IValues.NamespaceNameTokenSeparator_Constant;

        /// <inheritdoc cref="F10Y.L0000.IStrings.Period_Constant"/>
        const string NamespaceNameTokenSeparator_String_Constant = IStrings.Period_Constant;

        /// <inheritdoc cref="NamespaceNameTokenSeparator_String_Constant"/>
        string NamespaceNameTokenSeparator_String => IValues.NamespaceNameTokenSeparator_String_Constant;

        /// <summary>
        /// <para><value>-1</value></para>
        /// The length value for a null string, when a length value is required.
        /// </summary>
        const int NullStringLength_Constant = -1;

        /// <inheritdoc cref="NullStringLength_Constant"/>
        int NullStringLength => NullStringLength_Constant;
    }
}
