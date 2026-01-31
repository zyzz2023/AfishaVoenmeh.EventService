namespace AfishaVoenmeh.EventService.Contracts.Responses;

public class EventResponse
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
    public LocationResponse Location { get; init; }
    public string Status { get; init; } = string.Empty;
    public string Target { get; init; } = string.Empty;
}
