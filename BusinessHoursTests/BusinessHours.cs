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
                var queue = new Queue<DayOfWeek>(_days);

                while (queue.TryDequeue(out var fromDay))
                {
                    if (!queue.TryPeek(out var toDay))
                    {
                        yield return DayPeriodFactory.Make(fromDay);
                    }
                    else if (DayOfWeekComparer.MondayFirst.Compare(fromDay, toDay) < -1)
                    {
                        yield return DayPeriodFactory.Make(fromDay);
                    }
                    else
                    {
                        toDay = queue.Dequeue();
                        while (queue.TryPeek(out var nextDay) && 
                               DayOfWeekComparer.MondayFirst.Compare(toDay, nextDay) == -1)
                        {
                            toDay = queue.Dequeue();
                        }
                        yield return DayPeriodFactory.Make(fromDay, toDay);
                    } 
                }
            }
        }
    }
}