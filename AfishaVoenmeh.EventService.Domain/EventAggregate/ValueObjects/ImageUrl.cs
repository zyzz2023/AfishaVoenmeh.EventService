using AfishaVoenmeh.EventService.Domain.Common.Abstract;
using AfishaVoenmeh.EventService.Domain.Common.Errors;
using ErrorOr;

namespace AfishaVoenmeh.EventService.Domain.EventAggregate.ValueObjects;

public class ImageUrl : ValueObject
{
    public string Value { get; private set; } = string.Empty;

    protected ImageUrl() { } // EF Core

    private ImageUrl(string value) => Value = value;

    public static ImageUrl Create(string url) => new(url);

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
