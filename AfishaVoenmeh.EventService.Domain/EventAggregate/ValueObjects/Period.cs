using AfishaVoenmeh.EventService.Domain.Common.Abstract;
using AfishaVoenmeh.EventService.Domain.Common.Errors;
using ErrorOr;

namespace AfishaVoenmeh.EventService.Domain.EventAggregate.ValueObjects;

public class Period : ValueObject
{
    public DateTime StartsAt { get; private set; } // Начало мероприятия
    public DateTime EndsAt { get; private set; } // Конец мероприятия

    protected Period() { } // EF Core

    private Period(DateTime startsAt, DateTime endsAt)
    {
        StartsAt = startsAt;
        EndsAt = endsAt;
    }

    public static ErrorOr<Period> Create(DateTime startsAt, DateTime endsAt)
    {
        if ((endsAt - startsAt).TotalHours > 8)
            return DomainErrors.LongPeriod;

        return new Period(startsAt, endsAt);
    }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return StartsAt;
        yield return EndsAt;
    }
}
