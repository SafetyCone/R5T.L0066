using System;

using R5T.T0243;
using R5T.V0002;


namespace R5T.L0066.V000
{
    /// <summary>
    /// Day of week operator test article for the functionality method instances in <see cref="IDayOfWeekOperator"/>.
    /// </summary>
    [TestArticleImplementationMarker]
    public class DayOfWeekOperatorTestArticle : ITestArticleImplementationMarker,
        IDayOfWeekOperatorTestArticle
    {
        public int Get_DayOfWeekNumber(DayOfWeek dayOfWeek)
            => Instances.DayOfWeekOperator.Get_DayOfWeekNumber(dayOfWeek);

        public int Get_DaysToNextDayOfWeek_Exclusive(DayOfWeek from, DayOfWeek to)
            => Instances.DayOfWeekOperator.Get_DaysToNextDayOfWeek_Exclusive(from, to);

        public int Get_DaysToNextDayOfWeek_Inclusive(DayOfWeek from, DayOfWeek to)
            => Instances.DayOfWeekOperator.Get_DaysToNextDayOfWeek_Inclusive(from, to);

        public int Get_DaysToPriorDayOfWeek_Exclusive(DayOfWeek from, DayOfWeek to)
            => Instances.DayOfWeekOperator.Get_DaysToPriorDayOfWeek_Exclusive(from, to);

        public int Get_DaysToPriorDayOfWeek_Inclusive(DayOfWeek from, DayOfWeek to)
            => Instances.DayOfWeekOperator.Get_DaysToPriorDayOfWeek_Inclusive(from, to);
    }
}
