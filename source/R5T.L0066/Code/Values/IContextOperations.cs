using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using R5T.T0131;


namespace R5T.L0066
{
    [ValuesMarker]
    public partial interface IContextOperations : IValuesMarker
    {
        public Action<TContext> In_ChildContext<TContext, TChildContext>(
            // This can, and generally should, be a closure constructing method that takes in additional inputs beyond just the context instance to produce the child context instance.
            // Example: Func<TContext, TChildContext> Create_ChildContext(string a, string b, int i) { return context => new ChildContext(context, a, b, i); }
            Func<TContext, TChildContext> childContextConstructor,
            IEnumerable<Action<TChildContext>> childContextActions)
        {
            return context =>
            {
                var childContext = childContextConstructor(context);

                Instances.ContextOperator.In_Context(
                    childContext,
                    childContextActions);
            };
        }

        public Func<TContext, Task> In_ChildContext_O01<TContext, TChildContext>(
            // This can, and generally should, be a closure constructing method that takes in additional inputs beyond just the context instance to produce the child context instance.
            // Example: Func<TContext, TChildContext> Create_ChildContext(string a, string b, int i) { return context => new ChildContext(context, a, b, i); }
            Func<TContext, Task<TChildContext>> childContextConstructor,
            IEnumerable<Func<TChildContext, Task>> childContextActions)
        {
            return async context =>
            {
                var childContext = await childContextConstructor(context);

                await Instances.ContextOperator.In_Context(
                    childContext,
                    childContextActions);
            };
        }

        public Func<TContext, Task> In_ChildContext_O01<TContext, TChildContext>(
            // This can, and generally should, be a closure constructing method that takes in additional inputs beyond just the context instance to produce the child context instance.
            // Example: Func<TContext, TChildContext> Create_ChildContext(string a, string b, int i) { return context => new ChildContext(context, a, b, i); }
            Func<TContext, Task<TChildContext>> childContextConstructor,
            params Func<TChildContext, Task>[] childContextActions)
        {
            return this.In_ChildContext_O01<TContext, TChildContext>(
                childContextConstructor,
                childContextActions.AsEnumerable());
        }
    }
}
