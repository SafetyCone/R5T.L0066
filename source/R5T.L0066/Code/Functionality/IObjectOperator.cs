using System;

using R5T.T0132;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface IObjectOperator : IFunctionalityMarker
    {
        public TOutput As<TInput, TOutput>(TInput @object)
            where TOutput : class
        {
            var output = @object as TOutput;
            return output;
        }

        public T ModifyAndReturn<T>(
            T value,
            Action<T> modification)
        {
            modification(value);

            return value;
        }

        public void ModifyIf<T>(
            T @object,
            bool condition,
            Action<T> modifyAction)
        {
            if (condition)
            {
                modifyAction(@object);
            }
        }

        public T Verify_IsType<T>(object @object)
        {
            if (@object is T output)
            {
                return output;
            }
            else
            {
                throw new Exception("Type verification failed.");
            }
        }

        public string To_String<T>(T value)
            => value.ToString();
    }
}
