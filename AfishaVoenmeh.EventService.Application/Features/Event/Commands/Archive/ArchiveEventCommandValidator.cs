using FluentValidation;

namespace AfishaVoenmeh.EventService.Application.Features.Event.Commands.Archive;

public class ArchiveEventCommandValidator : AbstractValidator<ArchiveEventCommand>
{
    public ArchiveEventCommandValidator()
    {
        RuleFor(x => x.EventId)
            .Must(id => id != Guid.Empty)
            .WithMessage("EventId must not be empty.");
    }
}
