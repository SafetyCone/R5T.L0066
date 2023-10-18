using System;
using System.Collections.Generic;

using R5T.T0142;


namespace R5T.N0000
{
    /// <summary>
    /// An equality comparer for <see cref="Type"/> instances that uses only the name value (<see cref="System.Reflection.MemberInfo.Name"/>).
    /// </summary>
    [UtilityTypeMarker]
    public class NameBasedTypeEqualityComparer : IEqualityComparer<Type>
    {
        #region Static

        public static NameBasedTypeEqualityComparer Instance { get; } = new NameBasedTypeEqualityComparer();

        #endregion


        public bool Equals(Type x, Type y)
        {
            var output = x.Name == y.Name;
            return output;
        }

        public int GetHashCode(Type obj)
        {
            var output = obj.Name.GetHashCode();
            return output;
        }
    }
}
