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
        /// For x.CompareTo(y) in <see cref="IComparable{T}.CompareTo(T)"/>.
        /// </summary>
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
        /// When equating two object instances, if the objects have different types then a simple type check has determined whether the instances are equal.
        /// In the case where the instances have different types, a type check has determined equality and the instances are not equal.
        /// Otherwise, if the instances have the same type, a type check does not determine equality and you will need to equate instance values.
        /// </summary>
        public static readonly object TypeCheckDeterminesEquality;

        /// <summary>
        /// type name (fully qualified type name)
        /// </summary>
        public static readonly object TypeNameMeansFullyQualifiedTypeName;
    }
}