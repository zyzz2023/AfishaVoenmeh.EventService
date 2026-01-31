using AfishaVoenmeh.EventService.Application.Common.Interfaces.Persistence;
using AfishaVoenmeh.EventService.Application.Common.Interfaces.Services;
using AfishaVoenmeh.EventService.Application.Features.Event.Common;
using AfishaVoenmeh.EventService.Domain.EventAggregate.Enums;
using AfishaVoenmeh.EventService.Domain.EventAggregate.ValueObjects;
using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AfishaVoenmeh.EventService.Application.Features.Event.Commands.Update;

public class UpdateEventCommandHandler : IRequestHandler<UpdateEventCommand, ErrorOr<EventDto>>
{
    private readonly IEventRepository _eventRepository;
    private readonly IMapper _mapper;
    private readonly ICacheService _cacheService;

    public UpdateEventCommandHandler(
        IEventRepository eventRepository, 
        IMapper mapper, 
        ICacheService cacheService)
    {
        _eventRepository = eventRepository;
        _mapper = mapper;
        _cacheService = cacheService;
    }
    public async Task<ErrorOr<EventDto>> Handle(UpdateEventCommand request, CancellationToken cancellationToken)
    {
        var exitstsingEvent = await _eventRepository.GetByIdAsync(request.EventId, true, cancellationToken);
        if (exitstsingEvent == null)
            return Error.NotFound("EVENT_NOT_FOUND", "Event with ID {EventId} not found.");

        var period = Period.Create(request.StartsAt, request.EndsAt);
        if (period.IsError)
            return period.FirstError;

        var deadlineRegister = DeadlineRegister.Create(request.DeadlineRegister);
        var seatsNumber = SeatsNumber.Create(request.TotalSeats);
        var imageUrl = ImageUrl.Create(request.ImageUrl);
        var location = Location.Create(request.City, request.Street, request.Number);
        var target = Enum.Parse<Target>(request.Target, true);

        exitstsingEvent.ChangeTitle(request.Title);
        exitstsingEvent.ChangeDescription(request.Description);
        exitstsingEvent.ChangePeriod(period.Value);
        exitstsingEvent.ChangeDeadlineRegister(deadlineRegister);
        exitstsingEvent.ChangeSeatsNumber(seatsNumber);
        exitstsingEvent.ChangeImageUrl(imageUrl);
        exitstsingEvent.ChangeLocation(location);
        exitstsingEvent.ChangeTarget(target);

        await _eventRepository.UpdateAsync(exitstsingEvent, cancellationToken);

        await _cacheService.RemoveAsync(exitstsingEvent.Id.ToString(), cancellationToken);

        return _mapper.Map<EventDto>(exitstsingEvent);
    }
}
