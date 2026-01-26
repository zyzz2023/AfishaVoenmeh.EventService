using AfishaVoenmeh.EventService.Domain.EventAggregate.DomainEvents;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AfishaVoenmeh.EventService.Application.Features.Event.DomainEventHandlers;

public class EventFinishedDomainEventHandler
    : INotificationHandler<EventFinishedDomainEvent>
{
    private readonly ILogger<EventFinishedDomainEventHandler> _logger;

    public EventFinishedDomainEventHandler(ILogger<EventFinishedDomainEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(EventFinishedDomainEvent notification, CancellationToken cancellationToken)
    {
        // Add event bus

        // Publish

        _logger.LogInformation("Event with ID: {EventId} has been finished.", notification.EventId);

        return Task.CompletedTask;
    }
}
