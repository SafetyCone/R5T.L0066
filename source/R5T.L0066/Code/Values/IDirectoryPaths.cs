using System;

using R5T.T0131;


namespace R5T.L0066
{
    [ValuesMarker]
    public partial interface IDirectoryPaths : IValuesMarker
    {
        /// <inheritdoc cref="F10Y.L0000.IEnvironmentOperator.Get_UserProfileDirectoryPath"/>
        public string UserProfile => Instances.EnvironmentOperator.Get_UserProfileDirectoryPath();

        /// <inheritdoc cref="ISpecialDirectoryNames._USERPROFILE_"/>
        public string UserProfile_Unexpanded => Instances.SpecialDirectoryNames._USERPROFILE_;
    }
}
