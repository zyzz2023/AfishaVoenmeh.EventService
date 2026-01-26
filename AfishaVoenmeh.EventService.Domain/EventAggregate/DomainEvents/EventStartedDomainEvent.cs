using AfishaVoenmeh.EventService.Domain.Common.Abstract;

namespace AfishaVoenmeh.EventService.Domain.EventAggregate.DomainEvents;

public record EventStartedDomainEvent(Guid Id, Guid EventId) : DomainEvent(Id);