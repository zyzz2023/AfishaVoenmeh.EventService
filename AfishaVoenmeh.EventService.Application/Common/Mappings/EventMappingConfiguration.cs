using AfishaVoenmeh.EventService.Application.Features.Event.Commands.Update;
using AfishaVoenmeh.EventService.Application.Features.Event.Common;
using AfishaVoenmeh.EventService.Domain.EventAggregate;
using AfishaVoenmeh.EventService.Domain.EventAggregate.ValueObjects;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AfishaVoenmeh.EventService.Application.Common.Mappings;

public class EventMappingConfiguration : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<LocationDto, Location>();

        config.NewConfig<Event, EventDto>()
            .Map(dest => dest.CurrentSeats,
                src => src.SeatsNumber.Current)
            .Map(dest => dest.TotalSeats,
                src => src.SeatsNumber.Total)
            .Map(dest => dest.StartsAt,
                src => src.Period.StartsAt)
            .Map(dest => dest.EndsAt,
                src => src.Period.EndsAt)
            .Map(dest => dest.ImageUrl,
                src => src.ImageUrl.Value)
            .Map(dest => dest.Location,
                src => src.Location.Adapt<LocationDto>());

        config.NewConfig<UpdateEventCommand, EventDto>();
    }
}