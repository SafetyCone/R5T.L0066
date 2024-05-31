using System;
using System.Linq;

using R5T.T0132;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface ICommandLineArgumentsOperator : IFunctionalityMarker
    {
        public string Get_ExecutableFilePath()
        {
            var commandLineArguments = this.Get_CommandLineArguments();

            var output = this.Get_ExecutableFilePath(commandLineArguments);
            return output;
        }

        public string Get_ExecutableFilePath(string[] commandLineArguments)
        {
            // In .NET, the file path for the currently executing executable is the first argument.
            var output = this.Get_FirstCommandLineArgument();
            return output;
        }

        public string Get_FirstCommandLineArgument()
            => this.Get_CommandLineArguments().First();

        public string[] Get_CommandLineArguments()
        {
            var output = Environment.GetCommandLineArgs();
            return output;
        }
    }
}
