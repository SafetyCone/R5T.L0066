using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using R5T.T0132;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface IEnvironmentOperator : IFunctionalityMarker
    {
        /// <inheritdoc cref="IDirectorySeparatorOperator.Get_EnvironmentAlternateDirectorySeparator"/>
        public char Get_AlternateDirectorySeparator()
            => Instances.DirectorySeparatorOperator.Get_EnvironmentAlternateDirectorySeparator();

        /// <inheritdoc cref="IDirectorySeparatorOperator.Get_EnvironmentDirectorySeparator"/>
        public char Get_DirectorySeparator()
            => Instances.DirectorySeparatorOperator.Get_EnvironmentDirectorySeparator();

        public DriveInfo Get_DriveInformation(string driveName = IValues.C_DriveName)
            => new DriveInfo(driveName);

        /// <summary>
        /// Chooses <see cref="Get_EnvironmentVariable_OrNull(string)"/> as the default.
        /// </summary>
        public string Get_EnvironmentVariable(string variableName)
            => this.Get_EnvironmentVariable_OrNull(variableName);

        public string Get_EnvironmentVariable_OrNull(string variableName)
        {
            var output = Environment.GetEnvironmentVariable(variableName);
            return output;
        }

        public string Get_EnvironmentVariable_OrException(string variableName)
        {
            var exists = this.Has_EnvironmentVariable(
                variableName,
                out var value);

            if(!exists)
            {
                throw new Exception($"Environment variable '{variableName}' was not set.");
            }

            return value;
        }

        public bool Has_EnvironmentVariable(
            string variableName,
            out string value)
        {
            value = this.Get_EnvironmentVariable_OrNull(variableName);

            var exists = Instances.NullOperator.Is_NotNull(value);
            return exists;
        }

        public bool Has_EnvironmentVariable(string variableName)
        {
            var output = this.Has_EnvironmentVariable(
                variableName,
                out _);

            return output;
        }

        public Dictionary<string, string> Get_EnvironmentVariables()
        {
            var dictionary = Environment.GetEnvironmentVariables();

            var output = Instances.DictionaryOperator.To_Generic<string, string>(dictionary);
            return output;
        }

        public string Get_CurrentDirectoryPath()
        {
            var output = Environment.CurrentDirectory;
            return output;
        }

        public string Get_EntryPointAssemblyFilePath()
        {
            var entryPointAssembly = Instances.AssemblyOperator.Get_EntryPointAssembly();

            var output = Instances.AssemblyOperator.Get_FilePath(entryPointAssembly);
            return output;
        }

        /// <summary>
        /// Gets the name of the machine on which code is currently executing.
        /// </summary>
        public string Get_MachineName()
        {
            var output = Environment.MachineName;
            return output;
        }

        public string Get_NewLine()
            => Environment.NewLine;

        /// <inheritdoc cref="IRuntimeOperator.Get_RuntimeDirectoryPath"/>
        public string Get_RuntimeDirectoryPath()
            => Instances.RuntimeOperator.Get_RuntimeDirectoryPath();

        public string Get_PathEnvironmentVariable()
        {
            var output = this.Get_EnvironmentVariable(Instances.EnvironmentVariableNames.Path);
            return output;
        }

        /// <summary>
        /// Quality-of-life overload for <see cref="Get_PathEnvironmentVariable"/>.
        /// </summary>
        public string Get_Path()
            => this.Get_PathEnvironmentVariable();

        /// <summary>
        /// Chooses <see cref="Get_PathDirectories_WithoutDuplicates"/> as the default.
        /// </summary>
        public string[] Get_PathDirectories()
            => this.Get_PathDirectories_WithoutDuplicates();

        public string[] Get_PathDirectories_WithPossibleDuplicates()
        {
            var path = this.Get_Path();

            var separator = this.Get_PathDirectoriesSeparator();

            var output = Instances.StringOperator.Split(
                separator,
                path,
                StringSplitOptions.RemoveEmptyEntries);

            return output;
        }

        public string[] Get_PathDirectories_WithoutDuplicates()
        {
            var pathDirectories_WithDuplicates = this.Get_PathDirectories_WithPossibleDuplicates();

            var output = pathDirectories_WithDuplicates
                .Select(Instances.StringOperator.To_Lower)
                .Distinct()
                .Now();

            return output;
        }

        /// <summary>
        /// The separator used in the Path environment variable to separate search location directory paths.
        /// <inheritdoc cref="ICharacters.Semicolon" path="descendant::description"/>
        /// </summary>
        public char Get_PathDirectoriesSeparator()
            => Instances.Characters.Semicolon;

        /// <inheritdoc cref="IRuntimeOperator.Get_SystemAssemblyFilePath"/>
        public string Get_SystemAssemblyFilePath()
            => Instances.RuntimeOperator.Get_SystemAssemblyFilePath();

        public string Get_SpecialDirectoryPath(Environment.SpecialFolder specialFolder)
        {
            var output = Environment.GetFolderPath(specialFolder);
            return output;
        }

        /// <summary>
        /// Gets the system directory path for the current user.
        /// </summary>
        /// <remarks>
        /// Returns the value for <see cref="Environment.SpecialFolder.UserProfile"/>.
        /// </remarks>
        public string Get_UserDirectoryPath()
            => this.Get_SpecialDirectoryPath(Environment.SpecialFolder.UserProfile);

        public bool Is_Windows()
            => Instances.OperatingSystemOperator.Is_Windows();

        /// <summary>
        /// Determines if the current machine has the given name.
        /// </summary>
        public bool Is_CurrentMachineName(string machineName)
        {
            var currentMachineName = this.Get_MachineName();

            var output = currentMachineName == machineName;
            return output;
        }

        /// <summary>
        /// Verifies that the current machine has the given name.
        /// </summary>
        /// <remarks>
        /// Useful for ensuring that some code is only run on a particular machine.
        /// </remarks>
        public void Verify_CurrentMachineNameIs(string machineName)
        {
            var isMachineName = this.Is_CurrentMachineName(machineName);
            if (!isMachineName)
            {
                var currentMachineName = this.Get_MachineName();

                throw new Exception($"'{currentMachineName}': machine name was not '{machineName}'.");
            }
        }
    }
}
