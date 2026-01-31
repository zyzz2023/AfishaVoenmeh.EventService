using AfishaVoenmeh.EventService.Domain.Common.Abstract;

namespace AfishaVoenmeh.EventService.Domain.EventAggregate.ValueObjects;

public class DeadlineRegister : ValueObject
{
    public DateTime Value { get; set; }

    private DeadlineRegister(DateTime value) => Value = value;
    
    public static DeadlineRegister Create(DateTime value)
    {
        return new DeadlineRegister(value);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
