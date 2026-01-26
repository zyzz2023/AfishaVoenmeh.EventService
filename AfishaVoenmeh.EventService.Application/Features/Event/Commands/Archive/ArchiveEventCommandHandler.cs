using AfishaVoenmeh.EventService.Application.Common.Interfaces.Persistence;
using AfishaVoenmeh.EventService.Application.Common.Interfaces.Services;
using ErrorOr;
using MediatR;

namespace AfishaVoenmeh.EventService.Application.Features.Event.Commands.Archive;

public class ArchiveEventCommandHandler : IRequestHandler<ArchiveEventCommand, ErrorOr<bool>>
{
    private readonly IEventRepository _eventRepository;
    private readonly ICacheService _cacheService;

    public ArchiveEventCommandHandler(IEventRepository eventRepository, ICacheService cacheService)
    {
        _eventRepository = eventRepository;
        _cacheService = cacheService;
    }

    public async Task<ErrorOr<bool>> Handle(ArchiveEventCommand command, CancellationToken cancellationToken)
    {
        var existsingEvent = await _eventRepository.GetByIdAsync(command.EventId, true, cancellationToken);
        if (existsingEvent == null)
            return Error.NotFound(
                "Event_Not_Found", $"Event with id '{command.EventId}' was not found.");

        existsingEvent.ArchiveEvent();

        await _eventRepository.SaveChangesAsync();

        await _cacheService.RemoveAsync(command.EventId.ToString(), cancellationToken);

        return true;
    }
}
