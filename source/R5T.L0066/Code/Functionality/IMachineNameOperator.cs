using System;
using System.Collections.Generic;

using R5T.T0132;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface IMachineNameOperator : IFunctionalityMarker
    {
        /// <inheritdoc cref="IEnvironmentOperator.Get_MachineName"/>
        public string Get_MachineName()
            => Instances.EnvironmentOperator.Get_MachineName();

        /// <summary>
        /// Uses the machine name provided by <see cref="Get_MachineName"/>.
        /// </summary>
        public TOutput Switch_OnMachineName<TOutput>(
            IDictionary<string, TOutput> outputs_ByMachineName,
            TOutput @default)
        {
            var machineName = this.Get_MachineName();

            var output = outputs_ByMachineName.ContainsKey(machineName)
                ? outputs_ByMachineName[machineName]
                : @default
                ;

            return output;
        }

        public TValue Get_ValueByMachineName<TValue>(
            IDictionary<string, TValue> valuesByMachineName,
            Func<TValue> defaultValueProvider)
        {
            var machineName = this.Get_MachineName();

            if (valuesByMachineName.ContainsKey(machineName))
            {
                var output = valuesByMachineName[machineName];
                return output;
            }
            else
            {
                // Else, assume we are in a non-development environment, and all required files are in the executable directory.
                var output = defaultValueProvider();
                return output;
            }
        }

        public TOutput Switch_OnMachineName<TOutput>(
            IDictionary<string, Func<TOutput>> constructorsByMachineName,
            Func<TOutput> defaultValueProvider)
        {
            var machineName = this.Get_MachineName();

            var constructorDefinedForMachineName = constructorsByMachineName.ContainsKey(machineName);

            var constructor = constructorDefinedForMachineName
                ? constructorsByMachineName[machineName]
                : defaultValueProvider
                ;

            var output = constructor();
            return output;
        }

        /// <inheritdoc cref="IEnvironmentOperator.Verify_CurrentMachineNameIs(string)"/>
        public void Verify_CurrentMachineNameIs(string machineName)
            => Instances.EnvironmentOperator.Verify_CurrentMachineNameIs(machineName);
    }
}
