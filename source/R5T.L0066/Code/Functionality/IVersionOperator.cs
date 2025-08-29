using System;
using System.Collections.Generic;
using System.Linq;

using F10Y.T0011;
using R5T.T0132;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface IVersionOperator : IFunctionalityMarker,
        F10Y.L0000.IVersionOperator
    {
#pragma warning disable IDE1006 // Naming Styles

        [Ignore]
        public F10Y.L0000.IVersionOperator _F10Y_L0000 => F10Y.L0000.VersionOperator.Instance;

#pragma warning restore IDE1006 // Naming Styles


        /// <summary>
		/// Returns the value of a version property that is defined, but have the default value (which is 0, zero).
		/// </summary>
		public int Get_DefaultVersionPropertyValue()
        {
            var output = Instances.Integers.Zero;
            return output;
        }

        /// <summary>
        /// Returns the value of undefined version properties (which is -1, negative one).
        /// </summary>
        public int Get_UndefinedVersionPropertyValue()
        {
            var output = Instances.Integers.NegativeOne;
            return output;
        }

        /// <summary>
		/// Determines if the version property value is the value returned by <see cref="Get_UndefinedVersionPropertyValue"/> (which is -1, negative one).
		/// </summary>
		public bool Is_DefinedVersionPropertyValue(int versionPropertyValue)
        {
            var undefinedVersionPropertyValue = this.Get_UndefinedVersionPropertyValue();

            // Use not-equal instead of greater than to avoid relying on knowledged that the undefined value is negative one.
            var output = versionPropertyValue != undefinedVersionPropertyValue;
            return output;
        }

        /// <summary>
        /// The "only" available version must match the major version, and is the highest minor version greater-than or equal-to the target version.
        /// </summary>
        public Version Select_AvailableVersion_Only(
            Version targetVersion,
            IEnumerable<Version> availableVersions)
        {
            var matchingVersions = availableVersions
                .Where(version => this.Matches_MajorVersion(
                    version,
                    targetVersion)
                )
                ;

            var anyMatchingVersions = matchingVersions.Any();
            if(!anyMatchingVersions)
            {
                throw new Exception($"No version matches target version '{targetVersion}'.");
            };

            var output = matchingVersions
                .OrderByDescending(x => x)
                .First()
                ;

            return output;
        }

        /// <summary>
        /// Determines if a version matching the target version is available.
        /// Output version is the default if false.
        /// </summary>
        public bool Has_AvailableVersion_Only(
            Version targetVersion,
            IEnumerable<Version> availableVersions,
            out Version version)
        {
            var matchingVersions = availableVersions
                .Where(version => this.Matches_MajorVersion(
                    version,
                    targetVersion)
                )
                ;

            var output = matchingVersions.Any();

            version = matchingVersions
                .OrderByDescending(x => x)
                .FirstOrDefault()
                ;

            return output;
        }

        public Version Select_LatestVersion(IEnumerable<Version> versions)
            => versions.Max();

        public string ToString(Version version)
            => version.ToString();

        /// <summary>
		/// Will return X.Y.Z, and will not throw if the version defines fewer tokens.
		/// </summary>
		public string ToString_Major_Minor_Build_FewerTokensOk(Version version)
        {
            var normalizedVersion = this.NormalizeTo_Major_Minor_Build(version);

            var output = this.ToString_Major_Minor_Build_ThrowIfFewerTokens(normalizedVersion);
            return output;
        }

        /// <summary>
		/// Will throw if the major, minor, and build properties of version are not set.
		/// </summary>
		public string ToString_Major_Minor_Build_ThrowIfFewerTokens(Version version)
        {
            // This ToString() implementation throws if there are too few tokens.
            var output = version.ToString(3);
            return output;
        }

        /// <summary>
		/// <inheritdoc cref="ToString_Major_Minor_Build_FewerTokensOk(Version)" path="/summary"/>
		/// </summary>
		/// <remarks>
        /// Chooses <see cref="ToString_Major_Minor_Build_FewerTokensOk(Version)"/> as the default.
        /// </remarks>
        public string ToString_Major_Minor_Build(Version version)
        {
            var output = this.ToString_Major_Minor_Build_FewerTokensOk(version);
            return output;
        }
    }
}
