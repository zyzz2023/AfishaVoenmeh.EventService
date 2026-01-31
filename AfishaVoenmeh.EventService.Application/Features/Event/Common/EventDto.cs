using AfishaVoenmeh.EventService.Domain.EventAggregate.Enums;

namespace AfishaVoenmeh.EventService.Application.Features.Event.Common;

public class EventDto
{
    public Guid Id { get; init; }
    public DateTime CreatedAt { get; init; }

    public string Title { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
    public DateTime StartsAt { get; init; }
    public DateTime EndsAt { get; init; }
    public DateTime DeadlineRegister { get; init; }
    public int TotalSeats { get; init; }
    public int CurrentSeats { get; init; }
    public string ImageUrl { get; init; } = string.Empty;
    public LocationDto Location { get; init; }
    public Status Status { get; init; }
    public Target Target { get; init; }
}