using System;

using R5T.T0132;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface IDateOperator : IFunctionalityMarker
    {
        public DateTime GetDefault()
        {
            var output = default(DateTime);
            return output;
        }

        public DateTime GetMaximum()
        {
            var output = DateTime.MaxValue;
            return output;
        }

        public DateTime GetMinimum()
        {
            var output = DateTime.MinValue;
            return output;
        }

        public DateTime GetNow_Local()
        {
            var output = DateTime.Now;
            return output;
        }

        public DateTime GetNow_Utc()
        {
            var output = DateTime.UtcNow;
            return output;
        }

        /// <summary>
        /// Chooses <see cref="GetNow_Local"/> as the default.
        /// </summary>
        public DateTime GetNow()
        {
            var output = this.GetNow_Local();
            return output;
        }

        public DateTime From_YYYYMMDD(string yyyymmdd)
        {
            var output = Instances.DateTimeOperator.ParseExact(
                yyyymmdd,
                Instances.DateTimeFormats.YYYYMMDD);

            return output;
        }

        public DateTime GetTomorrow(DateTime dateTime)
        {
            var tomorrow = dateTime.AddDays(1);
            return tomorrow;
        }

        public DateTime GetTomorrow_Local()
        {
            var todayLocal = this.Get_Today_Local();

            var tomorrowLocal = this.GetTomorrow(todayLocal);
            return tomorrowLocal;
        }

        public DateTime GetTomorrow_Utc()
        {
            var todayUtc = this.Get_Today_Utc();

            var tomorrowUtc = this.GetTomorrow(todayUtc);
            return tomorrowUtc;
        }

        /// <summary>
        /// Chooses <see cref="GetTomorrow_Local"/> as the default.
        /// </summary>
        public DateTime GetTomorrow()
        {
            var tomorrow = this.GetTomorrow_Local();
            return tomorrow;
        }

        public DateTime GetToday_Local()
        {
            var nowLocal = Instances.DateTimeOperator.Get_Now_Local();

            var todayLocal = this.Get_Day(nowLocal);
            return todayLocal;
        }

        /// <summary>
        /// Chooses <see cref="GetToday_Local"/> as the default.
        /// </summary>
        public DateTime GetToday()
        {
            var today = this.GetToday_Local();
            return today;
        }

        public DateTime Get_Day(DateTime now)
        {
            var output = new DateTime(
                now.Year,
                now.Month,
                now.Day);

            return output;
        }

        public DateTime Get_Today_Local()
        {
            var nowLocal = Instances.NowOperator.Get_Now_Local();

            var todayLocal = this.Get_Day(nowLocal);
            return todayLocal;
        }

        public DateTime Get_Today_Utc()
        {
            var nowUtc = Instances.NowOperator.Get_Now_Utc();

            var todayUtc = this.Get_Day(nowUtc);
            return todayUtc;
        }

        public DateTime GetToday_Utc()
            => this.Get_Today_Utc();

        /// <summary>
        /// Chooses <see cref="Get_Today_Local"/> as the default.
        /// </summary>
        public DateTime Get_Today()
        {
            var today = this.Get_Today_Local();
            return today;
        }

        public string Get_YYYYMMDDFormatTemplate()
        {
            var yyyyMMddFormatTemplate = $"{{0:{Instances.DateTimeFormats.YYYYMMDD}}}";
            return yyyyMMddFormatTemplate;
        }

        public DateTime GetYesterday()
        {
            var today = this.GetToday();

            var yesterday = today.AddDays(-1);
            return yesterday;
        }

        public string ToString_YYYYMMDD(DateTime date)
        {
            var formatTemplate = this.Get_YYYYMMDDFormatTemplate();

            var output = Instances.DateTimeOperator.Format(
                date,
                formatTemplate);

            return output;
        }
    }
}
