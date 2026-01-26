using AfishaVoenmeh.EventService.Domain.EventAggregate.DomainEvents;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AfishaVoenmeh.EventService.Application.Features.Event.DomainEventHandlers;

public class EventStartedDomainEventHandler
    : INotificationHandler<EventStartedDomainEvent>
{
    private readonly ILogger<EventStartedDomainEventHandler> _logger;

    public EventStartedDomainEventHandler(ILogger<EventStartedDomainEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(EventStartedDomainEvent notification, CancellationToken cancellationToken)
    {
        // Add event bus

        // Publish

        _logger.LogInformation("Event with ID: {EventId} has been started.", notification.EventId);

        return Task.CompletedTask;
    }
}
