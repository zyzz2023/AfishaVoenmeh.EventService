using FluentValidation;

namespace AfishaVoenmeh.EventService.Application.Features.Event.Commands.Delete;

public class DeleteEventCommandValidator : AbstractValidator<DeleteEventCommand>
{
    public DeleteEventCommandValidator()
    {
        RuleFor(x => x.EventId)
            .Must(id => id != Guid.Empty)
            .WithMessage("EventId must not be empty.");
    }
}
