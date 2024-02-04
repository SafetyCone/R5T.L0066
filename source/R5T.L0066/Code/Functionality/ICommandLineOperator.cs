using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using R5T.T0132;

using R5T.L0066.Extensions;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface ICommandLineOperator : IFunctionalityMarker
    {
        public void Default_DataReceivedHandler(object sender, DataReceivedEventArgs eventArgs)
        {
            this.WriteToConsole_DataReceivedHandler(sender, eventArgs);
        }

        public void Default_OutputReceivedHandler(object sender, DataReceivedEventArgs eventArgs)
        {
            this.Default_DataReceivedHandler(sender, eventArgs);
        }

        public void Default_ErrorReceivedHandler(object sender, DataReceivedEventArgs eventArgs)
        {
            this.Throw_DataReceivedHandler(sender, eventArgs);
        }

        public void Throw_DataReceivedHandler(object sender, DataReceivedEventArgs eventArgs)
        {
            this.WriteToConsole_DataReceivedHandler(sender, eventArgs);

            throw new Exception(eventArgs.Data);
        }

        public void WriteToConsole_DataReceivedHandler(object sender, DataReceivedEventArgs eventArgs)
        {
            Console.WriteLine(eventArgs.Data);
        }

        public DataReceivedEventHandler GetWriteToText_DataReceivedHandler(
            TextWriter textWriter)
        {
            void Internal(object sender, DataReceivedEventArgs eventArgs)
            {
                textWriter.WriteLine(eventArgs.Data);
            }

            return Internal;
        }

        /// <summary>
        /// Configures and starts a process.
        /// </summary>
        public Process Start(
            string command,
            DataReceivedEventHandler receiveOutputData,
            bool redirectStandardInput = false)
        {
            var output = this.Start(
                command,
                /// As stated by <see cref="ProcessStartInfo.Arguments"/>, the default value is an empty string.
                Instances.Strings.Empty,
                receiveOutputData,
                redirectStandardInput);

            return output;
        }

        /// <summary>
        /// Configures and starts a process.
        /// </summary>
        public Process Start(
            string command,
            string arguments,
            DataReceivedEventHandler receiveOutputData,
            bool redirectStandardInput = false)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo(command, arguments)
            {
                UseShellExecute = false,
                CreateNoWindow = true,
                RedirectStandardInput = redirectStandardInput,
                RedirectStandardOutput = true,
            };

            Process process = new Process()
            {
                StartInfo = startInfo
            };

            process.OutputDataReceived += receiveOutputData;

            process.Start();

            // These events must occur after start.
            process.BeginOutputReadLine();

            return process;
        }

        /// <summary>
        /// Configures and starts a process.
        /// </summary>s
        public Process Start(
            string command,
            string arguments,
            DataReceivedEventHandler receiveOutputData,
            DataReceivedEventHandler receiveErrorData,
            bool redirectStandardInput = false)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo(command, arguments)
            {
                UseShellExecute = false,
                CreateNoWindow = true,
                RedirectStandardError = true,
                RedirectStandardInput = redirectStandardInput,
                RedirectStandardOutput = true,
            };

            Process process = new Process()
            {
                StartInfo = startInfo
            };

            process.OutputDataReceived += receiveOutputData;
            process.ErrorDataReceived += receiveErrorData;

            process.Start();

            // These events must occur after start.
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();

            return process;
        }

        public int RunWithoutDefaultOutput_Synchronous(
            string command,
            string arguments)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo(command, arguments)
            {
                UseShellExecute = false,
                CreateNoWindow = true,
            };

            Process process = new Process()
            {
                StartInfo = startInfo
            };

            process.Start();

            process.WaitForExit();

            int exitCode = process.ExitCode; // Must get value before closing the process?

            process.Close();

            return exitCode;
        }

        public Process Run(Action<ProcessStartInfo> startInfoAction)
        {
            var startInfo = new ProcessStartInfo();

            startInfoAction(startInfo);

            var output = Process.Start(startInfo);
            return output;
        }

        public DataReceivedEventHandler GetErrorReceivedEventHandler(List<Exception> exceptions)
        {
            void Internal(object sender, DataReceivedEventArgs eventArgs)
            {
                this.Default_DataReceivedHandler(sender, eventArgs);

                // If not null.
                var exception = Instances.ExceptionOperator.Get_ErrorDataReceivedException(eventArgs);

                exceptions.Add(exception);
            }

            return Internal;
        }

        public int Run_ThrowIfAnyErrorOutput_Synchronous(
            string command,
            string arguments,
            DataReceivedEventHandler receiveOutputData)
        {
            List<Exception> exceptions = new List<Exception>();

            var exitCode = this.Run_Synchronous(
                command,
                arguments,
                receiveOutputData,
                this.GetErrorReceivedEventHandler(exceptions));

            if (exceptions.Any())
            {
                throw new AggregateException($"The command had error output. Exit code: {exitCode}", exceptions);
            }

            return exitCode;
        }

        public int Run_ThrowIfAnyErrorOutput_Synchronous(
            string command,
            string arguments)
        {
            var output = this.Run_ThrowIfAnyErrorOutput_Synchronous(
                command,
                arguments,
                this.Default_OutputReceivedHandler);

            return output;
        }

        public int Run_Synchronous(
            string command)
        {
            var exitCode = this.Run_Synchronous(
                command,
                Instances.Values.EmptyCommandArguments);

            return exitCode;
        }

        public int Run_Synchronous(
            string command,
            string arguments)
        {
            var exitCode = this.Run_Synchronous(
                command,
                arguments,
                this.Default_DataReceivedHandler,
                this.Default_DataReceivedHandler);

            return exitCode;
        }

        public void Run_ThrowIfErrorOrFailure_Synchronous(
            string command,
            string arguments)
        {
            List<Exception> exceptions = new List<Exception>();

            var exitCode = this.Run_Synchronous(
                command,
                arguments,
                this.Default_OutputReceivedHandler,
                this.GetErrorReceivedEventHandler(exceptions));

            var isFailure = Instances.ExitCodeOperator.IsFailure(exitCode);
            if (isFailure && exceptions.Any())
            {
                throw new AggregateException($"The command had error output. Exit code: {exitCode}", exceptions);
            }
        }

        public void Run_Synchronous_NoWait(
            string command)
        {
            this.Run_Synchronous_NoWait(
                command,
                Values.Instance.EmptyCommandArguments);
        }

        public void Run_Synchronous_NoWait(
            string command,
            string arguments)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo(command, arguments)
            {
                UseShellExecute = false,
                CreateNoWindow = true,
                RedirectStandardError = true,
                RedirectStandardOutput = true
            };

            Process process = new Process()
            {
                StartInfo = startInfo
            };

            process.Start();
        }

        public int Run_Synchronous(
            string command,
            string arguments,
            DataReceivedEventHandler receiveOutputData,
            DataReceivedEventHandler receiveErrorData)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo(command, arguments)
            {
                UseShellExecute = false,
                CreateNoWindow = true,
                RedirectStandardError = true,
                RedirectStandardOutput = true
            };

            Process process = new Process()
            {
                StartInfo = startInfo
            };

            process.OutputDataReceived += receiveOutputData;
            process.ErrorDataReceived += receiveErrorData;

            process.Start();
            process.BeginOutputReadLine(); // Must occur after start?
            process.BeginErrorReadLine(); // Must occur after start?

            process.WaitForExit();

            process.OutputDataReceived -= receiveOutputData;
            process.ErrorDataReceived -= receiveErrorData;

            int exitCode = process.ExitCode; // Must get value before closing the process?

            process.Close();

            return exitCode;
        }

        public Task<int> Run(
            string command)
        {
            return this.Run(
                command,
                null);
        }

        public Task<int> Run(
            string command,
            string arguments)
        {
            return this.Run(
                command,
                arguments,
                this.Default_DataReceivedHandler,
                this.Default_DataReceivedHandler);
        }

        public async Task<int> Run(
            string command,
            string arguments,
            DataReceivedEventHandler receiveOutputData,
            DataReceivedEventHandler receiveErrorData)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo(command, arguments)
            {
                UseShellExecute = false,
                CreateNoWindow = true,
                RedirectStandardError = true,
                RedirectStandardOutput = true,
                RedirectStandardInput = true
            };

            Process process = new Process()
            {
                StartInfo = startInfo
            };

            process.OutputDataReceived += receiveOutputData;
            process.ErrorDataReceived += receiveErrorData;

            process.Start();

            process.BeginOutputReadLine(); // Must occur after start?
            process.BeginErrorReadLine(); // Must occur after start?

            await process.WaitForExitAsync();

            process.OutputDataReceived -= receiveOutputData;
            process.ErrorDataReceived -= receiveErrorData;

            int exitCode = process.ExitCode; // Must get value before closing the process?

            process.Close();

            return exitCode;
        }
    }
}
