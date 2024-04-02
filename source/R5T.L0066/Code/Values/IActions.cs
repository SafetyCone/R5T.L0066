using System;
using System.Threading.Tasks;

using R5T.T0131;


namespace R5T.L0066
{
    [ValuesMarker]
    public partial interface IActions : IValuesMarker
    {
        /// <summary>
        /// The correct usage is:
        /// <code>public Action&lt;RepositoryContext&gt; Default => Instances.ActionOperations.DoNothing_Synchronous;</code>
        /// (No need for a double arrow, => ... => ...;)
        /// </summary>
        public void DoNothing_Synchronous<T>(T value)
        {
            // Do nothing.
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
