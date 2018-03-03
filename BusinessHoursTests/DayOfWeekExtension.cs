using System;

namespace BusinessHoursTests
{
    public static class DayOfWeekExtension
    {
        public static bool IsFollowedBy(this DayOfWeek @this, DayOfWeek next)
        {
            return DayOfWeekComparer.MondayFirst
                       .Compare(@this, next) == -1;
        }
    }
}