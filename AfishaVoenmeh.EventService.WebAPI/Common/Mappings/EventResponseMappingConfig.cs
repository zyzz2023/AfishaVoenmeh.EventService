using AfishaVoenmeh.EventService.Application.Features.Event.Common;
using AfishaVoenmeh.EventService.Contracts.Responses;
using Mapster;

namespace AfishaVoenmeh.EventService.WebAPI.Common.Mappings;

public class EventResponseMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<EventDto, EventResponse>()
            .Map(dest => dest.Status, src => src.Status.ToString())
            .Map(dest => dest.Target, src => src.Target.ToString());

        config.NewConfig<LocationDto, LocationResponse>();
    }
}
