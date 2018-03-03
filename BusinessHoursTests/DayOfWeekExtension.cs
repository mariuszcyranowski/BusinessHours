using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessHoursTests
{
    public static class DayOfWeekExtension
    {
        public static bool IsFollowedBy(this DayOfWeek @this, DayOfWeek next)
        {
            return DayOfWeekComparer.MondayFirst
                       .Compare(@this, next) == -1;
        }

        public static string Format(this IEnumerable<Tuple<DayOfWeek, DayOfWeek?>> @this)
        {
            return string.Join(",", 
                @this.Select(x => 
                    x.Item2 != null ? $"{x.Item1}-{x.Item2}" : x.Item1.ToString()
                    ));
        }
    }
}