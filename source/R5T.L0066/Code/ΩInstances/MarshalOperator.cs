using System;


namespace R5T.L0066
{
    public class MarshalOperator : IMarshalOperator
    {
        #region Infrastructure

        public static IMarshalOperator Instance { get; } = new MarshalOperator();


        private MarshalOperator()
        {
        }

        #endregion
    }
}
