using System;

using R5T.T0131;


namespace R5T.L0066
{
    [ValuesMarker]
    public partial interface IComparisonResults : IValuesMarker
    {
        /// <summary>
        /// Indicates that x is less than y.
        /// <para>Value: <value>-1</value></para>
        /// <para><inheritdoc cref="Documentation.CompareToXY" path="/summary"/></para>
        /// </summary>
        public int LessThan => -1;

        /// <summary>
        /// Indicates that x is greater than y.
        /// <para>Value: <value>1</value></para>
        /// <para><inheritdoc cref="Documentation.CompareToXY" path="/summary"/></para>
        /// </summary>
        public int GreaterThan => 1;

        /// <summary>
        /// Indicates that x is equal to y.
        /// <para>Value: <value>0</value></para>
        /// <para><inheritdoc cref="Documentation.CompareToXY" path="/summary"/></para>
        /// </summary>
        public int EqualTo => 0;
    }
}
