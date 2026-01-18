using AfishaVoenmeh.EventService.Domain.EventAggregate.Enums;
using System.Text.Json.Serialization;

namespace AfishaVoenmeh.EventService.Application.Features.Event.Common;

public class EventDto
{
    public Guid Id { get; init; }
    public string Title { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
    public DateTime StartsAt { get; init; }
    public DateTime EndsAt { get; init; }
    public int TotalSeats { get; init; }
    public int CurrentSeats { get; init; }
    public string ImageUrl { get; init; } = string.Empty;
    public LocationDto Location { get; init; }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public Status Status { get; init; }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public Target Target { get; init; }
}