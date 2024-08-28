using System;

using R5T.T0132;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface IConversionOperator : IFunctionalityMarker
    {
        public double To_Double(string double_String)
        {
            var @double = Convert.ToDouble(double_String);
            return @double;
        }

        public long To_Long(string long_String)
        {
            var @long = Convert.ToInt64(long_String);
            return @long;
        }

        public string To_String(double @double)
        {
            var doubleString = @double.ToString();
            return doubleString;
        }
    }
}
