using AfishaVoenmeh.EventService.Domain.EventAggregate;

namespace AfishaVoenmeh.EventService.Application.Common.Interfaces.Persistence;

public interface IEventRepository : IRepository<Event>
{
    Task<IEnumerable<Event>> GetEventsForStatusProcessingAsync(
        DateTime now,
        bool enableTracking,
        CancellationToken ct = default);
}
