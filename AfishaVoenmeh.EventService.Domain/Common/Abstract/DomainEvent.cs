using MediatR;
namespace AfishaVoenmeh.EventService.Domain.Common.Abstract;

public record DomainEvent(Guid Id) : INotification;
