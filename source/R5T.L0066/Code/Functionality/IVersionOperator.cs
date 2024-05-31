using System;
using System.Collections.Generic;
using System.Linq;

using R5T.T0132;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface IVersionOperator : IFunctionalityMarker
    {
        public int[] Get_AllTokens(Version version)
        {
            var tokens = new[]
            {
                version.Major,
                version.Minor,
                version.Build,
                version.Revision,
            };

            return tokens;
        }

        /// <summary>
		/// Returns the value of a version property that is defined, but have the default value (which is 0, zero).
		/// </summary>
		public int Get_DefaultVersionPropertyValue()
        {
            var output = Instances.Integers.Zero;
            return output;
        }

        public int Get_DefinedTokenCount(Version version)
        {
            var undefinedVersionValue = this.Get_UndefinedVersionPropertyValue();

            var tokens = this.Get_AllTokens(version);

            var definedTokenCount = tokens
                .Where(this.Is_DefinedVersionPropertyValue)
                .Count();

            return definedTokenCount;
        }

        public int Get_MajorVersion(Version version)
            => version.Major;

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

        public bool Is_MajorVersion(
            Version version,
            int targetMajorVersion)
        {
            var majorVersion = this.Get_MajorVersion(version);

            var output = majorVersion == targetMajorVersion;
            return output;
        }

        public bool Matches_MajorVersion(
            Version version,
            Version targetVersion)
        {
            var targetMajorVersion = this.Get_MajorVersion(targetVersion);

            var output = this.Is_MajorVersion(
                version,
                targetMajorVersion);

            return output;
        }

        public Version NormalizeTo_Major_Minor_Build(Version version)
        {
            var definedTokenCount = this.Get_DefinedTokenCount(version);
            if (definedTokenCount > 3)
            {
                // Normalize to three.
                var outputVersion = new Version(version.Major, version.Minor, version.Build);
                return outputVersion;
            }

            // If not 4 tokens, but greater than 2, then it is 3.
            if (definedTokenCount > 2)
            {
                return version;
            }

            var defaultVersionPropertyValue = this.Get_DefaultVersionPropertyValue();

            if (definedTokenCount > 1)
            {
                var outputVersion = new Version(version.Major, version.Minor, defaultVersionPropertyValue);
                return outputVersion;
            }

            if (definedTokenCount > 0)
            {
                var outputVersion = new Version(version.Major, defaultVersionPropertyValue, defaultVersionPropertyValue);
                return outputVersion;
            }
            else
            {
                var outputVersion = new Version(defaultVersionPropertyValue, defaultVersionPropertyValue, defaultVersionPropertyValue);
                return outputVersion;
            }
        }

        public Version Parse(string version)
        {
            var output = Version.Parse(version);
            return output;
        }

        /// <summary>
        /// The "only" available version must match the major version, and is the highest minor version greater-than or equal-to the target version.
        /// </summary>
        public Version Select_AvailableVersion_Only(
            Version targetVersion,
            IEnumerable<Version> availableVersions)
        {
            var output = availableVersions
                .Where(version => this.Matches_MajorVersion(
                    version,
                    targetVersion)
                )
                .OrderByDescending(x => x)
                .First()
                ;

            return output;
        }

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
