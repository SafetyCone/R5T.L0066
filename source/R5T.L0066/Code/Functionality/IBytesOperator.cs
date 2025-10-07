using System;

using R5T.T0132;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface IBytesOperator : IFunctionalityMarker,
        F10Y.L0001.L000.IBytesOperator
    {
        public double Get_Gibibytes_double(long value)
        {
            var value_asDouble = Instances.Converter.To_double(value);
            var gibi_AsDouble = Instances.Converter.To_double(Instances.Values.Gibi);

            var output = value_asDouble / gibi_AsDouble;
            return output;
        }

        public double Get_Gibibytes_double(ulong value)
        {
            var value_asDouble = Instances.Converter.To_double(value);
            var gibi_AsDouble = Instances.Converter.To_double(Instances.Values.Gibi);

            var output = value_asDouble / gibi_AsDouble;
            return output;
        }

        public ulong Get_Gibibytes_ulong(ulong value)
        {
            var gibi_AsUlong = Instances.Converter.To_ulong(Instances.Values.Gibi);

            var output = value / gibi_AsUlong;
            return output;
        }

        public double Get_Gigabytes_double(long value)
        {
            var value_asDouble = Instances.Converter.To_double(value);
            var gibi_AsDouble = Instances.Converter.To_double(Instances.Values.Giga);

            var output = value_asDouble / gibi_AsDouble;
            return output;
        }

        public ulong Get_Gigabytes_ulong(ulong value)
        {
            var giga_AsUlong = Instances.Converter.To_ulong(Instances.Values.Giga);

            var output = value / giga_AsUlong;
            return output;
        }
    }
}
