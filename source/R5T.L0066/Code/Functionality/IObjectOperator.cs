using System;

using F10Y.T0011;

using R5T.T0132;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface IObjectOperator : IFunctionalityMarker,
        F10Y.L0000.IObjectOperator
    {
#pragma warning disable IDE1006 // Naming Styles
        
        [Ignore]
        F10Y.L0000.IObjectOperator _F10Y_L0000 => F10Y.L0000.ObjectOperator.Instance;

#pragma warning restore IDE1006 // Naming Styles


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
    }
}
