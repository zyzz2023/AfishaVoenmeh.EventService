using AfishaVoenmeh.EventService.Application.Common.Interfaces.Services;
using AfishaVoenmeh.EventService.Application.Features.Event.Common;
using AfishaVoenmeh.EventService.Domain.EventAggregate;
using AfishaVoenmeh.EventService.Infrastructure.Common;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace AfishaVoenmeh.EventService.Infrastructure.Services;

public class RedisDistributedCacheService : ICacheService
{
    private readonly IDistributedCache _cache;

    private readonly JsonSerializerOptions _jsonOptions;

    private readonly RedisOptions _redisOptions;

    public RedisDistributedCacheService(IDistributedCache cache, IOptions<RedisOptions> options)
    {
        _cache = cache;
        _jsonOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        _redisOptions = options.Value;
    }

    public async Task<EventDto?> GetAsync(string key, CancellationToken ct = default)
    {
        var jsonBytes = await _cache.GetAsync(key, ct);

        return jsonBytes != null ? 
            JsonSerializer.Deserialize<EventDto?>(jsonBytes, _jsonOptions) 
            : default;
    }

    public async Task SetAsync(string key, EventDto entity, CancellationToken ct = default)
    {
        var cacheOptions = new DistributedCacheEntryOptions();
        cacheOptions.SetSlidingExpiration(TimeSpan.FromMinutes(_redisOptions.TimeToLiveInMinutes));

        var json = JsonSerializer.Serialize(entity, _jsonOptions);

        await _cache.SetStringAsync(key, json, cacheOptions, ct);
    }

    public async Task RemoveAsync(string key, CancellationToken ct = default) =>
        await _cache.RemoveAsync(key, ct);
}
