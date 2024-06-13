using System;


namespace R5T.L0066.Extensions
{
    public static class BooleanExtensions
    {
        /// <inheritdoc cref="R5T.L0066.IBooleanOperator.ToString_PascalCase(bool)"/>
        public static string ToString_PascalCase(this bool value)
        {
            var representation = Instances.BooleanOperator.ToString_PascalCase(value);
            return representation;
        }
    }
}
