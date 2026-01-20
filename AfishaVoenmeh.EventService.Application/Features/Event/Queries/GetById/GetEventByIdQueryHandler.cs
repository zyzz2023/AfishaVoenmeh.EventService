using AfishaVoenmeh.EventService.Application.Common.Interfaces.Persistence;
using AfishaVoenmeh.EventService.Application.Common.Interfaces.Services;
using AfishaVoenmeh.EventService.Application.Features.Event.Common;
using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AfishaVoenmeh.EventService.Application.Features.Event.Queries.GetById;

public class GetEventByIdQueryHandler : IRequestHandler<GetEventByIdQuery, ErrorOr<EventDto>>
{
    private readonly IEventRepository _eventRepository;
    private readonly IMapper _mapper;
    private readonly ICacheService _cacheService;

    private readonly ILogger<GetEventByIdQueryHandler> _logger;

    public GetEventByIdQueryHandler(
        IEventRepository eventRepository,
        IMapper mapper,
        ICacheService cacheService,
        ILogger<GetEventByIdQueryHandler> logger)
    {
        _eventRepository = eventRepository;
        _mapper = mapper;
        _cacheService = cacheService;
        _logger = logger;
    }

    public async Task<ErrorOr<EventDto>> Handle(GetEventByIdQuery request, CancellationToken cancellationToken)
    {
        var cachedEventDto = await _cacheService.GetAsync(request.EventId.ToString(), cancellationToken);
        if (cachedEventDto != null)
        {
            _logger.LogInformation("Event (DTO) with ID {EventId} retrieved from cache.", request.EventId);
            return cachedEventDto;
        }

        var receivedEvent = await _eventRepository.GetByIdAsync(request.EventId, false, cancellationToken);
        if (receivedEvent is null)
            return Error.NotFound("Event_NotFound", "This event was not found.");

        var eventDto = _mapper.Map<EventDto>(receivedEvent);

        await _cacheService.SetAsync(receivedEvent.Id.ToString(), eventDto, cancellationToken);

        return eventDto;
    }
}