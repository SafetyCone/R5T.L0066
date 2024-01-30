using System;
using System.Threading.Tasks;

using R5T.T0131;


namespace R5T.L0066
{
    [ValuesMarker]
    public partial interface IFunctions : IValuesMarker
    {
        /// <summary>
        /// An asynchronous function that consumes any type.
        /// </summary>
        /// <remarks>
        /// Function takes in an object, which allows it to be used anywhere at Func&lt;T, Task&gt; is required.
        /// It would specify a generic type T, but properties cannot be generic with the containing type being generic
        /// (only methods can be generic without the containing type being generic, and making this a method would create awkwardness at the site of use).
        /// </remarks>
        public Func<object, Task> Do_Nothing => x => Task.CompletedTask;
    }
}
