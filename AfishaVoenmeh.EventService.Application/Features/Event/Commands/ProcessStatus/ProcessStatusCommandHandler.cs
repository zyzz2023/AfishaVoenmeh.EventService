using AfishaVoenmeh.EventService.Application.Common.Interfaces.Persistence;
using AfishaVoenmeh.EventService.Application.Common.Interfaces.Services;
using ErrorOr;
using MediatR;

namespace AfishaVoenmeh.EventService.Application.Features.Event.Commands.ProcessStatus;

public class ProcessStatusCommandHandler : IRequestHandler<ProcessStatusCommand, ErrorOr<bool>>
{
    private readonly IEventRepository _eventRepository;
    private readonly ICacheService _cacheService;

    public ProcessStatusCommandHandler(
        IEventRepository eventRepository,
        ICacheService cacheService)
    {
        _eventRepository = eventRepository;
        _cacheService = cacheService;
    }

    public async Task<ErrorOr<bool>> Handle(ProcessStatusCommand request, CancellationToken cancellationToken)
    {
        var events = await _eventRepository.GetEventsForStatusProcessingAsync(
            request.Now, true, cancellationToken);

        foreach(var ev in events)
        {
            ev.ProcessStatus(request.Now);
            await _cacheService.RemoveAsync(ev.Id.ToString(), cancellationToken);
        }

        await _eventRepository.SaveChangesAsync(cancellationToken);

        return true;
    }
}
