using AfishaVoenmeh.EventService.Application.Features.Event.Common;
using AfishaVoenmeh.EventService.Domain.EventAggregate.Enums;
using ErrorOr;
using MediatR;

namespace AfishaVoenmeh.EventService.Application.Features.Event.Commands.Create;

public record CreateEventCommand(
    string Title,
    string Description,
    DateTime StartsAt,
    DateTime EndsAt,
    int TotalSeats,
    string ImageUrl,
    string City,
    string Street,
    int Number,
    string Target
    ) : IRequest<ErrorOr<EventDto>>;