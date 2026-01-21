using ErrorOr;
using MediatR;

namespace AfishaVoenmeh.EventService.Application.Features.Event.Commands.Delete;

public record DeleteEventCommand(Guid EventId) : IRequest<ErrorOr<bool>>;
