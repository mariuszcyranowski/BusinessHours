using System;

namespace BusinessHoursTests
{
    static class DayPeriodFactory
    {
        public static Tuple<DayOfWeek, DayOfWeek?> Make(
            DayOfWeek fromDay, DayOfWeek? toDay = null)
        {
            return new Tuple<DayOfWeek, DayOfWeek?>(fromDay, toDay);
        }

        
    }

}