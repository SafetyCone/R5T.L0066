using System;


namespace R5T.L0066
{
    public class MemberInfoOperator : IMemberInfoOperator
    {
        #region Infrastructure

        public static IMemberInfoOperator Instance { get; } = new MemberInfoOperator();


        private MemberInfoOperator()
        {
        }

        #endregion
    }
}
