using System;


namespace R5T.L0066
{
    public class Seeds : ISeeds
    {
        #region Infrastructure

        public static ISeeds Instance { get; } = new Seeds();


        private Seeds()
        {
        }

        #endregion
    }
}
