using System;
using System.Linq;
using Xunit;

namespace BusinessHoursTests
{
    public class DayOfWeekComparerTests
    {
        [Fact]
        private void DayOfWeekComparisionTest()
        {
            var dayOfWeeks = new[]
            {
                DayOfWeek.Friday, DayOfWeek.Saturday, DayOfWeek.Tuesday,
                DayOfWeek.Sunday, DayOfWeek.Monday
            }.OrderBy(x => x, DayOfWeekComparer.MondayFirst);
         
            Assert.Collection(dayOfWeeks,
                week => Assert.Equal(DayOfWeek.Monday, week),
                week => Assert.Equal(DayOfWeek.Tuesday, week),
                week => Assert.Equal(DayOfWeek.Friday, week),
                week => Assert.Equal(DayOfWeek.Saturday, week),
                week => Assert.Equal(DayOfWeek.Sunday, week)
            );
        }
        
        [Fact]
        public void DayOfWeekDistanceTest()
        {
            Assert.Equal(-1, DayOfWeekComparer.MondayFirst.Compare(DayOfWeek.Monday, DayOfWeek.Tuesday));    
            Assert.Equal(-2, DayOfWeekComparer.MondayFirst.Compare(DayOfWeek.Monday, DayOfWeek.Wednesday));    
            Assert.Equal(6, DayOfWeekComparer.MondayFirst.Compare(DayOfWeek.Sunday, DayOfWeek.Monday));    
        }
    }
}