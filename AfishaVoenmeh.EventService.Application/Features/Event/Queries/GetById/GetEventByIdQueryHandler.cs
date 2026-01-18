using AfishaVoenmeh.EventService.Application.Common.Interfaces.Persistence;
using AfishaVoenmeh.EventService.Application.Features.Event.Common;
using ErrorOr;
using Mapster;
using MapsterMapper;
using MediatR;

namespace AfishaVoenmeh.EventService.Application.Features.Event.Queries.GetById;

public class GetEventByIdQueryHandler : IRequestHandler<GetEventByIdQuery, ErrorOr<EventDto>>
{
    private readonly IEventRepository _eventRepository;

    private readonly IMapper _mapper;

    public GetEventByIdQueryHandler(IEventRepository eventRepository, IMapper mapper)
    {
        _eventRepository = eventRepository;
        _mapper = mapper;
    }

    public async Task<ErrorOr<EventDto>> Handle(GetEventByIdQuery request, CancellationToken cancellationToken)
    {
        var receivedEvent = await _eventRepository.GetByIdAsync(request.EventId, false, cancellationToken);
        if (receivedEvent is null)
            return Error.NotFound("Event_NotFound", "This event was not found.");

        return _mapper.Map<EventDto>(receivedEvent);
    }
}