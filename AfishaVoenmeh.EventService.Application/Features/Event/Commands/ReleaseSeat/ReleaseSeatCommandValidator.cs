using FluentValidation;

namespace AfishaVoenmeh.EventService.Application.Features.Event.Commands.ReleaseSeat;

public class ReleaseSeatCommandValidator : AbstractValidator<ReleaseSeatCommand>
{
    public ReleaseSeatCommandValidator()
    {
        RuleFor(x => x.EventId)
            .NotEmpty()
            .WithMessage("Event ID is required.")
            .Must(id => id != Guid.Empty)
            .WithMessage("Invalid Event ID format.");
    }
}
