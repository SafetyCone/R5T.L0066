using System;


namespace R5T.L0066
{
	/// <summary>
	/// Strict platform library for .NET Standard 2.1.
	/// </summary>
	public static class Documentation
	{
        /// <summary>
        /// Note that array lengths are *not* actually checked.
        /// </summary>
        public static readonly object ArrayLengthsNotActuallyChecked;

        /// <summary>
        /// Note that collection counts are *not* actually checked.
        /// </summary>
        public static readonly object CollectionCountsNotActuallyChecked;

        /// <summary>
        /// <para>OBSOLETE: <see cref="F10Y.Y0000.Documentation.CompareTo_XtoY"/></para>
        /// For x.CompareTo(y) in <see cref="IComparable{T}.CompareTo(T)"/>.
        /// </summary>
        [Obsolete]
        public static readonly object CompareToXY;

        /// <summary>
        /// Exclusive in that if the first day of the week is the same as the second day of the week, the result is a full week of seven (7) days.
        /// </summary>
        public static readonly object DayOfWeek_Exclusive;

        /// <summary>
        /// Inclusive in that if the first day of the week is the same as the second day of the week, the result is zero (0) days.
        /// </summary>
        public static readonly object DayOfWeek_Inclusive;

        /// <summary>
        /// Note that dictionary counts are *not* actually checked.
        /// </summary>
        public static readonly object DictionaryCountsNotActuallyChecked;

        /// <summary>
        /// Note that list counts are *not* actually checked.
        /// </summary>
        public static readonly object ListCountsNotActuallyChecked;

        /// <summary>
        /// type name (fully qualified type name)
        /// </summary>
        public static readonly object TypeNameMeansFullyQualifiedTypeName;
    }
}