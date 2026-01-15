using AfishaVoenmeh.EventService.Domain.Common;
using ErrorOr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AfishaVoenmeh.EventService.Domain.EventAggregate.ValueObjects;

public class ImageUrl : ValueObject
{
    public string Value { get; private set; } = string.Empty;

    protected ImageUrl() { } // EF Core

    private ImageUrl(string value) => Value = value;
    
    public ErrorOr<ImageUrl> Create(string url)
    {
        if (string.IsNullOrEmpty(url))
            return Error.Validation("Url_Null", "The url cannot be empty");

        if (!Uri.IsWellFormedUriString(url, UriKind.Absolute))
            return Error.Validation("Url_Incorrect", "Invalid url format");

        return new ImageUrl(url);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

}
