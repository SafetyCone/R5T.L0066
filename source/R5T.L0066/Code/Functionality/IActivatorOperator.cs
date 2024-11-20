using System;

using R5T.T0132;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface IActivatorOperator : IFunctionalityMarker
    {
        public object Create_Instance(Type type)
        {
            var output = Activator.CreateInstance(type, null);
            return output;
        }

        public T Create_Instance<T>(Type type)
            where T : class
        {
            var @object = this.Create_Instance(type);

            var output = (T)@object;
            return output;
        }
    }
}
