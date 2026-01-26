using AfishaVoenmeh.EventService.Application.Common.Interfaces.Persistence;
using AfishaVoenmeh.EventService.Domain.EventAggregate;
using MediatR;

namespace AfishaVoenmeh.EventService.Infrastructure.Data.Repositories;

public class EventRepository : Repository<Event>, IEventRepository
{
    public EventRepository(ApplicationDbContext context, IPublisher publisher)
        : base(context, publisher)
    {
    }
}