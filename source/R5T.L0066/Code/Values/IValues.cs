using System;

using R5T.T0131;


namespace R5T.L0066
{
    [ValuesMarker]
    public partial interface IValues : IValuesMarker
    {
        private static readonly Lazy<byte[]> zByteOrderMark = new Lazy<byte[]>(() => new byte[]
        {
            239,
            187,
            191
        });

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
    }
}
