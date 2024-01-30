using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using R5T.T0132;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface IActionOperator : IFunctionalityMarker
    {
        /// <summary>
        /// Chooses <see cref="Run_Action_OkIfDefault{TValue}(TValue, Action{TValue})"/> as the default.
        /// </summary>
        public void Run_Action<TValue>(
            TValue value,
            Action<TValue> action)
        {
            this.Run_Action_OkIfDefault(
                value,
                action);
        }

        public Task Run_Action<TValue>(
            TValue value,
            Func<TValue, Task> action)
        {
            return this.Run_Action_OkIfDefault(
                value,
                action);
        }

        public void Run_OkIfDefault<TValue>(
            TValue value,
            Action<TValue> action = default)
        {
            this.Run_Action_OkIfDefault(
                value,
                action);
        }

        public void Run_Action_OkIfDefault<TValue>(
            TValue value,
            Action<TValue> action = default)
        {
            if (action == default)
            {
                return;
            }

            action(value);
        }

        public Task Run_Action_OkIfDefault<TValue>(
            TValue value,
            Func<TValue, Task> action = default)
        {
            if (action == default)
            {
                return Task.CompletedTask;
            }

            return action(value);
        }

        public void Run_Actions<TValue>(
            TValue value,
            IEnumerable<Action<TValue>> actions)
        {
            foreach (var action in actions)
            {
                this.Run_Action(
                    value,
                    action);
            }
        }

        /// <summary>
        /// Chooses <see cref="Run_Actions{TValue}(TValue, Action{TValue}[])"/> as the default.
        /// </summary>
        public void Run<TValue>(
            TValue value,
            params Action<TValue>[] actions)
        {
            this.Run_Actions(
                value,
                actions);
        }

        public void Run_Actions<TValue>(
            TValue value,
            params Action<TValue>[] actions)
        {
            this.Run_Actions(
                value,
                actions.AsEnumerable());
        }

        public async Task Run_Actions<TValue>(
            TValue value,
            IEnumerable<Func<TValue, Task>> actions)
        {
            foreach (var action in actions)
            {
                await this.Run_Action(
                    value,
                    action);
            }
        }

        public async Task Run_Actions<TValue>(
            TValue value,
            params Func<TValue, Task>[] actions)
        {
            foreach (var action in actions)
            {
                await this.Run_Action(
                    value,
                    action);
            }
        }

        /// <summary>
		/// Chooses <see cref="Run_Function_OkIfDefault{T, TOutput}(T, Func{T, TOutput})"/> as the default.
		/// </summary>
        public TOutput Run<T, TOutput>(
            T value,
            Func<T, TOutput> function)
        {
            var output = this.Run_Function_OkIfDefault(
                value,
                function);

            return output;
        }

        /// <summary>
        /// Chooses <see cref="Run_Function_OkIfDefault{T, TOutput}(T, Func{T, TOutput})"/> as the default.
        /// </summary>
        public TOutput Run_Function<T, TOutput>(
            T value,
            Func<T, TOutput> function)
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

        public TOutput Run_Function_OkIfDefault<T, TOutput>(
            T value,
            Func<T, TOutput> function = default)
        {
            if (function == default)
            {
                return default;
            }

            var output = function(value);
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
            Func<T, TOutput>[] functions)
        {
            var output = this.Run_Functions(
                value,
                functions.AsEnumerable())
                .Now();

            return output;
        }

        public Task Run<TValue>(
            TValue value,
            params Func<TValue, Task>[] actions)
        {
            return this.Run_Actions(
                value,
                actions);
        }
    }
}
