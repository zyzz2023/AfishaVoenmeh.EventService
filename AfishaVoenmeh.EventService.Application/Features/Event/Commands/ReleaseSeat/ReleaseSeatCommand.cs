using ErrorOr;
using MediatR;

namespace AfishaVoenmeh.EventService.Application.Features.Event.Commands.ReleaseSeat;

public record ReleaseSeatCommand(Guid EventId) : IRequest<ErrorOr<bool>>;