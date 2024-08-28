using System;
using System.Threading.Tasks;

using R5T.T0132;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface ITaskOperator : IFunctionalityMarker
    {
        public Task<T> From_Function<T>(Func<Task<T>> function)
            => function();

        public async Task<(T1, T2)> When_All<T1, T2>((Task<T1>, Task<T2>) tasks)
        {
            await Task.WhenAll(
                tasks.Item1,
                tasks.Item2);

            var output = (
                tasks.Item1.Result,
                tasks.Item2.Result);

            return output;
        }

        public async Task<(T1, T2, T3)> When_All<T1, T2, T3>((Task<T1>, Task<T2>, Task<T3>) tasks)
        {
            await Task.WhenAll(
                tasks.Item1,
                tasks.Item2,
                tasks.Item3);

            var output = (
                tasks.Item1.Result,
                tasks.Item2.Result,
                tasks.Item3.Result);

            return output;
        }
    }
}
