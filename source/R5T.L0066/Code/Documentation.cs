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