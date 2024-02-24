using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace R5T.L0066
{
    public partial interface IFunctionOperator
    {
        /// <summary>
        /// Given a value and a set of modifier functions (functions that take the value, and return a value of the same type),
        /// feed the value through the modifier functions.
        /// </summary>
        public T Run_Modifiers<T>(
            T value,
            IEnumerable<Func<T, T>> modifiers)
        {
            foreach (var modifier in modifiers)
            {
                value = this.Run_Modifier_OkIfDefault(
                    value,
                    modifier);
            }

            return value;
        }

        public T Run_Modifiers<T>(
            T value,
            params Func<T, T>[] modifiers)
        {
            var output = this.Run_Modifiers(
                value,
                modifiers.AsEnumerable());

            return output;
        }

        public T Run_Modifier<T>(
            T value,
            Func<T, T> modifier = default)
        {
            var output = this.Run_Modifier_OkIfDefault(
                value,
                modifier);

            return output;
        }

        public T Run_Modifier_OkIfDefault<T>(
            T value,
            Func<T, T> modifier = default)
        {
            var isDefault = Instances.DefaultOperator.Is_Default(modifier);
            if(isDefault)
            {
                return value;
            }

            // Else.
            var output = modifier(value);
            return output;
        }
    }
}
