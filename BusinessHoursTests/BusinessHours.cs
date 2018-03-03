using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessHoursTests
{
    class BusinessHours
    {
        private Queue<DayOfWeek> _weekDays;
        public Tuple<DayOfWeek, DayOfWeek?>[] NormalizedWeekDays { get; private set; }

        public IEnumerable<DayOfWeek> WeekDays
        {
            get => _weekDays;
            set
            {
                _weekDays = new Queue<DayOfWeek>(value.OrderBy(x => x, DayOfWeekComparer.MondayFirst).Distinct());
                NormalizedWeekDays = Normalize().ToArray();
            }
        }

        private IEnumerable<Tuple<DayOfWeek, DayOfWeek?>> Normalize()
        {
            if (_weekDays.Count == 1)
            {
                yield return Make(_weekDays.Dequeue());
            }
            else if (_weekDays.Count == 2)
            {
                yield return Make(_weekDays.Dequeue(), _weekDays.Dequeue());
            }
            else
            {
                var queue = new Queue<DayOfWeek>(_weekDays);

                while (queue.TryDequeue(out var first))
                {
                    if (!queue.TryPeek(out var second))
                    {
                        yield return Make(first);
                    }
                    else if (DayOfWeekComparer.MondayFirst.Compare(first, second) < -1)
                    {
                        yield return Make(first);
                    }
                    else
                    {
                        second = queue.Dequeue();
                        while (queue.TryPeek(out var next) && 
                               DayOfWeekComparer.MondayFirst.Compare(second, next) == -1)
                        {
                            second = queue.Dequeue();
                        }
                        yield return Make(first, second);
                    } 
                }
            }
        }

        private Tuple<DayOfWeek, DayOfWeek?> Make(DayOfWeek first, DayOfWeek? second = null)
        {
            return new Tuple<DayOfWeek, DayOfWeek?>(first, second);
        }
    }
}