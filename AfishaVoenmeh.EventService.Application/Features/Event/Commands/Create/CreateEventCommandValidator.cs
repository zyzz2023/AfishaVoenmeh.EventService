using AfishaVoenmeh.EventService.Domain.EventAggregate.Enums;
using FluentValidation;

namespace AfishaVoenmeh.EventService.Application.Features.Event.Commands.Create;

public class CreateEventCommandValidator : AbstractValidator<CreateEventCommand>
{
    public CreateEventCommandValidator()
    {
        RuleFor(c => c.Title)
            .Must(str => !string.IsNullOrWhiteSpace(str))
            .WithMessage("Title cannot be empty.")
            .MaximumLength(100)
            .WithMessage("Title maximum length is 100.");

        RuleFor(c => c.Description)
            .Must(str => !string.IsNullOrWhiteSpace(str))
            .WithMessage("Description cannot be empty.")
            .MaximumLength(200)
            .WithMessage("Title maximum length is 200.");

        RuleFor(c => c.StartsAt)
            .NotNull()
            .WithMessage("Start time cannot be null.")
            .LessThan(c => c.EndsAt)
            .WithMessage("Start time must be earlier than end time.")
            .GreaterThanOrEqualTo(DateTime.UtcNow)
            .WithMessage("Start time cannot be in the past.");

        RuleFor(c => c.EndsAt)
            .NotNull()
            .WithMessage("End time cannot be null.");

        RuleFor(c => c.DeadlineRegister)
            .NotNull()
            .WithMessage("Deadline register time cannot be null.");

        RuleFor(c => c.TotalSeats)
            .NotNull()
            .WithMessage("Total seats cannot be null.")
            .InclusiveBetween(1, 200)
            .WithMessage("The total number of seats must be from 1 to 200 inclusive.");

        RuleFor(c => c.City)
            .Must(str => !string.IsNullOrWhiteSpace(str))
            .WithMessage("Address field (city) cannot be empty.");

        RuleFor(c => c.Street)
            .Must(str => !string.IsNullOrWhiteSpace(str))
            .WithMessage("Address field (street) cannot be empty.");

        RuleFor(c => c.Number)
            .GreaterThan(0)
            .WithMessage("The address number must be greater than zero.");

        RuleFor(c => c.ImageUrl)
            .Must(url => !string.IsNullOrWhiteSpace(url))
            .WithMessage("The url cannot be empty.")
            .Must(url => Uri.IsWellFormedUriString(url, UriKind.Absolute))
            .WithMessage("Invalid url format.");

        RuleFor(c => c.Target)
            .NotNull()
            .WithMessage("Target cannot be null.")
            .Must(s => Enum.TryParse<Target>(s, true, out _))
            .WithMessage("Incorrect target.");
    }
}
