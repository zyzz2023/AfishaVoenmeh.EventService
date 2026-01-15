using AfishaVoenmeh.EventService.Domain.Common;
using AfishaVoenmeh.EventService.Domain.EventAggregate.Enums;
using AfishaVoenmeh.EventService.Domain.EventAggregate.ValueObjects;
using ErrorOr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AfishaVoenmeh.EventService.Domain.EventAggregate;

public class Event : AggregateRoot<Guid>
{
    public Guid Id { get; private set; }
    public string Title { get; private set; }
    public string Description { get; private set; }

    public Period Period { get; private set; }
    public SeatsNumber SeatsNumber { get; private set; }
    public ImageUrl ImageUrl { get; private set; }
    public Location Location {  get; private set; }
    public Status Status { get; private set; }
    public Target Target { get; private set; }

    public DateTime CreatedAt { get; private set; }

    protected Event() { } // EF Core

    private Event(
        string title,
        string description,
        Period period,
        SeatsNumber seatsNumber,
        ImageUrl imageUrl,
        Location location,
        Status status,
        Target target)
    {
        Id = Guid.NewGuid();
        Title = title;
        Description = description;

        Period = period;
        SeatsNumber = seatsNumber;
        ImageUrl = imageUrl;
        Location = location;
        Status = status;
        Target = target;

        CreatedAt = DateTime.UtcNow;
    }

    public static ErrorOr<Event> Create(
        string title,
        string description,
        Period period,
        SeatsNumber seatsNumber,
        ImageUrl imageUrl,
        Location location,
        Status status,
        Target target
        )
    {
        if (string.IsNullOrEmpty(title))
            return Error.Validation("Title_Null", "Title cannot be empty");

        if(string.IsNullOrEmpty(description))
            return Error.Validation("Description_Null", "Description cannot be empty");

        return new Event(
            title, 
            description, 
            period, 
            seatsNumber, 
            imageUrl, 
            location, 
            status, 
            target
            );
    }

    public void ChangeStatus(Status status) => Status = status;
    
    public void ChangeTarget(Target target) => Target = target;
}
