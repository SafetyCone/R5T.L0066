using System;
using System.Runtime.InteropServices;

using R5T.T0132;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface IMarshalOperator : IFunctionalityMarker
    {
        /// <summary>
        /// Chooses <see cref="Release_ComObject_WithNullCheck(object)"/> as the default.
        /// </summary>
        public int Release_ComObject(object @object)
            => this.Release_ComObject_WithNullCheck(@object);

        public int Release_ComObject_WithNullCheck(object @object)
        {
            var is_NotNull = Instances.NullOperator.Is_NotNull(@object);

            var output = is_NotNull
                ? this.Release_ComObject_WithoutNullCheck(@object)
                : Instances.Integers.NegativeOne
                ;

            return output;
        }

        public int Release_ComObject_WithoutNullCheck(object @object)
        {
            var output = Marshal.ReleaseComObject(@object);
            return output;
        }

        /// <summary>
        /// Chooses <see cref="FinalRelease_ComObject_WithNullCheck(object)"/> as the default.
        /// </summary>
        public int FinalRelease_ComObject(object @object)
            => this.FinalRelease_ComObject_WithNullCheck(@object);

        public int FinalRelease_ComObject_WithNullCheck(object @object)
        {
            var is_NotNull = Instances.NullOperator.Is_NotNull(@object);

            var output = is_NotNull
                ? this.FinalRelease_ComObject_WithoutNullCheck(@object)
                : Instances.Integers.NegativeOne
                ;

            return output;
        }

        public int FinalRelease_ComObject_WithoutNullCheck(object @object)
        {
            var output = Marshal.FinalReleaseComObject(@object);
            return output;
        }
    }
}
