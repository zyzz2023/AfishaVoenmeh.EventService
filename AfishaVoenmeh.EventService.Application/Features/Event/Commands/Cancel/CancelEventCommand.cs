using ErrorOr;
using MediatR;

namespace AfishaVoenmeh.EventService.Application.Features.Event.Commands.Cancel;

public record CancelEventCommand(Guid EventId) : IRequest<ErrorOr<bool>>;
