using FluentValidation;

namespace AfishaVoenmeh.EventService.Application.Features.Event.Queries.GetById;

public class GetByIdQueryValidator : AbstractValidator<GetEventByIdQuery>
{
    public GetByIdQueryValidator()
    {
        RuleFor(q => q.EventId)
            .Must(id => id != Guid.Empty)
            .WithMessage("Event ID cannot be empty.");
    }
}
