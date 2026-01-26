using ErrorOr;
using MediatR;

namespace AfishaVoenmeh.EventService.Application.Features.Event.Commands.ProcessStatus;

public record ProcessStatusCommand(DateTime Now) : IRequest<ErrorOr<bool>>;