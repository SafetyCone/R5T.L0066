using System;
using System.Diagnostics;

using R5T.T0132;
using R5T.T0143;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface IProcessOperator : IFunctionalityMarker,
        F10Y.L0000.IProcessOperator
    {
#pragma warning disable IDE1006 // Naming Styles

        [Ignore]
        F10Y.L0000.IProcessOperator _F10Y_L0000 => F10Y.L0000.ProcessOperator.Instance;

#pragma warning restore IDE1006 // Naming Styles


        public ProcessStartInfo Set_Command(
            ProcessStartInfo processStartInfo,
            string command,
            string commandArgument)
        {
            processStartInfo.FileName = command;
            processStartInfo.Arguments = commandArgument;

            return processStartInfo;
        }

        public void Start(
            string command_ExecutableFilePath_OrExecutableName,
            string argumentsString)
        {
            // Ignore the output process.
            Process.Start(
                command_ExecutableFilePath_OrExecutableName,
                argumentsString);
        }
    }
}
