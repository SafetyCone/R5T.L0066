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
        public TOut Run_Function<TIn, TOut>(
            TIn @in,
            Func<TIn, TOut> function = default)
        {
            return this.Run_Function_OkIfDefault(@in, function);
        }

        public TOut Run_Function_OkIfDefault<TIn, TOut>(
            TIn @in,
            Func<TIn, TOut> function = default)
        {
            var isNotDefault = Instances.DefaultOperator.Is_NotDefault(function);
            if (isNotDefault)
            {
                var output = function(@in);
                return output;
            }

            // Else
            return default;
        }

        public TOut Run<TIn, TOut>(
            TIn @in,
            Func<TIn, TOut> function = default)
        {
            return this.Run_Function(@in, function);
        }

        public TOut Run_OkIfDefault<TIn, TOut>(
            TIn @in,
            Func<TIn, TOut> function = default)
        {
            return this.Run_Function_OkIfDefault(
                @in,
                function);
        }

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
                value = this.Run_Modifier_OkIfDefault(
                    value,
                    modifier);
            }

            return value;
        }

        public T Run_Modifiers<T>(
            T value,
            params Func<T, T>[] modifiers)
        {
            var output = this.Run_Modifiers(
                value,
                modifiers.AsEnumerable());

            return output;
        }

        public T Run_Modifier<T>(
            T value,
            Func<T, T> modifier = default)
        {
            var output = this.Run_Modifier_OkIfDefault(
                value,
                modifier);

            return output;
        }

        public T Run_Modifier_OkIfDefault<T>(
            T value,
            Func<T, T> modifier = default)
        {
            var isDefault = Instances.DefaultOperator.Is_Default(modifier);
            if(isDefault)
            {
                return value;
            }

            // Else.
            var output = modifier(value);
            return output;
        }

        public TOut Run<TIn, TOut>(
            TIn @in,
            IEnumerable<Func<TIn, TOut>> functions)
        {
            return this.Run(
                @in,
                functions);
        }

        //public async Task Run_Functions<TValue>(
        //    TValue value,
        //    IEnumerable<Func<TValue, TValue>> actions)
        //{
        //    foreach (var action in actions)
        //    {
        //        await this.Run_Function(
        //            value,
        //            action);
        //    }
        //}

        //public async Task Run_Functions<TValue>(
        //    TValue value,
        //    params Func<TValue, TValue>[] actions)
        //{
        //    foreach (var action in actions)
        //    {
        //        await this.Run_Function(
        //            value,
        //            action);
        //    }
        //}
    }
}
