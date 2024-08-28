using System;
using System.Collections.Generic;


using Instances = R5T.L0066.Instances;


namespace System
{
    public static class StackExtensions
    {
        public static bool Is_NotEmpty<T>(this Stack<T> stack)
        {
            var output = Instances.StackOperator.Is_NotEmpty(stack);
            return output;
        }

        public static bool Is_Empty<T>(this Stack<T> stack)
        {
            var output = Instances.StackOperator.Is_Empty(stack);
            return output;
        }

        public static bool Pop_OkIfEmpty<T>(this Stack<T> stack,
            out T value)
        {
            var output = Instances.StackOperator.Pop_OkIfEmpty(
                stack,
                out value);

            return output;
        }
    }
}


namespace R5T.L0066.Extensions.ForUris
{
    public static class StringExtensions
    {
        public static Uri To_Uri(this string uriText)
            => Instances.UriOperator.To_Uri(uriText);
    }
}
