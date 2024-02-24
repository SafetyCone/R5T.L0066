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
        public Task Run_Action_OkIfDefault(
            Func<Task> action = default)
        {
            if (action == default)
            {
                return Task.CompletedTask;
            }

            return action();
        }

        public Task Run_Action(
            Func<Task> action)
        {
            return this.Run_Action_OkIfDefault(
                action);
        }

        public Task Run_OkIfDefault(
            Func<Task> action = default)
        {
            return this.Run_Action_OkIfDefault(
                action);
        }

        public async Task Run_Actions(
            IEnumerable<Func<Task>> actions)
        {
            foreach (var action in actions)
            {
                await this.Run_Action(
                    action);
            }
        }

        public Task Run_Actions(
            params Func<Task>[] actions)
        {
            return this.Run_Actions(
                actions.AsEnumerable());
        }

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

        public Task Run_OkIfDefault<TValue>(
            TValue value,
            Func<TValue, Task> action = default)
        {
            return this.Run_Action_OkIfDefault(
                value,
                action);
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
