using AfishaVoenmeh.EventService.Application.Features.Event.Commands.Create;
using AfishaVoenmeh.EventService.Contracts.Requests;
using Mapster;

namespace AfishaVoenmeh.EventService.WebAPI.Common.Mappings;

public class EventRequestsMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreateEventRequest, CreateEventCommand>();
    }
}
