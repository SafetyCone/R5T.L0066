using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace R5T.L0066
{
    public partial interface IActionOperator
    {
        public Task Run_Action<TValue1, TValue2>(
            TValue1 value1,
            TValue2 value2,
            Func<TValue1, TValue2, Task> action)
        {
            return this.Run_Action_OkIfDefault(
                value1,
                value2,
                action);
        }

        public Task Run_Action_OkIfDefault<TValue1, TValue2>(
            TValue1 value1,
            TValue2 value2,
            Func<TValue1, TValue2, Task> action = default)
        {
            if (action == default)
            {
                return Task.CompletedTask;
            }

            return action(value1, value2);
        }

        public async Task Run_Actions<TValue1, TValue2>(
            TValue1 value1,
            TValue2 value2,
            IEnumerable<Func<TValue1, TValue2, Task>> actions)
        {
            foreach (var action in actions)
            {
                await this.Run_Action(
                    value1,
                    value2,
                    action);
            }
        }

        public Task Run_Action<TValue1, TValue2, TValue3>(
            TValue1 value1,
            TValue2 value2,
            TValue3 value3,
            Func<TValue1, TValue2, TValue3, Task> action)
        {
            return this.Run_Action_OkIfDefault(
                value1,
                value2,
                value3,
                action);
        }

        public Task Run_Action_OkIfDefault<TValue1, TValue2, TValue3>(
            TValue1 value1,
            TValue2 value2,
            TValue3 value3,
            Func<TValue1, TValue2, TValue3, Task> action = default)
        {
            if (action == default)
            {
                return Task.CompletedTask;
            }

            return action(value1, value2, value3);
        }

        public async Task Run_Actions<TValue1, TValue2, TValue3>(
            TValue1 value1,
            TValue2 value2,
            TValue3 value3,
            IEnumerable<Func<TValue1, TValue2, TValue3, Task>> actions)
        {
            foreach (var action in actions)
            {
                await this.Run_Action(
                    value1,
                    value2,
                    value3,
                    action);
            }
        }

        public Task Run_Action<TValue1, TValue2, TValue3, TValue4>(
            TValue1 value1,
            TValue2 value2,
            TValue3 value3,
            TValue4 value4,
            Func<TValue1, TValue2, TValue3, TValue4, Task> action)
        {
            return this.Run_Action_OkIfDefault(
                value1,
                value2,
                value3,
                value4,
                action);
        }

        public Task Run_Action_OkIfDefault<TValue1, TValue2, TValue3, TValue4>(
            TValue1 value1,
            TValue2 value2,
            TValue3 value3,
            TValue4 value4,
            Func<TValue1, TValue2, TValue3, TValue4, Task> action = default)
        {
            if (action == default)
            {
                return Task.CompletedTask;
            }

            return action(value1, value2, value3, value4);
        }

        public async Task Run_Actions<TValue1, TValue2, TValue3, TValue4>(
            TValue1 value1,
            TValue2 value2,
            TValue3 value3,
            TValue4 value4,
            IEnumerable<Func<TValue1, TValue2, TValue3, TValue4, Task>> actions)
        {
            foreach (var action in actions)
            {
                await this.Run_Action(
                    value1,
                    value2,
                    value3,
                    value4,
                    action);
            }
        }

        public Task Run_Action<TValue1, TValue2, TValue3, TValue4, TValue5>(
            TValue1 value1,
            TValue2 value2,
            TValue3 value3,
            TValue4 value4,
            TValue5 value5,
            Func<TValue1, TValue2, TValue3, TValue4, TValue5, Task> action)
        {
            return this.Run_Action_OkIfDefault(
                value1,
                value2,
                value3,
                value4,
                value5,
                action);
        }

        public Task Run_Action_OkIfDefault<TValue1, TValue2, TValue3, TValue4, TValue5>(
            TValue1 value1,
            TValue2 value2,
            TValue3 value3,
            TValue4 value4,
            TValue5 value5,
            Func<TValue1, TValue2, TValue3, TValue4, TValue5, Task> action = default)
        {
            if (action == default)
            {
                return Task.CompletedTask;
            }

            return action(value1, value2, value3, value4, value5);
        }

        public async Task Run_Actions<TValue1, TValue2, TValue3, TValue4, TValue5>(
            TValue1 value1,
            TValue2 value2,
            TValue3 value3,
            TValue4 value4,
            TValue5 value5,
            IEnumerable<Func<TValue1, TValue2, TValue3, TValue4, TValue5, Task>> actions)
        {
            foreach (var action in actions)
            {
                await this.Run_Action(
                    value1,
                    value2,
                    value3,
                    value4,
                    value5,
                    action);
            }
        }
    }
}
