using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using R5T.T0132;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface IConstructionOperator : IFunctionalityMarker
    {
        public TValue Create<TValue>(
           Func<TValue> constructor,
           params Action<TValue>[] modifiers)
        {
            var value = this.Create(
                constructor,
                modifiers.AsEnumerable());

            return value;
        }

        public TValue Create<TValue>(
            Func<TValue> constructor,
            IEnumerable<Action<TValue>> modifiers)
        {
            var value = constructor();

            Instances.ActionOperator.Run_Actions(
                value,
                modifiers);

            return value;
        }

        public async Task<TValue> Create<TValue>(
            Func<Task<TValue>> constructor,
            params Func<TValue, Task>[] modifiers)
        {
            var value = await constructor();

            await Instances.ActionOperator.Run(
                value,
                modifiers);

            return value;
        }

        public async Task<TValue> New<TValue>(
            Func<Task<TValue>> constructor,
            params Func<TValue, Task>[] modifiers)
        {
            var value = await this.Create(
                constructor,
                modifiers);

            return value;
        }

        public Func<Task<TValue>> Get_New<TValue>(
            Func<Task<TValue>> constructor,
            params Func<TValue, Task>[] modifiers)
        {
            return () => this.New(
                constructor,
                modifiers);
        }
    }
}
