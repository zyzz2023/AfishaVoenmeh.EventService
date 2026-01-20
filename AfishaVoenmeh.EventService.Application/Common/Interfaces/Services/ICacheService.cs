using AfishaVoenmeh.EventService.Application.Features.Event.Common;
using AfishaVoenmeh.EventService.Domain.EventAggregate;

namespace AfishaVoenmeh.EventService.Application.Common.Interfaces.Services;

public interface ICacheService
{
    Task<EventDto?> GetAsync(string key, CancellationToken ct = default);
    Task SetAsync(string key, EventDto entity, CancellationToken ct = default);
    Task RemoveAsync(string key, CancellationToken ct = default);
}
