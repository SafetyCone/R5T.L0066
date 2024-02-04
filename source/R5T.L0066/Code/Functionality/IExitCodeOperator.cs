using System;

using R5T.T0132;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface IExitCodeOperator : IFunctionalityMarker
    {
        public bool IsSuccess(int exitCode)
        {
            var output = exitCode == Instances.ExitCodes.Success;
            return output;
        }

        public bool IsFailure(int exitCode)
        {
            var output = exitCode != Instances.ExitCodes.Success;
            return output;
        }
    }
}
