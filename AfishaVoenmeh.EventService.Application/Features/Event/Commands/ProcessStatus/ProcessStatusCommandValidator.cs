using FluentValidation;

namespace AfishaVoenmeh.EventService.Application.Features.Event.Commands.ProcessStatus;

public class ProcessStatusCommandValidator : AbstractValidator<ProcessStatusCommand>
{
    public ProcessStatusCommandValidator()
    {
        RuleFor(c => c.Now)
            .NotEmpty()
            .WithMessage("The 'Now' field must not be empty.");
    }
}
