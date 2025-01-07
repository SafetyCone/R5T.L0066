using System;
using System.Collections.Generic;

using R5T.T0131;
using R5T.T0143;


namespace R5T.L0066
{
    [ValuesMarker]
    public partial interface IValues : IValuesMarker
    {
#pragma warning disable IDE1006 // Naming Styles

        [Ignore]
        public Raw.IValues _Raw => Raw.Values.Instance;

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

        public static Dictionary<int, int> LastDaysOfMonth_Instance => zLastDaysOfMonth_Instance.Value;

        #endregion


        /// <summary>
        /// <para><value>7</value></para>
        /// </summary>
        public const int DaysInWeek_Constant = 7;

        /// <inheritdoc cref="DaysInWeek_Constant"/>
        public int DaysInWeek => DaysInWeek_Constant;

        public int Days_InWeek => DaysInWeek_Constant;

        /// <summary>
        /// <para><value>24</value></para>
        /// </summary>
        public const int Hours_InDay_Constant = 24;

        /// <inheritdoc cref="Hours_InDay_Constant"/>
        public int Hours_InDay => Hours_InDay_Constant;

        /// <summary>
        /// <para><value>60</value></para>
        /// </summary>
        public const int Minutes_InHour_Constant = 60;

        /// <inheritdoc cref="Minutes_InHour_Constant"/>
        public int Minutes_InHour => Minutes_InHour_Constant;

        /// <summary>
        /// <para><value>60</value></para>
        /// </summary>
        public const int Seconds_InMinute_Constant = 60;

        /// <inheritdoc cref="Seconds_InMinute_Constant"/>
        public int Seconds_InMinute => Seconds_InMinute_Constant;

        /// <summary>
        /// <para><value>100</value></para>
        /// </summary>
        public const int Nanoseconds_InTick_Constant = 100;

        /// <inheritdoc cref="Nanoseconds_InTick_Constant"/>
        public int Nanoseconds_InTick => Nanoseconds_InTick_Constant;


        public Dictionary<int, int> LastDaysOfMonth => new Dictionary<int, int>()
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
        /// <inheritdoc cref="Raw.IValues.DEFAULT" path="descendant::value"/>
        /// </summary>
        /// <remarks>
        /// <see cref="System.Xml.Linq.XElement"/>s cannot be constructed without a name,
        /// but you can change the element's name after construction.
        /// You might want to just construct an element, and then set its name.
        /// This value is used by <see cref="IXElementOperator.New()"/> to do this.
        /// </remarks>
        public string Default_XElementName => _Raw.DEFAULT;

        /// <summary>
        /// The byte-order-mark is a series of three bytes:
        /// 0xEF, 239, ï
        /// 0xBB, 187, »
        /// 0xBF, 191, ¿
        /// </summary>
        public byte[] ByteOrderMark => IValues.zByteOrderMark.Value;

        /// <summary>
        /// <para>true</para>
        /// By default, files are overwritten.
        /// </summary>
        public const bool Default_OverwriteValue_Constant = true;

        /// <inheritdoc cref="Default_OverwriteValue_Constant"/>
        public bool Default_OverwriteValue => Default_OverwriteValue_Constant;

        /// <summary>
        /// 1024, the default for <see cref="System.IO.StreamReader"/>.
        /// </summary>
        public const int Default_StreamReaderBufferSize_Constant = 1024;

        /// <inheritdoc cref="Default_StreamReaderBufferSize_Constant"/>.
        public int Default_StreamReaderBufferSize => IValues.Default_StreamReaderBufferSize_Constant;

        /// <summary>
		/// The value for the command line to have no arguments is null.
		/// </summary>
		public string EmptyCommandArguments => null;

        /// <inheritdoc cref="ICharacters.Period_Constant"/>
        public const char NamespaceNameTokenSeparator_Constant = ICharacters.Period_Constant;

        /// <inheritdoc cref="NamespaceNameTokenSeparator_Constant"/>
        public char NamespaceNameTokenSeparator => IValues.NamespaceNameTokenSeparator_Constant;

        /// <inheritdoc cref="IStrings.Period_Constant"/>
        public const string NamespaceNameTokenSeparator_String_Constant = IStrings.Period_Constant;

        /// <inheritdoc cref="NamespaceNameTokenSeparator_String_Constant"/>
        public string NamespaceNameTokenSeparator_String => IValues.NamespaceNameTokenSeparator_String_Constant;

        /// <summary>
        /// <para><value>-1</value></para>
        /// The length value for a null string, when a length value is required.
        /// </summary>
        public const int NullStringLength_Constant = -1;

        /// <inheritdoc cref="NullStringLength_Constant"/>
        public int NullStringLength => NullStringLength_Constant;

        /// <summary>
        /// <para><value>false</value></para>
        /// </summary>
        public bool False => false;

        /// <summary>
        /// <para><value>true</value></para>
        /// </summary>
        public bool True => true;

        /// <summary>
        /// <inheritdoc cref="Raw.IValues._1_000" path="descendant::value[1]"/>
        /// </summary>
        public uint Kilo => _Raw._1_000;

        /// <summary>
        /// <inheritdoc cref="Raw.IValues._1_000_000" path="descendant::value[1]"/>
        /// </summary>
        public uint Mega => _Raw._1_000_000;

        /// <summary>
        /// <inheritdoc cref="Raw.IValues._1_024_x_1_024_x_1_024" path="descendant::value[1]"/>
        /// </summary>
        public uint Gibi => _Raw._1_024_x_1_024_x_1_024;

        /// <summary>
        /// <inheritdoc cref="Raw.IValues._1_000_000_000" path="descendant::value[1]"/>
        /// </summary>
        public uint Giga => _Raw._1_000_000_000;

        /// <summary>
        /// <para><value>C:\</value></para>
        /// </summary>
        public const string C_DriveName = @"C:\";
    }
}
