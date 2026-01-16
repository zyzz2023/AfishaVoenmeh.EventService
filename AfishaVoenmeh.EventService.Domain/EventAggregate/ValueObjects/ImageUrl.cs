using AfishaVoenmeh.EventService.Domain.Common.Abstract;
using AfishaVoenmeh.EventService.Domain.Common.Errors;
using ErrorOr;

namespace AfishaVoenmeh.EventService.Domain.EventAggregate.ValueObjects;

public class ImageUrl : ValueObject
{
    public string Value { get; private set; } = string.Empty;

    protected ImageUrl() { } // EF Core

    private ImageUrl(string value) => Value = value;
    
    public static ErrorOr<ImageUrl> Create(string url)
    {
        if (string.IsNullOrEmpty(url))
            return DomainErrors.EmptyUrl;

        if (!Uri.IsWellFormedUriString(url, UriKind.Absolute))
            return DomainErrors.BadUrl;

        return new ImageUrl(url);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
