using System;
using Xunit;

namespace BusinessHoursTests
{
    public class BusinessHoursTests
    {
        [Fact]
        public void Test1()
        {
            var bussinessHours = new BusinessHours();
            bussinessHours.WeekDays = new[] {DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Thursday};
            
            Assert.Equal(new []
                {
                    new Tuple<DayOfWeek, DayOfWeek?>(DayOfWeek.Monday, DayOfWeek.Tuesday),
                    new Tuple<DayOfWeek, DayOfWeek?>(DayOfWeek.Thursday, null),
                },
                bussinessHours.NormalizedWeekDays);
        }
        
        [Fact]
        public void Test2()
        {
            var bussinessHours = new BusinessHours();
            bussinessHours.WeekDays = new[] {DayOfWeek.Monday, DayOfWeek.Wednesday, DayOfWeek.Friday};
            
            Assert.Equal(new []
                {
                    new Tuple<DayOfWeek, DayOfWeek?>(DayOfWeek.Monday, null),
                    new Tuple<DayOfWeek, DayOfWeek?>(DayOfWeek.Wednesday, null),
                    new Tuple<DayOfWeek, DayOfWeek?>(DayOfWeek.Friday, null),
                },
                bussinessHours.NormalizedWeekDays);
        }

        [Fact]
        public void Test3()
        {
            var bussinessHours = new BusinessHours();
            bussinessHours.WeekDays = new[] {DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Sunday};
            
            Assert.Equal(new []
                {
                    new Tuple<DayOfWeek, DayOfWeek?>(DayOfWeek.Tuesday, DayOfWeek.Thursday),
                    new Tuple<DayOfWeek, DayOfWeek?>(DayOfWeek.Sunday, null),
                },
                bussinessHours.NormalizedWeekDays);
        }
        
        [Fact]
        public void Test4()
        {
            var bussinessHours = new BusinessHours();
            bussinessHours.WeekDays = new[] {DayOfWeek.Monday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Saturday, DayOfWeek.Sunday};
            
            Assert.Equal(new []
                {
                    new Tuple<DayOfWeek, DayOfWeek?>(DayOfWeek.Monday, null),
                    new Tuple<DayOfWeek, DayOfWeek?>(DayOfWeek.Wednesday, DayOfWeek.Thursday),
                    new Tuple<DayOfWeek, DayOfWeek?>(DayOfWeek.Saturday, DayOfWeek.Sunday),
                },
                bussinessHours.NormalizedWeekDays);
        }
    }
}