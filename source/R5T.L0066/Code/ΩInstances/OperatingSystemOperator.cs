using System;


namespace R5T.L0066
{
    public class OperatingSystemOperator : IOperatingSystemOperator
    {
        #region Infrastructure

        public static IOperatingSystemOperator Instance { get; } = new OperatingSystemOperator();


        private OperatingSystemOperator()
        {
        }

        #endregion
    }
}


namespace R5T.L0066.Internal
{
    public class OperatingSystemOperator : IOperatingSystemOperator
    {
        #region Infrastructure

        public static IOperatingSystemOperator Instance { get; } = new OperatingSystemOperator();


        private OperatingSystemOperator()
        {
        }

        #endregion
    }
}
