using AfishaVoenmeh.EventService.Domain.EventAggregate.DomainEvents;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AfishaVoenmeh.EventService.Application.Features.Event.DomainEventHandlers;

public class EventCancelledDomainEventHandler
    : INotificationHandler<EventCancelledDomainEvent>
{
    private readonly ILogger<EventCancelledDomainEventHandler> _logger;

    public EventCancelledDomainEventHandler(ILogger<EventCancelledDomainEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(EventCancelledDomainEvent notification, CancellationToken cancellationToken)
    {
        // Add event bus

        // Publish

        _logger.LogInformation("Event with ID: {EventId} has been cancelled.", notification.EventId);

        return Task.CompletedTask;
    }
}
