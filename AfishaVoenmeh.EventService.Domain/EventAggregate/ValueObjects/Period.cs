using AfishaVoenmeh.EventService.Domain.Common;
using ErrorOr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AfishaVoenmeh.EventService.Domain.EventAggregate.ValueObjects
{
    public class Period : ValueObject
    {
        public DateTime StartTime { get; private set; }
        public DateTime EndTime { get; private set; }

        protected Period() { } // EF Core

        private Period(DateTime startTime, DateTime endTime)
        {
            StartTime = startTime;
            EndTime = endTime;
        }

        public ErrorOr<Period> Create(DateTime startTime, DateTime endTime)
        {
            if (startTime > endTime || startTime == endTime)
                return Error.Validation("Period_Invalid", "The end date must be less than the start date");

            return new Period(startTime, endTime);
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return StartTime;
            yield return EndTime;
        }
    }
}
