using System;


namespace R5T.L0066
{
    public class TaskOperator : ITaskOperator
    {
        #region Infrastructure

        public static ITaskOperator Instance { get; } = new TaskOperator();


        private TaskOperator()
        {
        }

        #endregion
    }
}
