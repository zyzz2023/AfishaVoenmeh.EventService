using AfishaVoenmeh.EventService.Domain.Common.Abstract;
using AfishaVoenmeh.EventService.Domain.EventAggregate.Enums;
using AfishaVoenmeh.EventService.Domain.EventAggregate.ValueObjects;

namespace AfishaVoenmeh.EventService.Domain.EventAggregate;

public class Event : AggregateRoot<Guid>
{
    public string Title { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;

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

    public static Event Create(
        string title,
        string description,
        Period period,
        SeatsNumber seatsNumber,
        ImageUrl imageUrl,
        Location location,
        Target target
        )
    {
        Status status = Status.Created;

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

    public void ChangeTitle(string title) => Title = title;

    public void ChangeDescription(string description) => Description = description;

    public void ChangePeriod(Period period) => Period = period;

    public void ChangeSeatsNumber(SeatsNumber seatsNumber) => SeatsNumber = seatsNumber;

    public void ChangeImageUrl(ImageUrl imageUrl) => ImageUrl = imageUrl;

    public void ChangeLocation(Location location) => Location = location;

    public void ChangeStatus(Status status) => Status = status;
    
    public void ChangeTarget(Target target) => Target = target;
}
