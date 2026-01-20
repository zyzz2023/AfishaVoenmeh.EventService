using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AfishaVoenmeh.EventService.Infrastructure.Common;

public class RedisOptions
{
    public const string RedisOptionsSection = "RedisOptions";
    public const string RedisConnectionStringSection = "RedisOptions:RedisConnectionString";
    public const string RedisInstanceNameSection = "RedisOptions:InstanceName";

    public int TimeToLiveInMinutes { get; set; }
}
