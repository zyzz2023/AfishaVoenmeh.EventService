
using FluentValidation;

namespace AfishaVoenmeh.EventService.Application.Features.Event.Commands.ReserveSeat;

public class ReserveSeatCommandValidator : AbstractValidator<ReserveSeatCommand>
{
    public ReserveSeatCommandValidator()
    {
        RuleFor(x => x.EventId)
            .NotEmpty()
            .WithMessage("Event ID is required.")
            .Must(id => id != Guid.Empty)
            .WithMessage("Invalid Event ID format.");
        RuleFor(x => x.UserRole)
            .IsInEnum()
            .WithMessage("Invalid user role.");
    }
}
