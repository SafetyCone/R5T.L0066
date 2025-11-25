using System;
using System.Threading.Tasks;

using R5T.T0132;
using R5T.T0143;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface ITaskOperator : IFunctionalityMarker,
        F10Y.L0000.ITaskOperator
    {
#pragma warning disable IDE1006 // Naming Styles

        [Ignore]
        public F10Y.L0000.ITaskOperator _F10Y_L0000 => F10Y.L0000.TaskOperator.Instance;

#pragma warning restore IDE1006 // Naming Styles


        public Task<T> From_Function<T>(Func<Task<T>> function)
            => function();
    }
}
