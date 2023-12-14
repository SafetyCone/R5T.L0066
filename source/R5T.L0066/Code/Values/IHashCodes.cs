using System;

using R5T.T0131;


namespace R5T.L0066
{
    [ValuesMarker]
    public partial interface IHashCodes : IValuesMarker
    {
        /// <summary>
        /// <para><value>0 (zero)</value></para>
        /// <para>
        /// <description>
        /// A fixed (not run-specific) value for the hashcode of null.
        /// </description>
        /// </para>
        /// Useful if you need a hashcode of a property of an instance to combine with other values, but the property value is null.
        /// </summary>
        public int For_Null_Fixed => 0;
    }
}
