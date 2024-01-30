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
        /// <summary>
        /// For use in design-time code construction.
        /// Allows hovering over the "context" variable to see the context type, and intellisense on the context variable to see its properties.
        /// </summary>
        /// <remarks>
        /// Useful when put first in a list of contextual operations,
        /// since it requires specifying the context type parameter (which is useful for displaying the context type as required by the C# compiler for sub-context operations),
        /// and since it allows (but does not require) a sub-operation (which is useful for getting intellisense on the properties of the context type).
        /// </remarks>
        public Func<TContext, Task> DisplayContext_AtDesignTime_ForAsynchronous<TContext>(Func<TContext, Task> operation = default)
        {
            return context => Instances.ContextOperator.In_Context(
                context,
                operation);
        }

        /// <inheritdoc cref="DisplayContext_AtDesignTime_ForAsynchronous{TContext}(Func{TContext, Task})"/>
        public Action<TContext> DisplayContext_AtDesignTime_Synchronous<TContext>(Action<TContext> operation = default)
        {
            return context => Instances.ContextOperator.In_Context(
                context,
                operation);
        }

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
            return this.In_ChildContext_O01(
                childContextConstructor,
                childContextActions.AsEnumerable());
        }
    }
}
