using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessHoursTests
{
    class BusinessHours
    {
        private Queue<DayOfWeek> _days;
        public Tuple<DayOfWeek, DayOfWeek?>[] DayPeriods 
        { get; private set; }

        public IEnumerable<DayOfWeek> Days
        {
            get => _days;
            set
            {
                _days = new Queue<DayOfWeek>(value
                    .OrderBy(x => x, DayOfWeekComparer.MondayFirst)
                    .Distinct()
                );
                DayPeriods = Normalize().ToArray();
            }
        }

        private IEnumerable<Tuple<DayOfWeek, DayOfWeek?>> Normalize()
        {
            if (_days.Count == 1)
            {
                yield return DayPeriodFactory.Make(_days.Dequeue());
            }
            else if (_days.Count == 2)
            {
                yield return DayPeriodFactory.Make(_days.Dequeue(), _days.Dequeue());
            }
            else
            {
                while (_days.TryDequeue(out var fromDay))
                {
                    if (!_days.TryPeek(out var toDay))
                    {
                        yield return DayPeriodFactory.Make(fromDay);
                    }
                    else if (DayOfWeekComparer.MondayFirst.Compare(fromDay, toDay) < -1)
                    {
                        yield return DayPeriodFactory.Make(fromDay);
                    }
                    else
                    {
                        toDay = _days.Dequeue();
                        while (_days.TryPeek(out var nextDay) && 
                               DayOfWeekComparer.MondayFirst.Compare(toDay, nextDay) == -1)
                        {
                            toDay = _days.Dequeue();
                        }
                        yield return DayPeriodFactory.Make(fromDay, toDay);
                    } 
                }
            }
        }
    }
}