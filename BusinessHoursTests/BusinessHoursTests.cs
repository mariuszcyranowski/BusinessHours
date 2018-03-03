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
                
                period0 => Assert.Equal(DayPeriodFactory
                    .Make(DayOfWeek.Monday, DayOfWeek.Tuesday), 
                    period0),
                
                period1 => Assert.Equal(DayPeriodFactory
                    .Make(DayOfWeek.Thursday), 
                    period1)
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
                
                period0 => Assert.Equal(DayPeriodFactory
                    .Make(DayOfWeek.Monday), 
                    period0),
                
                period1 => Assert.Equal(DayPeriodFactory
                    .Make(DayOfWeek.Wednesday), 
                    period1),
                
                period2 => Assert.Equal(DayPeriodFactory
                    .Make(DayOfWeek.Friday), 
                    period2)
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
                
                period0 => Assert.Equal(DayPeriodFactory
                    .Make(DayOfWeek.Tuesday, DayOfWeek.Thursday), 
                    period0),
                
                period1 => Assert.Equal(DayPeriodFactory
                    .Make(DayOfWeek.Sunday), 
                    period1)
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
                
                period0 => Assert.Equal(DayPeriodFactory
                    .Make(DayOfWeek.Monday), 
                    period0),
                
                period1 => Assert.Equal(DayPeriodFactory
                    .Make(DayOfWeek.Wednesday, DayOfWeek.Thursday), 
                    period1),
                
                period2 => Assert.Equal(DayPeriodFactory
                    .Make(DayOfWeek.Saturday, DayOfWeek.Sunday), 
                    period2)
            );
        }
        
        [Fact]
        public void Test5()
        {
            var bussinessHours = new BusinessHours
            {
                Days = new[]
                {
                    DayOfWeek.Monday,
                    DayOfWeek.Tuesday,
                    DayOfWeek.Wednesday,
                    DayOfWeek.Thursday,
                    DayOfWeek.Friday,
                    DayOfWeek.Saturday,
                    DayOfWeek.Sunday
                }
            };
            
            Assert.Collection(bussinessHours.DayPeriods,
                
                period0 => Assert.Equal(DayPeriodFactory
                        .Make(DayOfWeek.Monday, DayOfWeek.Sunday), 
                    period0)
            );
        }
        
        [Fact]
        public void Test6()
        {
            var bussinessHours = new BusinessHours
            {
                Days = new[]
                {
                    DayOfWeek.Monday,
                }
            };
            
            Assert.Collection(bussinessHours.DayPeriods,
                
                period0 => Assert.Equal(DayPeriodFactory
                        .Make(DayOfWeek.Monday), 
                    period0)
            );
        }
        
        [Fact]
        public void Test7()
        {
            var bussinessHours = new BusinessHours
            {
                Days = new[]
                {
                    DayOfWeek.Wednesday,
                    DayOfWeek.Thursday
                }
            };
            
            Assert.Collection(bussinessHours.DayPeriods,
                
                period0 => Assert.Equal(DayPeriodFactory
                        .Make(DayOfWeek.Wednesday, DayOfWeek.Thursday), 
                    period0)
            );
        }
    }
}