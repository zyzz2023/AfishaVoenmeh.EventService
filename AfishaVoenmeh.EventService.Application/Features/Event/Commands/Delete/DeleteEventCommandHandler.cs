using AfishaVoenmeh.EventService.Application.Common.Interfaces.Persistence;
using AfishaVoenmeh.EventService.Application.Common.Interfaces.Services;
using ErrorOr;
using MediatR;

namespace AfishaVoenmeh.EventService.Application.Features.Event.Commands.Delete;

public class DeleteEventCommandHandler : IRequestHandler<DeleteEventCommand, ErrorOr<bool>>
{
    private readonly IEventRepository _eventRepository;

    private readonly ICacheService _cacheService;

    public DeleteEventCommandHandler(
        IEventRepository eventRepository, 
        ICacheService cacheService)
    {
        _eventRepository = eventRepository;
        _cacheService = cacheService;
    }

    public async Task<ErrorOr<bool>> Handle(DeleteEventCommand command, CancellationToken cancellationToken)
    {
        var existingEvent = await _eventRepository.GetByIdAsync(command.EventId, false, cancellationToken);
        if (existingEvent is null)
            return Error.NotFound(
                "Event.NotFound", $"Event with id '{command.EventId}' was not found.");

        await _eventRepository.DeleteAsync(existingEvent, cancellationToken);

        await _cacheService.RemoveAsync(command.EventId.ToString(), cancellationToken);

        return true;
    }
}
