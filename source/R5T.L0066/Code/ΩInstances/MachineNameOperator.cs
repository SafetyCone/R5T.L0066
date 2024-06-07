using System;


namespace R5T.L0066
{
    public class MachineNameOperator : IMachineNameOperator
    {
        #region Infrastructure

        public static IMachineNameOperator Instance { get; } = new MachineNameOperator();


        private MachineNameOperator()
        {
        }

        #endregion
    }
}
