using System;
using System.Diagnostics;

using R5T.T0132;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface IProcessOperator : IFunctionalityMarker
    {
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
