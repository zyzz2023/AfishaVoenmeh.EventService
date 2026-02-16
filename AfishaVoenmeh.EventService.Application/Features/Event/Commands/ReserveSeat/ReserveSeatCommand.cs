using AfishaVoenmeh.EventService.Domain.EventAggregate.Enums;
using ErrorOr;
using MediatR;

namespace AfishaVoenmeh.EventService.Application.Features.Event.Commands.ReserveSeat;

public record ReserveSeatCommand(Guid EventId, Target UserRole) : IRequest<ErrorOr<bool>>;
