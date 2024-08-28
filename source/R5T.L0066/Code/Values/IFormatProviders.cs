using System;
using System.Globalization;

using R5T.T0131;


namespace R5T.L0066
{
    [ValuesMarker]
    public partial interface IFormatProviders : IValuesMarker
    {
        /// <summary>
		/// The <see cref="CultureInfo.InvariantCulture"/> value.
		/// </summary>
		public IFormatProvider Default => CultureInfo.InvariantCulture;
    }
}
