using AfishaVoenmeh.EventService.Domain.Common.Abstract;
using AfishaVoenmeh.EventService.Domain.Common.Errors;
using ErrorOr;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

    public static Location Create(string city, string street, int number) =>
        new (city, street, number);

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return City;
        yield return Street;
        yield return Number!;
    }
}
