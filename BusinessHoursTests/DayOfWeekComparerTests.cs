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
            var days = new[]
                {
                    DayOfWeek.Friday, DayOfWeek.Saturday, 
                    DayOfWeek.Tuesday,DayOfWeek.Sunday, 
                    DayOfWeek.Monday
                }
                .OrderBy(x => x, DayOfWeekComparer.MondayFirst);
         
            Assert.Collection(days,
                day => Assert.Equal(DayOfWeek.Monday, day),
                day => Assert.Equal(DayOfWeek.Tuesday, day),
                day => Assert.Equal(DayOfWeek.Friday, day),
                day => Assert.Equal(DayOfWeek.Saturday, day),
                day => Assert.Equal(DayOfWeek.Sunday, day)
            );
        }
        
        [Fact]
        public void DayOfWeekDistanceTest()
        {
            Assert.Equal(-1, DayOfWeekComparer.MondayFirst.Compare(
                DayOfWeek.Monday, 
                DayOfWeek.Tuesday));    
            Assert.Equal(-2, DayOfWeekComparer.MondayFirst.Compare(
                DayOfWeek.Monday, 
                DayOfWeek.Wednesday));    
            Assert.Equal(6, DayOfWeekComparer.MondayFirst.Compare(
                DayOfWeek.Sunday, 
                DayOfWeek.Monday));    
        }
    }
}