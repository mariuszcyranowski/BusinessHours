using System;
using Xunit;

namespace BusinessHoursTests
{
    public class BusinessHoursTests
    {
        [Fact]
        public void Test1()
        {
            var bussinessHours = new BusinessHours
            {
                Days = new[]
                {
                    DayOfWeek.Thursday,
                    DayOfWeek.Monday,
                    DayOfWeek.Tuesday,
                    DayOfWeek.Thursday
                }
            };
            Assert.Collection(bussinessHours.DayPeriods,
                x => Assert.Equal(DayPeriodFactory.Make(
                    DayOfWeek.Monday, 
                    DayOfWeek.Tuesday), x),
                x => Assert.Equal(DayPeriodFactory.Make(
                    DayOfWeek.Thursday), x)
            );
        }

        [Fact]
        public void Test2()
        {
            var bussinessHours = new BusinessHours
            {
                Days = new[]
                {
                    DayOfWeek.Monday,
                    DayOfWeek.Wednesday,
                    DayOfWeek.Friday
                }
            };

            Assert.Collection(bussinessHours.DayPeriods,
                x => Assert.Equal(DayPeriodFactory.Make(
                    DayOfWeek.Monday), x),
                x => Assert.Equal(DayPeriodFactory.Make(
                    DayOfWeek.Wednesday), x),
                x => Assert.Equal(DayPeriodFactory.Make(
                    DayOfWeek.Friday), x)
            );
        }

        [Fact]
        public void Test3()
        {
            var bussinessHours = new BusinessHours
            {
                Days = new[]
                {
                    DayOfWeek.Tuesday,
                    DayOfWeek.Wednesday,
                    DayOfWeek.Thursday,
                    DayOfWeek.Sunday
                }
            };
            Assert.Collection(bussinessHours.DayPeriods,
                x => Assert.Equal(DayPeriodFactory.Make(
                    DayOfWeek.Tuesday, 
                    DayOfWeek.Thursday), x),
                x => Assert.Equal(DayPeriodFactory.Make(
                    DayOfWeek.Sunday), x)
            );
        }
        
        [Fact]
        public void Test4()
        {
            var bussinessHours = new BusinessHours
            {
                Days = new[]
                {
                    DayOfWeek.Monday,
                    DayOfWeek.Wednesday,
                    DayOfWeek.Thursday,
                    DayOfWeek.Saturday,
                    DayOfWeek.Sunday
                }
            };
            
            Assert.Collection(bussinessHours.DayPeriods,
                x => Assert.Equal(DayPeriodFactory.Make(
                    DayOfWeek.Monday), x),
                x => Assert.Equal(DayPeriodFactory.Make(
                    DayOfWeek.Wednesday, 
                    DayOfWeek.Thursday), x),
                x => Assert.Equal(DayPeriodFactory.Make(
                    DayOfWeek.Saturday,
                    DayOfWeek.Sunday), x)
            );
        }
    }
}