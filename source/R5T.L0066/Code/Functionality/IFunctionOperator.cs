using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using R5T.T0132;
using R5T.T0143;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface IFunctionOperator : IFunctionalityMarker,
        F10Y.L0000.IFunctionOperator
    {
#pragma warning disable IDE1006 // Naming Styles

        [Ignore]
        F10Y.L0000.IFunctionOperator _F10Y_L0000 => F10Y.L0000.FunctionOperator.Instance;

#pragma warning restore IDE1006 // Naming Styles


        /// <summary>
        /// Get an instance of the function that always returns false.
        /// </summary>
        Func<T, bool> Get_ReturnFalse<T>()
            => x => true;

        /// <summary>
        /// Get an instance of the function that always returns true.
        /// </summary>
        Func<T, bool> Get_ReturnTrue<T>()
            => x => true;

        /// <summary>
        /// The function that, no matter its input, returns false.
        /// </summary>
        bool Return_False<T>(T _)
            => false;

        /// <summary>
        /// The function that, no matter its input, returns true.
        /// </summary>
        bool Return_True<T>(T _)
            => true;

        TOutput Run_OkIfDefault<T, TOutput>(
            T value,
            Func<T, TOutput> function = default)
        {
            var output = this.Run_Function_OkIfDefault(
                value,
                function);

            return output;
        }

        IEnumerable<TOutput> Run_Functions<T, TOutput>(
            T value,
            IEnumerable<Func<T, TOutput>> functions)
        {
            var output = functions
                .Select(function => this.Run_Function(
                    value,
                    function))
                ;

            return output;
        }

        public TOutput[] Run_Functions<T, TOutput>(
            T value,
            params Func<T, TOutput>[] functions)
        {
            var output = this.Run_Functions(
                value,
                functions.AsEnumerable())
                .ToArray();

            return output;
        }

        public TOut Run<T1, T2, TOut>(
            T1 value1,
            T2 value2,
            Func<T1, T2, TOut> function = default)
        {
            return this.Run_OkIfDefault(value1, value2, function);
        }

        public TOut Run_OkIfDefault<T1, T2, TOut>(
            T1 value1,
            T2 value2,
            Func<T1, T2, TOut> function = default)
        {
            var isNotDefault = Instances.DefaultOperator.Is_NotDefault(function);
            if(isNotDefault)
            {
                var output = function(value1, value2);
                return output;
            }

            // Else
            return default;
        }

        public Task Run<T1, T2>(
            T1 in1,
            T2 in2,
            Func<T1, T2, Task> function = default)
        {
            return this.Run_OkIfDefault(in1, in2, function);
        }

        public Task Run_OkIfDefault<TIn1, TIn2>(
            TIn1 in1,
            TIn2 in2,
            Func<TIn1, TIn2, Task> function = default)
        {
            var isNotDefault = Instances.DefaultOperator.Is_NotDefault(function);
            if (isNotDefault)
            {
                var output = function(in1, in2);
                return output;
            }

            // Else, return a completed task.
            return Task.CompletedTask;
        }
    }
}
