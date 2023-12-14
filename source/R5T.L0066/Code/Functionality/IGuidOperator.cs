using System;

using R5T.T0132;

using GuidDocumentation = R5T.Y0006.Documentation.ForGuid;


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
    public partial interface IGuidOperator : IFunctionalityMarker
    {
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

        public Guid New()
        {
            var output = Guid.NewGuid();
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

        public Guid Parse(string guidString)
        {
            var output = Guid.Parse(guidString);
            return output;
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
