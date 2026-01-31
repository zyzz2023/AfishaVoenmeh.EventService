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

        var deadlineRegister = DeadlineRegister.Create(request.DeadlineRegister);
        var seatsNumber = SeatsNumber.Create(request.TotalSeats);
        var imageUrl = ImageUrl.Create(request.ImageUrl);
        var location = Location.Create(request.City, request.Street, request.Number);

        var target = Enum.Parse<Target>(request.Target, true);

        var newEvent = Domain.EventAggregate.Event.Create(
            request.Title,
            request.Description,
            period.Value,
            deadlineRegister,
            seatsNumber,
            imageUrl,
            location,
            target);

        await _eventRepository.AddAsync(newEvent, cancellationToken);

        return _mapper.Map<EventDto>(newEvent);
    }
}