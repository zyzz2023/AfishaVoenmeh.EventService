using AfishaVoenmeh.EventService.Application.Common.Interfaces.Persistence;
using AfishaVoenmeh.EventService.Application.Features.Event.Common;
using AfishaVoenmeh.EventService.Domain.EventAggregate.Enums;
using AfishaVoenmeh.EventService.Domain.EventAggregate.ValueObjects;
using ErrorOr;
using MapsterMapper;
using MediatR;

namespace AfishaVoenmeh.EventService.Application.Features.Event.Commands.Create;

public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, ErrorOr<EventDto>>
{
    private readonly IEventRepository _eventRepository;

    private readonly IMapper _mapper;

    public CreateEventCommandHandler(IEventRepository eventRepository, IMapper mapper)
    {
        _eventRepository = eventRepository;
        _mapper = mapper;
    }

    public async Task<ErrorOr<EventDto>> Handle(CreateEventCommand request, CancellationToken cancellationToken)
    {
        var period = Period.Create(request.StartsAt, request.EndsAt);
        if (period.IsError)
            return period.FirstError;

        var seatsNumber = SeatsNumber.Create(request.TotalSeats);
        if(seatsNumber.IsError)
            return seatsNumber.FirstError;

        var imageUrl = ImageUrl.Create(request.ImageUrl);
        if(imageUrl.IsError)
            return imageUrl.FirstError;

        var location = Location.Create(request.City, request.Street, request.Number);
        if(location.IsError)
            return location.FirstError;

        // Сделать валидатор, который будет валидирвать строковые значения enum
        var status = Enum.Parse<Status>(request.Status, true);
        var target = Enum.Parse<Target>(request.Target, true);

        var newEvent = Domain.EventAggregate.Event.Create(
            request.Title,
            request.Description,
            period.Value,
            seatsNumber.Value,
            imageUrl.Value,
            location.Value,
            status,
            target);

        if (newEvent.IsError)
            return newEvent.FirstError;

        await _eventRepository.AddAsync(newEvent.Value, cancellationToken);

        return _mapper.Map<EventDto>(newEvent.Value);
    }
}