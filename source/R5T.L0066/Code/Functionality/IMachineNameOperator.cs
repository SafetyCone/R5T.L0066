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
    }
}
