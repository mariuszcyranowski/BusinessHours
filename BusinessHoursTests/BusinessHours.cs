using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessHoursTests
{
    class BusinessHours
    {
        private DayOfWeek[] _weekDays;
        public Tuple<DayOfWeek, DayOfWeek?>[] NormalizedWeekDays { get; private set; }

        public IEnumerable<DayOfWeek> WeekDays
        {
            get => _weekDays;
            set
            {
                _weekDays = value.OrderByDescending(x => x, DayOfWeekComparer.MondayFirst).Distinct().ToArray();
                Normalize();
            }
        }

        private void Normalize()
        {
            if (_weekDays.Length == 1)
            {
                NormalizedWeekDays = new[]
                {
                    new Tuple<DayOfWeek, DayOfWeek?>(_weekDays[0], null), 
                };
            }
            else if (_weekDays.Length == 2)
            {
                NormalizedWeekDays = new[]
                {
                    new Tuple<DayOfWeek, DayOfWeek?>(_weekDays[0], _weekDays[1]), 
                };
            }
            else
            {
                var result = new List<Tuple<DayOfWeek, DayOfWeek?>>();

                var stack = new Stack<DayOfWeek>(_weekDays);

                while (stack.TryPop(out var first))
                {
                    if (!stack.TryPeek(out var second))
                    {
                        result.Add(new Tuple<DayOfWeek, DayOfWeek?>(first, null));
                    }
                    else if (DayOfWeekComparer.MondayFirst.Compare(first, second) < -1)
                    {
                        result.Add(new Tuple<DayOfWeek, DayOfWeek?>(first, null));
                    }
                    else
                    {
                        second = stack.Pop();
                        while (stack.TryPeek(out var next) && 
                               DayOfWeekComparer.MondayFirst.Compare(second, next) == -1)
                        {
                            second = stack.Pop();
                        }
                        result.Add(new Tuple<DayOfWeek, DayOfWeek?>(first, second));
                    } 
                }
                NormalizedWeekDays = result.ToArray();
            }
        }
    }
}