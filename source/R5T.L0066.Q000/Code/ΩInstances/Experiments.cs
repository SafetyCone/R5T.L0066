using System;


namespace R5T.L0066.Q000
{
    public class Experiments : IExperiments
    {
        #region Infrastructure

        public static IExperiments Instance { get; } = new Experiments();


        private Experiments()
        {
        }

        #endregion
    }
}
