using AfishaVoenmeh.EventService.Domain.Common.Abstract;

namespace AfishaVoenmeh.EventService.Domain.EventAggregate.DomainEvents;

public sealed record EventCancelledDomainEvent(Guid Id , Guid EventId) : DomainEvent(Id);
