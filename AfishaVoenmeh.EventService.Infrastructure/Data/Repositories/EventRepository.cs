using AfishaVoenmeh.EventService.Application.Common.Interfaces.Persistence;
using AfishaVoenmeh.EventService.Domain.EventAggregate;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AfishaVoenmeh.EventService.Infrastructure.Data.Repositories;

public class EventRepository : Repository<Event>, IEventRepository
{
    public EventRepository(ApplicationDbContext context, IPublisher publisher)
        : base(context, publisher)
    {
    }

    public async Task<IEnumerable<Event>> GetEventsForStatusProcessingAsync(DateTime now, bool enableTracking, CancellationToken ct = default)
    {
        return await _context.Events
            .Where(e => 
            (e.Status == Domain.EventAggregate.Enums.Status.Created && e.Period.StartsAt <= now)
            || (e.Status == Domain.EventAggregate.Enums.Status.Started && e.Period.EndsAt <= now))
            .ToListAsync(ct);
    }
}