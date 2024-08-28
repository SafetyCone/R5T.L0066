using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using R5T.T0132;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface IFunctionOperator : IFunctionalityMarker
    {
        /// <summary>
        /// Get an instance of the function that always returns true.
        /// </summary>
        public Func<T, bool> Get_ReturnTrue<T>()
            => x => true;

        /// <summary>
        /// The function that, no matter its input, returns true.
        /// </summary>
        public bool Return_True<T>(T _)
            => true;

        /// <summary>
		/// Chooses <see cref="Run_Function_OkIfDefault{T, TOutput}(T, Func{T, TOutput})"/> as the default.
		/// </summary>
        public TOutput Run<T, TOutput>(
            T value,
            Func<T, TOutput> function = default)
        {
            var output = this.Run_Function(
                value,
                function);

            return output;
        }

        /// <summary>
        /// Chooses <see cref="Run_Function_OkIfDefault{T, TOutput}(T, Func{T, TOutput})"/> as the default.
        /// </summary>
        public TOutput Run_Function<T, TOutput>(
            T value,
            Func<T, TOutput> function = default)
        {
            var output = this.Run_Function_OkIfDefault(
                value,
                function);

            return output;
        }

        public TOutput Run_OkIfDefault<T, TOutput>(
            T value,
            Func<T, TOutput> function = default)
        {
            var output = this.Run_Function_OkIfDefault(
                value,
                function);

            return output;
        }

        public IEnumerable<TOutput> Run_Functions<T, TOutput>(
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
                .Now();

            return output;
        }

        public TOutput Run_Function_OkIfDefault<T, TOutput>(
            T value,
            Func<T, TOutput> function = default)
        {
            var isNotDefault = Instances.DefaultOperator.Is_NotDefault(function);
            if (isNotDefault)
            {
                var output = function(value);
                return output;
            }

            // Else
            return default;
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
