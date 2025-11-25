using System;
using System.Collections.Generic;
using System.Linq;

using R5T.T0132;
using R5T.T0143;

using GuidDocumentation = R5T.Y0006.Documentation.For_Guid;


namespace R5T.L0066
{
    /// <summary>
    /// Guid functionality.
    /// </summary>
    /// <remarks>
    /// Prior work:
    /// * R5T.B0000.IGuidOperator
    /// * R5T.T0055.IGuidOperator
    /// * R5T.D0004.IGuidProvider
    /// </remarks>
    [FunctionalityMarker]
    public partial interface IGuidOperator : IFunctionalityMarker,
        F10Y.L0000.IGuidOperator
    {
#pragma warning disable IDE1006 // Naming Styles

        [Ignore]
        F10Y.L0000.IGuidOperator _F10Y_L0000 => F10Y.L0000.GuidOperator.Instance;

#pragma warning restore IDE1006 // Naming Styles


        public IEnumerable<Guid> Enumerate_From(IEnumerable<string> guidStrings)
            => guidStrings
                .Select(this.From)
                ;

        /// <summary>
        /// A quality-of-life overload for <see cref="F10Y.L0000.IGuidOperator.Parse(string)"/>.
        /// </summary>
        public Guid Get_From(string guidString)
            => this.Parse(guidString);

        public Guid[] Get_From(IEnumerable<string> guidStrings)
            => this.Enumerate_From(guidStrings)
                .ToArray();

        public Guid GetDefault()
        {
            var output = new Guid();
            return output;
        }

        public bool IsDefault(Guid guid)
        {
            var output = guid == default;
            return output;
        }

        /// <summary>
        /// Returns a new Guid use the specified random (for seeded Guids, useful in testing).
        /// </summary>
        /// <remarks>
        /// Source: https://stackoverflow.com/a/13188409/10658484
        /// </remarks>
        public Guid New(Random random)
        {
            var guidBytes = new byte[16];

            random.NextBytes(guidBytes);

            var output = new Guid(guidBytes);
            return output;
        }

        public Guid NewSeededGuid(int seed = ISeeds.Default_Constant)
        {
            var random = RandomOperator.Instance.WithSeed(seed);

            var guid = this.New(random);
            return guid;
        }

        /// <summary>
        /// <inheritdoc cref="GuidDocumentation.B_Format"/>
        /// </summary>
        public string ToString_B_Format(Guid guid)
        {
            var output = guid.ToString("B");
            return output;
        }

        /// <summary>
        /// <inheritdoc cref="GuidDocumentation.B_Uppercase_Format"/>
        /// </summary>
        public string ToString_B_Uppercase_Format(Guid guid)
        {
            var output = this.ToString_B_Format(guid).ToUpperInvariant();
            return output;
        }

        /// <summary>
        /// <inheritdoc cref="GuidDocumentation.D_Format"/>
        /// </summary>
        public string ToString_D_Format(Guid guid)
        {
            var output = guid.ToString("D");
            return output;
        }

        /// <summary>
        /// <inheritdoc cref="GuidDocumentation.D_Uppercase_Format"/>
        /// </summary>
        public string ToString_D_Uppercase_Format(Guid guid)
        {
            var output = this.ToString_D_Format(guid).ToUpperInvariant();
            return output;
        }

        /// <summary>
        /// <inheritdoc cref="GuidDocumentation.N_Format"/>
        /// </summary>
        public string ToString_N_Format(Guid guid)
        {
            var output = guid.ToString("N");
            return output;
        }

        /// <summary>
        /// <inheritdoc cref="GuidDocumentation.P_Format"/>
        /// </summary>
        public string ToString_P_Format(Guid guid)
        {
            var output = guid.ToString("P");
            return output;
        }

        /// <summary>
        /// <inheritdoc cref="GuidDocumentation.X_Format"/>
        /// </summary>
        public string ToString_X_Format(Guid guid)
        {
            var output = guid.ToString("X");
            return output;
        }

        /// <summary>
        /// <para>The standard format is default (D uppercase) format.</para>
        /// <inheritdoc cref="GuidDocumentation.D_Uppercase_Format"/>
        /// </summary>
        public string ToString_Standard(Guid guid)
        {
            var output = this.ToString_D_Uppercase_Format(guid);
            return output;
        }

        /// <summary>
        /// <para>The default is the D format.</para>
        /// <inheritdoc cref="GuidDocumentation.D_Format"/>
        /// </summary>
        public string ToString(Guid guid)
        {
            var output = guid.ToString();
            return output;
        }
    }
}
