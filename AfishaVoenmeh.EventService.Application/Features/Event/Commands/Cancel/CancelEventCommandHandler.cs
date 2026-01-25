using AfishaVoenmeh.EventService.Application.Common.Interfaces.Persistence;
using AfishaVoenmeh.EventService.Application.Common.Interfaces.Services;
using ErrorOr;
using MediatR;

namespace AfishaVoenmeh.EventService.Application.Features.Event.Commands.Cancel;

public class CancelEventCommandHandler : IRequestHandler<CancelEventCommand, ErrorOr<bool>>
{
    private readonly IEventRepository _eventRepository;
    private readonly ICacheService _cacheService;

    public CancelEventCommandHandler(IEventRepository eventRepository, ICacheService cacheService)
    {
        _eventRepository = eventRepository;
        _cacheService = cacheService;
    }

    public async Task<ErrorOr<bool>> Handle(CancelEventCommand command, CancellationToken cancellationToken)
    {
        var existsingEvent = await _eventRepository.GetByIdAsync(command.EventId, true, cancellationToken);
        if (existsingEvent == null)
            return Error.NotFound(
                "Event_Not_Found", $"Event with id '{command.EventId}' was not found.");

        existsingEvent.ChangeStatus(Domain.EventAggregate.Enums.Status.Cancelled);

        await _eventRepository.UpdateAsync(existsingEvent);

        await _cacheService.RemoveAsync(command.EventId.ToString(), cancellationToken);

        return true;
    }
}
