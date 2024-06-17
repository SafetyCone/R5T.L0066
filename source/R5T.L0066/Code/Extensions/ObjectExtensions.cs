using System;


namespace R5T.L0066.ArrayExtensions
{
    public static class ObjectExtensions
    {
        public static T[] To_Array<T>(this T value)
            => Instances.ArrayOperator.From(value);
    }
}
