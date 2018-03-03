using System;
using System.Collections.Generic;

namespace BusinessHoursTests
{
    class DayOfWeekComparer : IComparer<DayOfWeek>
    {
        static DayOfWeekComparer()
        {
            MondayFirst = new DayOfWeekComparer();
        }
        
        private readonly Dictionary<DayOfWeek, int> ordering = 
            new Dictionary<DayOfWeek, int>()
        {
            { DayOfWeek.Monday, 1},
            { DayOfWeek.Tuesday, 2},
            { DayOfWeek.Wednesday, 3},
            { DayOfWeek.Thursday, 4},
            { DayOfWeek.Friday, 5},
            { DayOfWeek.Saturday, 6},
            { DayOfWeek.Sunday, 7}
        };

        public static DayOfWeekComparer MondayFirst { get; }

        public int Compare(DayOfWeek x, DayOfWeek y)
        {
            //return ordering[x].CompareTo(ordering[y]);
            return ordering[x] - ordering[y];
        }
        
         
    }
}