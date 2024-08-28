using System;
using System.Threading.Tasks;


namespace R5T.L0066.Extensions
{
    public static class TaskExtensions
    {
        public static async Task<T> With_Continuation_Action<T>(this Task<T> gettingValue,
            Action<T> valueAction)
        {
            var value = await gettingValue;

            valueAction(value);

            return value;
        }

        public static async Task<T> With_Continuation_ModifierFunction<T>(this Task<T> gettingValue,
            Func<T, T> valueModiferFunction)
        {
            var value = await gettingValue;

            var output = valueModiferFunction(value);

            return output;
        }
    }
}
