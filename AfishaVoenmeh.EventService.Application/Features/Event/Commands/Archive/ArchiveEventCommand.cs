using ErrorOr;
using MediatR;

namespace AfishaVoenmeh.EventService.Application.Features.Event.Commands.Archive;

public record ArchiveEventCommand(Guid EventId) : IRequest<ErrorOr<bool>>;