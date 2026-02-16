using AfishaVoenmeh.EventService.Application.Common.Interfaces.Persistence;
using AfishaVoenmeh.EventService.Application.Common.Interfaces.Services;
using ErrorOr;
using MediatR;

namespace AfishaVoenmeh.EventService.Application.Features.Event.Commands.ReserveSeat;

public class ReserveSeatCommandHandler : IRequestHandler<ReserveSeatCommand, ErrorOr<bool>>
{
    private readonly IEventRepository _eventRepository;

    public ReserveSeatCommandHandler(
        IEventRepository eventRepository)
    {
        _eventRepository = eventRepository;
    }

    public async Task<ErrorOr<bool>> Handle(ReserveSeatCommand request, CancellationToken cancellationToken)
    {
        var existingEvent = await _eventRepository.GetByIdAsync(request.EventId, true, cancellationToken);
        if (existingEvent is null)
        {
            return Error.NotFound("Event_NotFound", "The event was not found.");
            // TODO: Поменять на application error
        }

        var result = existingEvent.ReserveSeat(request.UserRole);
        if (result.IsError)
        {
            return result.Errors;
        }

        await _eventRepository.UpdateAsync(existingEvent, cancellationToken);

        return true;
    }
}
