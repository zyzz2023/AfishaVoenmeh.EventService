using AfishaVoenmeh.EventService.Domain.Common;
using ErrorOr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AfishaVoenmeh.EventService.Domain.EventAggregate.ValueObjects;

public class Location : ValueObject
{
    public string City { get; private set; }
    public string Street { get; private set; }
    public int? Number { get; private set; }

    protected Location() { } // EF Core

    private Location(string city, string street, int number)
    {
        City = city;
        Street = street;
        Number = number;
    }

    public ErrorOr<Location> Create(string city, string street, int number)
    {
        if(string.IsNullOrEmpty(city))
            return Error.Validation("City_Null", "The city cannot be empty");

        if (string.IsNullOrEmpty(street))
            return Error.Validation("Street_Null", "The street cannot be empty");

        if (number <= 0)
            return Error.Validation("Number_Incorrect", "The number must be greater than zero");

        return new Location(city, street, number);
    }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return City;
        yield return Street;
        yield return Number;
    }
}
