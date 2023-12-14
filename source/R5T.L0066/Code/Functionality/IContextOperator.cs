using System;
using System.Collections.Generic;

using R5T.T0132;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface IContextOperator : IFunctionalityMarker
    {
        public void In_Context<TContext>(
            TContext context,
            IEnumerable<Action<TContext>> contextActions)
        {
            Instances.ActionOperator.Run_Actions(
                context,
                contextActions);
        }

        public void In_Context<TContext>(
            TContext context,
            params Action<TContext>[] contextActions)
        {
            Instances.ActionOperator.Run_Actions(
                context,
                contextActions);
        }
    }
}
