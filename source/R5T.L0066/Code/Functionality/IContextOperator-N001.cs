using System;
using System.Collections.Generic;
using System.Linq;

using R5T.T0132;


namespace R5T.L0066.N001
{
    [FunctionalityMarker]
    public partial interface IContextOperator<T> : IFunctionalityMarker
    {
        public T In_ModifyContext(
            T value,
            IEnumerable<Func<T, T>> modifiers)
        {
            var output = Instances.FunctionOperator.Run_Modifiers(
                value,
                modifiers);

            return output;
        }

        public T In_ModifyContext(
            T value,
            params Func<T, T>[] modifiers)
        {
            return this.In_ModifyContext(
                value,
                modifiers.AsEnumerable());
        }

        public T In_ModifyContext(
            Func<T> constructor,
            IEnumerable<Func<T, T>> modifiers)
        {
            var compilationUnit = constructor();

            var output = this.In_ModifyContext(
                compilationUnit,
                modifiers);

            return output;
        }

        public T In_ModifyContext(
            Func<T> constructor,
            params Func<T, T>[] modifiers)
        {
            return this.In_ModifyContext(
                constructor,
                modifiers.AsEnumerable());
        }
    }
}
