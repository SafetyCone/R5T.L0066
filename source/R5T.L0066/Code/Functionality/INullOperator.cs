using System;

using R5T.T0132;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface INullOperator : IFunctionalityMarker
    {
        public bool Is_NotNull<T>(T value)
            where T : class
        {
            // A great, quick null check.
            var output = value is object;
            return output;
        }

        public bool Is_Null<T>(T value)
            where T : class
        {
            var output = value is null;
            return output;
        }
    }
}
