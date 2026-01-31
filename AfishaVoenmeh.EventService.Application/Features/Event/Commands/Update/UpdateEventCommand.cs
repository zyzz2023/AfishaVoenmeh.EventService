using AfishaVoenmeh.EventService.Application.Features.Event.Common;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AfishaVoenmeh.EventService.Application.Features.Event.Commands.Update;

public record UpdateEventCommand(
    Guid EventId,
    string Title,
    string Description,
    DateTime StartsAt,
    DateTime EndsAt,
    DateTime DeadlineRegister,
    int TotalSeats,
    string ImageUrl,
    string City,
    string Street,
    int Number,
    string Target) : IRequest<ErrorOr<EventDto>>;