using System;

using R5T.T0132;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface INowOperator : IFunctionalityMarker
    {
        /// <inheritdoc cref="F10Y.L0000.IDateTimeOperator.Get_Now"/>
		public DateTime Get_Now()
        {
            var output = Instances.DateTimeOperator.Get_Now();
            return output;
        }

        /// <inheritdoc cref="F10Y.L0000.IDateTimeOperator.Get_Now_Local"/>
        public DateTime Get_Now_Local()
        {
            var output = Instances.DateTimeOperator.Get_Now_Local();
            return output;
        }

        /// <inheritdoc cref="F10Y.L0000.IDateTimeOperator.Get_Now_Utc"/>
        public DateTime Get_Now_Utc()
        {
            var output = Instances.DateTimeOperator.Get_Now_Utc();
            return output;
        }

        /// <summary>
        /// Chooses <see cref="Get_Today_Local"/> as the default.
        /// </summary>
        public DateTime Get_Today()
        {
            var output = this.Get_Today_Local();
            return output;
        }

        public DateTime Get_Today_Local()
        {
            var now = this.Get_Now_Local();

            var output = now.Date;
            return output;
        }

        public DateTime Get_Today_Utc()
        {
            var now = this.Get_Now_Utc();

            var output = now.Date;
            return output;
        }

        /// <summary>
        /// Chooses <see cref="Get_CurrentYear_Local"/> as the default.
        /// </summary>
        public int Get_CurrentYear()
        {
            var currentYear = this.Get_CurrentYear_Local();
            return currentYear;
        }

        public int Get_CurrentYear_Local()
        {
            var nowLocal = this.Get_Now_Local();

            var currentYear = nowLocal.Year;
            return currentYear;
        }

        public int Get_CurrentYear_Utc()
        {
            var nowLocal = this.Get_Now_Utc();

            var currentYear = nowLocal.Year;
            return currentYear;
        }
    }
}
