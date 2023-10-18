using System;
using System.Collections.Generic;

using R5T.T0142;


namespace R5T.N0000
{
    [UtilityTypeMarker]
    public class MethodBasedEqualityComparer<T> : IEqualityComparer<T>
    {
        public Func<T, T, bool> EqualsMethod { get; }
        public Func<T, int> GetHashCodeMethod { get; }


        public MethodBasedEqualityComparer(
            Func<T, T, bool> equalsMethod,
            Func<T, int> getHashCodeMethod)
        {
            this.EqualsMethod = equalsMethod;
            this.GetHashCodeMethod = getHashCodeMethod;
        }

        public bool Equals(T x, T y)
        {
            var areEqual = this.EqualsMethod(x, y);
            return areEqual;
        }

        public int GetHashCode(T obj)
        {
            var hashCode = this.GetHashCodeMethod(obj);
            return hashCode;
        }
    }
}
