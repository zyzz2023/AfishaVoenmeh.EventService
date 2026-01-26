using AfishaVoenmeh.EventService.Domain.EventAggregate.DomainEvents;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AfishaVoenmeh.EventService.Application.Features.Event.DomainEventHandlers;

public class EventArchivedDomainEventHandler : INotificationHandler<EventArchivedDomainEvent>
{
    private readonly ILogger<EventArchivedDomainEventHandler> _logger;

    public EventArchivedDomainEventHandler(ILogger<EventArchivedDomainEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(EventArchivedDomainEvent notification, CancellationToken cancellationToken)
    {
        // Add event bus

        // Publish

        _logger.LogInformation("Event with ID: {EventId} has been archived.", notification.EventId);

        return Task.CompletedTask;
    }
}
