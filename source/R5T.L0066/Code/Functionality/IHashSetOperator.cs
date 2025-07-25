using System;
using System.Collections.Generic;

using R5T.T0132;
using R5T.T0143;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface IHashSetOperator : IFunctionalityMarker,
        F10Y.L0000.IHashSetOperator
    {
#pragma warning disable IDE1006 // Naming Styles

        [Ignore]
        public F10Y.L0000.IHashSetOperator _F10Y_L0000 => F10Y.L0000.HashSetOperator.Instance;

#pragma warning restore IDE1006 // Naming Styles


        /// <summary>
        /// Quality-of-life overload for <see cref="F10Y.L0000.IHashSetOperator.New{T}"/>.
        /// </summary>
        public HashSet<T> Get_New<T>()
            => this.New<T>();
    }
}
