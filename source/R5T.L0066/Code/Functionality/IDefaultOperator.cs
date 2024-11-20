using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using R5T.T0132;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface IDefaultOperator : IFunctionalityMarker
    {
        public T Get_Default<T>()
        {
            T output = default;
            return output;
        }

        public bool Is_Default<T>(
            T value,
            IEqualityComparer<T> equalityComparer)
        {
            var output = equalityComparer.Equals(value, default);
            return output;
        }

        public bool Is_Default<T>(T value)
        {
            var equalityComparer = EqualityComparer<T>.Default;

            var output = this.Is_Default(
                value,
                equalityComparer);

            return output;
        }

        public bool Is_NotDefault<T>(T value)
        {
            var isDefault = this.Is_Default(value);

            var output = !isDefault;
            return output;
        }

        public void Verify_NotDefault<T>(T value)
        {
            var is_Default = this.Is_Default(value);

            if (is_Default)
            {
                throw new Exception("Default value encountered.");
            }
        }
    }
}
