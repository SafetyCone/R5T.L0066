using System;

using R5T.T0132;


namespace R5T.L0066.Implementations
{
    [FunctionalityMarker]
    public partial interface IEnvironmentOperator : IFunctionalityMarker
    {
        /// <inheritdoc cref="L0066.IEnvironmentOperator.Get_UserProfileDirectoryPath" path="/summary"/>
        /// <remarks>
        /// Uses the <see cref="Environment.SpecialFolder.UserProfile"/> value and <see cref="Environment.GetFolderPath(Environment.SpecialFolder)"/> method.
        /// </remarks>
        public string Get_UserProfileDirectoryPath_ViaSpecialFolder()
        {
            var userProfileDirectoryPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);

            // Result returned by system implementation is not directory indicated.
            var output = Instances.PathOperator.Ensure_IsDirectoryIndicated(userProfileDirectoryPath);
            return output;
        }

        /// <inheritdoc cref="L0066.IEnvironmentOperator.Get_UserProfileDirectoryPath" path="/summary"/>
        /// <remarks>
        /// Of interest, any %value% code is actually an environment variable!
        /// Thus we can get resolve a directory path like "%userprofile%/x/y/x" using the <see cref="Environment.ExpandEnvironmentVariables(string)"/> method.
        /// </remarks>
        public string Get_UserProfileDirectoryPath_ViaPathEnvironmentVariableExpansion()
        {
            var userProfileDirectoryUnexpandedPath = Instances.DirectoryPaths.UserProfile_Unexpanded;

            var userProfileDirectoryPath = Environment.ExpandEnvironmentVariables(userProfileDirectoryUnexpandedPath);

            // Result returned by system implementation is not directory indicated.
            var output = Instances.PathOperator.Ensure_IsDirectoryIndicated(userProfileDirectoryPath);
            return output;
        }
    }
}
