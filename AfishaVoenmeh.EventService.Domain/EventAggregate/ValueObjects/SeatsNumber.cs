using AfishaVoenmeh.EventService.Domain.Common.Abstract;
using AfishaVoenmeh.EventService.Domain.Common.Errors;
using ErrorOr;

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

    public static ErrorOr<SeatsNumber> Create(int total, int current)
    {
        if (total <= 0 || current <= 0)
            return DomainErrors.IncorrectSeatsNumber;

        if (total > 200)
            return DomainErrors.OverLimitSeatsNumber;

        if (current > total)
            return DomainErrors.CurrentSeatsIncorrect;

        return new SeatsNumber(total, current);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Total;
        yield return Current;
    }
}
