using System;
using System.Threading.Tasks;

using F10Y.T0011;

using R5T.T0131;


namespace R5T.L0066
{
    [ValuesMarker]
    public partial interface IActions : IValuesMarker,
        F10Y.L0000.IActions
    {
#pragma warning disable IDE1006 // Naming Styles

        [Ignore]
        F10Y.L0000.IActions _F10Y_L0000 => F10Y.L0000.Actions.Instance;

#pragma warning restore IDE1006 // Naming Styles


        /// <summary>
        /// The correct usage is:
        /// <code>public Action&lt;RepositoryContext&gt; Default => Instances.ActionOperations.DoNothing_Synchronous;</code>
        /// (No need for a double arrow, => ... => ...;)
        /// </summary>
        public void DoNothing_Synchronous<T>(T value)
        {
            // Do nothing.
        }

        public Task DoNothing()
        {
            // Do nothing.
            return Task.CompletedTask;
        }

        public Task DoNothing<T>(T value)
        {
            // Do nothing.
            return Task.CompletedTask;
        }

        public Task DoNothing<T1, T2>(T1 value1, T2 value2)
        {
            // Do nothing.
            return Task.CompletedTask;
        }
    }
}
