using AfishaVoenmeh.EventService.Application.Common.Interfaces.Persistence;
using AfishaVoenmeh.EventService.Application.Common.Interfaces.Services;
using AfishaVoenmeh.EventService.Application.Features.Event.Common;
using AfishaVoenmeh.EventService.Domain.EventAggregate;
using AfishaVoenmeh.EventService.Domain.EventAggregate.Enums;
using AfishaVoenmeh.EventService.Domain.EventAggregate.ValueObjects;
using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AfishaVoenmeh.EventService.Application.Features.Event.Commands.Update;

public class UpdateEventCommandHandler : IRequestHandler<UpdateEventCommand, ErrorOr<EventDto>>
{
    private readonly IEventRepository _eventRepository;
    private readonly IMapper _mapper;
    private readonly ICacheService _cacheService;

    private readonly ILogger<UpdateEventCommandHandler> _logger;

    public UpdateEventCommandHandler(
        IEventRepository eventRepository, 
        IMapper mapper, 
        ICacheService cacheService,
        ILogger<UpdateEventCommandHandler> logger)
    {
        _eventRepository = eventRepository;
        _mapper = mapper;
        _cacheService = cacheService;

        _logger = logger;
    }
    public async Task<ErrorOr<EventDto>> Handle(UpdateEventCommand request, CancellationToken cancellationToken)
    {
        var exitstsingEvent = await _eventRepository.GetByIdAsync(request.EventId, true, cancellationToken);
        if (exitstsingEvent == null)
            return Error.NotFound("EVENT_NOT_FOUND", "Event with ID {EventId} not found.");

        var period = Period.Create(request.StartsAt, request.EndsAt);
        if (period.IsError)
            return period.FirstError;

        var seatsNumber = SeatsNumber.Create(request.TotalSeats);
        var imageUrl = ImageUrl.Create(request.ImageUrl);
        var location = Location.Create(request.City, request.Street, request.Number);

        var target = Enum.Parse<Target>(request.Target, true);

        exitstsingEvent.Update(
            request.Title,
            request.Description,
            period.Value, // Добавить ErrorOr в остальные VO
            seatsNumber,
            imageUrl,
            location,
            target);

        _eventRepository.Update(exitstsingEvent);

        var cachedEventDto = await _cacheService.GetAsync(request.EventId.ToString(), cancellationToken);
        if(cachedEventDto != null)
        {
            var updatedDto = _mapper.Map<EventDto>(request);
            await _cacheService.SetAsync(request.EventId.ToString(), updatedDto, cancellationToken);

            _logger.LogInformation("Event (DTO) with ID {EventId} has been updated in the cache.", request.EventId);
        }

        return _mapper.Map<EventDto>(exitstsingEvent);
    }
}
