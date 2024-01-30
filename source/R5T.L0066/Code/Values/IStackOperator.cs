using System;
using System.Collections.Generic;

using R5T.T0131;


namespace R5T.L0066
{
    [ValuesMarker]
    public partial interface IStackOperator : IValuesMarker
    {
        public bool Is_NotEmpty<T>(Stack<T> stack)
        {
            var output = stack.Count > 0;
            return output;
        }

        public bool Is_Empty<T>(Stack<T> stack)
        {
            var output = stack.Count < 1;
            return output;
        }

        public bool Pop_OkIfEmpty<T>(
            Stack<T> stack,
            out T value)
        {
            var isNotEmpty = this.Is_NotEmpty(stack);

            value = isNotEmpty
                ? stack.Pop()
                : default
                ;

            var output = isNotEmpty;
            return output;
        }
    }
}
