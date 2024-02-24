using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using R5T.T0241;


namespace R5T.L0066
{
    [ContextOperationsMarker]
    public partial interface IContextOperations : IContextOperationsMarker
    {
        /// <summary>
        /// Does nothing.
        /// </summary>
        public Task Do_Nothing<TContext>(TContext context) => Task.CompletedTask;

        public Action<TContext> If<TContext>(
            bool condition,
            IEnumerable<Action<TContext>> operations)
        {
            return context =>
            {
                if (condition)
                {
                    Instances.ContextOperator.In_Context(
                        context,
                        operations);
                }
                // Else, do nothing.
            };
        }

        public Action<TContext> If<TContext>(
            bool condition,
            params Action<TContext>[] operations)
        {
            return this.If(
                condition,
                operations.AsEnumerable());
        }

        public Func<TContext, Task> If<TContext>(
            bool condition,
            IEnumerable<Func<TContext, Task>> operations)
        {
            return context =>
            {
                if(condition)
                {
                    return Instances.ContextOperator.In_Context(
                        context,
                        operations);
                }
                else
                {
                    return Task.CompletedTask;
                }
            };
        }

        public Func<TContext, Task> If<TContext>(
            bool condition,
            params Func<TContext, Task>[] operations)
        {
            return this.If(
                condition,
                operations.AsEnumerable());
        }

        public Func<TContext, Task> In_Context<TContext>(
            IEnumerable<Func<TContext, Task>> operations)
        {
            return context => Instances.ContextOperator.In_Context(
                context,
                operations);
        }

        public Func<TContext, Task> In_Context<TContext>(
            params Func<TContext, Task>[] operations)
        {
            return this.In_Context(
                operations.AsEnumerable());
        }

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

        public Func<TContext, Task> In_ChildContext<TContext, TChildContext>(
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

        public Func<TContext, Task> In_ChildContext<TContext, TChildContext>(
            // This can, and generally should, be a closure constructing method that takes in additional inputs beyond just the context instance to produce the child context instance.
            // Example: Func<TContext, TChildContext> Create_ChildContext(string a, string b, int i) { return context => new ChildContext(context, a, b, i); }
            Func<TContext, Task<TChildContext>> childContextConstructor,
            params Func<TChildContext, Task>[] childContextActions)
        {
            return this.In_ChildContext(
                childContextConstructor,
                childContextActions.AsEnumerable());
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
