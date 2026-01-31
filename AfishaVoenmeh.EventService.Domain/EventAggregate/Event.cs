using AfishaVoenmeh.EventService.Domain.Common.Abstract;
using AfishaVoenmeh.EventService.Domain.EventAggregate.DomainEvents;
using AfishaVoenmeh.EventService.Domain.EventAggregate.Enums;
using AfishaVoenmeh.EventService.Domain.EventAggregate.ValueObjects;

namespace AfishaVoenmeh.EventService.Domain.EventAggregate;

public class Event : AggregateRoot<Guid>
{
    public string Title { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;

    public Period Period { get; private set; }
    public DeadlineRegister DeadlineRegister { get; private set; }
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
        DeadlineRegister deadlineRegister,
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
        DeadlineRegister = deadlineRegister;
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
        DeadlineRegister deadlineRegister,
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
            deadlineRegister,
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

    public void ChangeDeadlineRegister(DeadlineRegister deadlineRegister) => DeadlineRegister = deadlineRegister;

    public void ChangeSeatsNumber(SeatsNumber seatsNumber) => SeatsNumber = seatsNumber;

    public void ChangeImageUrl(ImageUrl imageUrl) => ImageUrl = imageUrl;

    public void ChangeLocation(Location location) => Location = location;

    public void ChangeTarget(Target target) => Target = target;

    public void ProcessStatus(DateTime now)
    {
        if(Status == Status.Created && Period.StartsAt <= now)
        {
            StartEvent();
        }
        else if(Status == Status.Started && Period.EndsAt <= now)
        {
            FinishEvent();
        }
    }

    private void StartEvent()
    {
        if(Status == Status.Created)
        {
            ChangeStatus(Status.Started);

            RaiseDomainEvent(new EventStartedDomainEvent(Guid.NewGuid(), Id));
        }

        // add domain error
    }

    private void FinishEvent()
    {
        if(Status == Status.Started)
        {
            ChangeStatus(Status.Finished);

            RaiseDomainEvent(new EventFinishedDomainEvent(Guid.NewGuid(), Id));
        }

        // add domain error
    }

    public void CancelEvent()
    {
        if(Status == Status.Created || Status == Status.Started)
        {
            ChangeStatus(Status.Cancelled);

            RaiseDomainEvent(new EventCancelledDomainEvent(Guid.NewGuid(), Id));
        }

        // add domain error
    }

    public void ArchiveEvent()
    {
        if(Status == Status.Finished || Status == Status.Cancelled)
        {
            ChangeStatus(Status.Archived);

            RaiseDomainEvent(new EventArchivedDomainEvent(Guid.NewGuid(), Id));
        }

        // add domain error
    }

    private void ChangeStatus(Status status) => Status = status;
}
