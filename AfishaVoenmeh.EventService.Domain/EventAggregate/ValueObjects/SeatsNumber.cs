using AfishaVoenmeh.EventService.Domain.Common.Abstract;
using AfishaVoenmeh.EventService.Domain.Common.Errors;
using ErrorOr;

namespace AfishaVoenmeh.EventService.Domain.EventAggregate.ValueObjects;

public class SeatsNumber : ValueObject
{
    public int Total { get; private set; }
    public int Current { get; private set; }

    protected SeatsNumber() { } // EF Core

    private SeatsNumber(int total)
    { 
        Total = total;
        Current = total;
    }

    public static SeatsNumber Create(int total) => new(total);

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Total;
        yield return Current;
    }

    public ErrorOr<bool> ReduceQuantityCurrentSeats(int quantity)
    {
        if (quantity <= 0)
            return DomainErrors.IncorrectSeatsNumber;

        if(quantity > Total)
            return DomainErrors.CurrentSeatsIncorrect;

        Current -= quantity;

        return true;
    }
}
