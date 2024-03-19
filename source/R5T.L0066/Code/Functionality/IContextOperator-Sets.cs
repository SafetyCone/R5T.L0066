using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace R5T.L0066
{
    public partial interface IContextOperator
    {
        public Task In_ContextSet(
            IEnumerable<Func<Task>> operations)
        {
            return Instances.ActionOperator.Run_Actions(
                operations);
        }

        public Task In_ContextSet(
            params Func<Task>[] operations)
        {
            return this.In_ContextSet(
                operations.AsEnumerable());
        }

        public Task In_ContextSet<TContext>(
            TContext context,
            IEnumerable<Func<TContext, Task>> operations)
        {
            return Instances.ActionOperator.Run_Actions(
                context,
                operations);
        }

        public Task In_ContextSet<TContextSet>(
            IEnumerable<Func<TContextSet, Task>> operations)
            where TContextSet : new()
        {
            var contextSet = new TContextSet();

            return this.In_ContextSet<TContextSet>(
                contextSet,
                operations);
        }

        /// <summary>
        /// Apply provided operations to an instance of the context set type.
        /// This instance is constructed by a parameterless constructor (thus the context set type must have a parameterless constructor).
        /// </summary>
        public Task In_ContextSet<TContextSet>(
            params Func<TContextSet, Task>[] operations)
            where TContextSet : new()
        {
            return this.In_ContextSet<TContextSet>(
                operations.AsEnumerable());
        }

        public Task In_ContextSet<TContext>(
            TContext context,
            params Func<TContext, Task>[] operations)
        {
            return this.In_ContextSet(
                context,
                operations.AsEnumerable());
        }

        public async Task In_ContextSet<TContext>(
            Func<Task<TContext>> contextConstructor,
            IEnumerable<Func<TContext, Task>> operations)
        {
            var context = await contextConstructor();

            await this.In_ContextSet<TContext>(
                context,
                operations);
        }

        public Task In_ContextSet<TContext>(
            Func<Task<TContext>> contextConstructor,
            params Func<TContext, Task>[] contextActions)
        {
            return this.In_ContextSet(
                contextConstructor,
                contextActions.AsEnumerable());
        }

        public Task In_ContextSet<TContextA, TContextB>(
            TContextA contextA,
            TContextB contextB,
            IEnumerable<Func<TContextA, TContextB, Task>> contextActions = default)
        {
            return Instances.ActionOperator.Run_Actions<TContextA, TContextB>(
                contextA,
                contextB,
                contextActions);
        }

        public Task In_ContextSet<TContextA, TContextB>(
            TContextA contextA,
            TContextB contextB,
            params Func<TContextA, TContextB, Task>[] contextActions)
        {
            return this.In_ContextSet(
                contextA,
                contextB,
                contextActions.AsEnumerable());
        }

        public Task In_ContextSet<TContextA, TContextB, TContextC>(
            TContextA contextA,
            TContextB contextB,
            TContextC contextC,
            IEnumerable<Func<TContextA, TContextB, TContextC, Task>> contextActions)
        {
            return Instances.ActionOperator.Run_Actions(
                contextA,
                contextB,
                contextC,
                contextActions);
        }

        public Task In_ContextSet<TContextA, TContextB, TContextC>(
            TContextA contextA,
            TContextB contextB,
            TContextC contextC,
            params Func<TContextA, TContextB, TContextC, Task>[] contextActions)
        {
            return this.In_ContextSet(
                contextA,
                contextB,
                contextC,
                contextActions.AsEnumerable());
        }

        public Task In_ContextSet<TContextA, TContextB, TContextC, TContextD>(
            TContextA contextA,
            TContextB contextB,
            TContextC contextC,
            TContextD contextD,
            IEnumerable<Func<TContextA, TContextB, TContextC, TContextD, Task>> contextActions)
        {
            return Instances.ActionOperator.Run_Actions(
                contextA,
                contextB,
                contextC,
                contextD,
                contextActions);
        }

        public Task In_ContextSet<TContextA, TContextB, TContextC, TContextD>(
            TContextA contextA,
            TContextB contextB,
            TContextC contextC,
            TContextD contextD,
            params Func<TContextA, TContextB, TContextC, TContextD, Task>[] contextActions)
        {
            return this.In_ContextSet(
                contextA,
                contextB,
                contextC,
                contextD,
                contextActions.AsEnumerable());
        }

        public Task In_ContextSet<TContextA, TContextB, TContextC, TContextD, TContextE>(
            TContextA contextA,
            TContextB contextB,
            TContextC contextC,
            TContextD contextD,
            TContextE contextE,
            IEnumerable<Func<TContextA, TContextB, TContextC, TContextD, TContextE, Task>> contextActions)
        {
            return Instances.ActionOperator.Run_Actions(
                contextA,
                contextB,
                contextC,
                contextD,
                contextE,
                contextActions);
        }

        public Task In_ContextSet<TContextA, TContextB, TContextC, TContextD, TContextE>(
            TContextA contextA,
            TContextB contextB,
            TContextC contextC,
            TContextD contextD,
            TContextE contextE,
            params Func<TContextA, TContextB, TContextC, TContextD, TContextE, Task>[] contextActions)
        {
            return this.In_ContextSet(
                contextA,
                contextB,
                contextC,
                contextD,
                contextE,
                contextActions.AsEnumerable());
        }
    }
}
