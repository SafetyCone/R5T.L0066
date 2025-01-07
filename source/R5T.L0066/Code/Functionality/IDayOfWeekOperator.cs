using System;

using R5T.T0132;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface IDayOfWeekOperator : IFunctionalityMarker
    {
        DayOfWeek[] Get_DaysOfWeek()
        {
            var output = Instances.EnumerationOperator.Get_Values<DayOfWeek>();
            return output;
        }

        /// <summary>
        /// Gets the integer day of the week, starting at 0 for <see cref="DayOfWeek.Sunday"/> and going to 6 for <see cref="DayOfWeek.Saturday"/>.
        /// </summary>
        int Get_DayOfWeekNumber(DayOfWeek dayOfWeek)
        {
            var output = Instances.EnumerationOperator.Get_ValueOf_Integer32(dayOfWeek);
            return output;
        }

        /// <summary>
        /// <inheritdoc cref="Documentation.DayOfWeek_Inclusive" path="descendant::summary"/>
        /// </summary>
        int Get_DaysToNextDayOfWeek_Inclusive(
            DayOfWeek from,
            DayOfWeek to)
        {
            var output = from == to
                ? 0
                : this.Get_DaysToNextDayOfWeek_Exclusive(
                    from,
                    to)
                ;

            return output;
        }

        /// <summary>
        /// <inheritdoc cref="Documentation.DayOfWeek_Exclusive" path="descendant::summary"/>
        /// </summary>
        int Get_DaysToNextDayOfWeek_Exclusive(
            DayOfWeek from,
            DayOfWeek to)
        {
            var from_AsInteger = Convert.ToInt32(from);
            var to_AsInteger = Convert.ToInt32(to);

            var output = to_AsInteger > from_AsInteger
                ? to_AsInteger - from_AsInteger
                : (IValues.DaysInWeek_Constant - from_AsInteger) + to_AsInteger
                ;

            return output;
        }



        /// <summary>
        /// <inheritdoc cref="Documentation.DayOfWeek_Inclusive" path="descendant::summary"/>
        /// </summary>
        int Get_DaysToPriorDayOfWeek_Inclusive(
            DayOfWeek from,
            DayOfWeek to)
        {
            var output = from == to
                ? 0
                : this.Get_DaysToPriorDayOfWeek_Exclusive(
                    from,
                    to)
                ;

            return output;
        }

        /// <summary>
        /// <inheritdoc cref="Documentation.DayOfWeek_Exclusive" path="descendant::summary"/>
        /// </summary>
        int Get_DaysToPriorDayOfWeek_Exclusive(
            DayOfWeek from,
            DayOfWeek to)
        {
            var from_AsInteger = Convert.ToInt32(from);
            var to_AsInteger = Convert.ToInt32(to);

            var output = from_AsInteger > to_AsInteger
                ? from_AsInteger - to_AsInteger
                : (IValues.DaysInWeek_Constant - to_AsInteger) + from_AsInteger
                ;

            return output;
        }
    }
}
