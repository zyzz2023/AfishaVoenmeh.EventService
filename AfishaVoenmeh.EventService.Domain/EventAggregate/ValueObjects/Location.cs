using AfishaVoenmeh.EventService.Domain.Common.Abstract;
using AfishaVoenmeh.EventService.Domain.Common.Errors;
using ErrorOr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AfishaVoenmeh.EventService.Domain.EventAggregate.ValueObjects;

public class Location : ValueObject
{
    public string City { get; private set; } = string.Empty;
    public string Street { get; private set; } = string.Empty;
    public int? Number { get; private set; } = default;

    protected Location() { } // EF Core

    private Location(string city, string street, int number)
    {
        City = city;
        Street = street;
        Number = number;
    }

    public static ErrorOr<Location> Create(string city, string street, int number)
    {
        if (string.IsNullOrEmpty(city) || string.IsNullOrEmpty(street))
            return DomainErrors.EmptyAddress;

        if (number <= 0)
            return DomainErrors.IncorrectAddressNumber;

        return new Location(city, street, number);
    }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return City;
        yield return Street;
        yield return Number!;
    }
}
