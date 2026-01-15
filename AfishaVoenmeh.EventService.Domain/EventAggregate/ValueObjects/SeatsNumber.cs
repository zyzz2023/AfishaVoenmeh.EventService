using AfishaVoenmeh.EventService.Domain.Common;
using ErrorOr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AfishaVoenmeh.EventService.Domain.EventAggregate.ValueObjects;

public class SeatsNumber : ValueObject
{
    public int Total { get; private set; }
    public int Current { get; private set; }

    protected SeatsNumber() { } // EF Core

    private SeatsNumber(int total, int current)
    { 
        Total = total;
        Current = current;
    }

    public ErrorOr<SeatsNumber> Create(int total, int current)
    {
        if (total <= 0 || current <= 0)
            return Error.Validation("Number_Of_Seats_Incorrect", "The number of seats cannot be less than or equal to zero");

        return new SeatsNumber(total, current);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Total;
        yield return Current;
    }
}
