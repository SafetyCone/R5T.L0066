using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using R5T.T0132;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface IContextOperator : IFunctionalityMarker
    {
        public Tuple<T1, T2> Get_ContextPropertiesSpecifier<T1, T2>()
        {
            return null;
        }

        public Tuple<TContextA, TContextB> Get_ContextSetSpecifier<TContextA, TContextB>()
        {
            // Return null;
            return null;
        }

        public Tuple<TContextA, TContextB, TContextC> Get_ContextSetSpecifier<TContextA, TContextB, TContextC>()
        {
            // Return null;
            return null;
        }

        public Tuple<TContextA, TContextB, TContextC, TContextD> Get_ContextSetSpecifier<TContextA, TContextB, TContextC, TContextD>()
        {
            // Return null;
            return null;
        }

        public Tuple<TContextA, TContextB, TContextC, TContextD, TContextE> Get_ContextSetSpecifier<TContextA, TContextB, TContextC, TContextD, TContextE>()
        {
            // Return null;
            return null;
        }

        public void In_Context<TContext>(
            Func<TContext> contextConstructor,
            IEnumerable<Action<TContext>> contextActions)
        {
            var context = contextConstructor();

            this.In_Context(
                context,
                contextActions);
        }

        public void In_Context<TContext>(
            Func<TContext> contextConstructor,
            params Action<TContext>[] contextActions)
        {
            this.In_Context(
                contextConstructor,
                contextActions.AsEnumerable());
        }

        public void In_Context<TContext>(
            TContext context,
            IEnumerable<Action<TContext>> contextActions)
        {
            Instances.ActionOperator.Run_Actions(
                context,
                contextActions);
        }

        public void In_Context<TContext>(
            TContext context,
            params Action<TContext>[] contextActions)
        {
            Instances.ActionOperator.Run_Actions(
                context,
                contextActions);
        }

        public Task In_Context<TContext>(
            Func<TContext> contextConstructor,
            IEnumerable<Func<TContext, Task>> contextActions)
        {
            var context = contextConstructor();

            return this.In_Context(
                context,
                contextActions);
        }

        public Task In_Context<TContext>(
            Func<TContext> contextConstructor,
            params Func<TContext, Task>[] contextActions)
        {
            return this.In_Context(
                contextConstructor,
                contextActions.AsEnumerable());
        }

        public async Task In_Context<TContext>(
            Func<Task<TContext>> contextConstructor,
            IEnumerable<Func<TContext, Task>> contextActions)
        {
            var context = await contextConstructor();

            await this.In_Context(
                context,
                contextActions);
        }

        public Task In_Context<TContext>(
            Func<Task<TContext>> contextConstructor,
            params Func<TContext, Task>[] contextActions)
        {
            return this.In_Context(
                contextConstructor,
                contextActions.AsEnumerable());
        }

        public Task In_Context_UsingParameterlessConstructor<TContext>(
            IEnumerable<Func<TContext, Task>> operations)
            where TContext : new()
        {
            var context = new TContext();

            return this.In_Context(
                context,
                operations);
        }

        public Task In_Context_UsingParameterlessConstructor<TContext>(
            params Func<TContext, Task>[] operations)
            where TContext : new()
            => this.In_Context_UsingParameterlessConstructor(
                operations.AsEnumerable());

        public Task In_Context<TContext>(
            IEnumerable<Func<TContext, Task>> operations)
            where TContext : new()
            => this.In_Context_UsingParameterlessConstructor(operations);

        public Task In_Context<TContext>(
            params Func<TContext, Task>[] operations)
            where TContext : new()
            => this.In_Context_UsingParameterlessConstructor(operations);

        public async Task In_Context<TContext>(
            Task<TContext> gettingContext,
            IEnumerable<Func<TContext, Task>> contextActions)
        {
            var context = await gettingContext;

            await this.In_Context(
                context,
                contextActions);
        }

        public Task In_Context<TContext>(
            Task<TContext> gettingContext,
            params Func<TContext, Task>[] contextActions)
        {
            return this.In_Context(
                gettingContext,
                contextActions.AsEnumerable());
        }

        public async Task In_Context<TContext>(
            TContext context,
            IEnumerable<Func<TContext, Task>> contextActions)
        {
            await Instances.ActionOperator.Run_Actions(
                context,
                contextActions);
        }

        public Task In_Context<TContext>(
            TContext context,
            params Func<TContext, Task>[] contextActions)
        {
            return this.In_Context(
                context,
                contextActions.AsEnumerable());
        }
    }
}
