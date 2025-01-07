using System;

using R5T.T0132;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface IDateOperator : IFunctionalityMarker
    {
        public DateTime From(int year, int month, int day)
            => new DateTime(year, month, day);

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

        public DateTime Get_NthFromLastDayOfWeek_OfMonth(int year, int month, int n, DayOfWeek dayOfWeek)
        {
            // What day is the first of the month?
            var lastOfMonth = this.Get_LastOfMonth(year, month);

            var lastOfMonth_DayOfWeek = lastOfMonth.DayOfWeek;

            var daysToPriorDayOfWeek = Instances.DayOfWeekOperator.Get_DaysToPriorDayOfWeek_Inclusive(
                lastOfMonth_DayOfWeek,
                dayOfWeek);

            // n - 1, since we already got to the first day of the week in the month.
            var fullWeekDays = (n - 1) * IValues.DaysInWeek_Constant;

            // + 1, to get the actual day, not the number of day.s
            var daysToSubtract = daysToPriorDayOfWeek + fullWeekDays;

            var output = Instances.DateTimeOperator.Subtract_Days(lastOfMonth, daysToSubtract);
            return output;
        }

        public DateTime Get_NthDayOfWeek_OfMonth(int year, int month, int n, DayOfWeek dayOfWeek)
        {
            // What day is the first of the month?
            var firstOfMonth = this.Get_FirstOfMonth(year, month);

            var firstOfMonth_DayOfWeek = firstOfMonth.DayOfWeek;

            var daysToDayOfWeek = this.Get_DaysToDayOfWeek(
                firstOfMonth_DayOfWeek,
                dayOfWeek);

            // n - 1, since we already got to the first day of the week in the month.
            var daysToAdd = (n - 1) * IValues.DaysInWeek_Constant;

            // + 1, to get the actual day, not the number of day.s
            var dayOfMonth = daysToDayOfWeek + daysToAdd + 1;

            var output = this.From(year, month, dayOfMonth);
            return output;
        }

        /// <summary>
        /// Gets the number of days to the day of the week.
        /// (Which is zero, if the days of the week are the same.)
        /// </summary>
        public int Get_DaysToDayOfWeek(
            DayOfWeek dayOfWeek,
            DayOfWeek nextDayOfWeek)
            => Instances.DayOfWeekOperator.Get_DaysToNextDayOfWeek_Inclusive(
                dayOfWeek,
                nextDayOfWeek);

        /// <summary>
        /// Gets the number of days to the next day of the week.
        /// (Next means a full week, 7 days, if the days of the week are the same.)
        /// </summary>
        public int Get_DaysToDayOfWeek_Next(
            DayOfWeek dayOfWeek,
            DayOfWeek nextDayOfWeek)
            => Instances.DayOfWeekOperator.Get_DaysToNextDayOfWeek_Exclusive(
                dayOfWeek,
                nextDayOfWeek);

        public DateTime Get_FirstOfMonth(int year, int month)
            => this.From(year, month, 1);

        public DateTime Get_LastOfMonth(int year, int month)
        {
            var lastOfMonth_DayNumber = this.Get_LastOfMonth_DayNumber(year, month);

            var output = this.From(year, month, lastOfMonth_DayNumber);
            return output;
        }

        public int Get_LastOfMonth_DayNumber(int year, int month)
        {
            var lastOfMonth = IValues.LastDaysOfMonth_Instance[month];
            
            if(month == 2)
            {
                var is_LeapYear = this.Is_LeapYear(year);

                var output = is_LeapYear
                    ? lastOfMonth + 1
                    : lastOfMonth
                    ;

                return output;
            }

            return lastOfMonth;
        }

        public bool Is_LeapYear(int year)
        {
            var is_DivisibleBy4 = year % 4 == 0;
            if(is_DivisibleBy4)
            {
                var is_DivisibleBy100 = year % 100 == 0;
                if(is_DivisibleBy100)
                {
                    var is_DivisibleBy400 = year % 400 == 0;

                    var output = is_DivisibleBy400;
                    return output;
                }

                return false;
            }

            return false;
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
