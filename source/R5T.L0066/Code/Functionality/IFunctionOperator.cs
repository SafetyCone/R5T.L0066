using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using R5T.T0132;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface IFunctionOperator : IFunctionalityMarker
    {
        public TOut Run<TIn1, TIn2, TOut>(
            TIn1 in1,
            TIn2 in2,
            Func<TIn1, TIn2, TOut> function = default)
        {
            return this.Run_OkIfDefault(in1, in2, function);
        }

        public TOut Run_OkIfDefault<TIn1, TIn2, TOut>(
            TIn1 in1,
            TIn2 in2,
            Func<TIn1, TIn2, TOut> function = default)
        {
            var isNotDefault = Instances.DefaultOperator.Is_NotDefault(function);
            if(isNotDefault)
            {
                var output = function(in1, in2);
                return output;
            }

            // Else
            return default;
        }

        public Task Run<TIn1, TIn2>(
            TIn1 in1,
            TIn2 in2,
            Func<TIn1, TIn2, Task> function = default)
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

        /// <summary>
        /// Given a value and a set of modifier functions (functions that take the value, and return a value of the same type),
        /// feed the value through the modifier functions.
        /// </summary>
        public T Run_Modifiers<T>(
            T value,
            IEnumerable<Func<T, T>> modifiers)
        {
            foreach (var modifier in modifiers)
            {
                value = modifier(value);
            }

            return value;
        }
    }
}
