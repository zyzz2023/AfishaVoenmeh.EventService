using AfishaVoenmeh.EventService.Application.Features.Event.Common;
using ErrorOr;
using MediatR;

namespace AfishaVoenmeh.EventService.Application.Features.Event.Queries.GetById;

public record GetEventByIdQuery(Guid EventId) : IRequest<ErrorOr<EventDto>>;