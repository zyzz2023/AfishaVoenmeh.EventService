using FluentValidation;

namespace AfishaVoenmeh.EventService.Application.Features.Event.Commands.Cancel;

public class CancelEventCommandValidator : AbstractValidator<CancelEventCommand>
{
    public CancelEventCommandValidator()
    {
        RuleFor(c => c.EventId)
            .Must(id => id != Guid.Empty)
            .WithMessage("EventId must not be empty.");
    }
}
