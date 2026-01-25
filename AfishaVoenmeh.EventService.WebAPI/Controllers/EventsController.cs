using AfishaVoenmeh.EventService.Application.Features.Event.Commands.Archive;
using AfishaVoenmeh.EventService.Application.Features.Event.Commands.Create;
using AfishaVoenmeh.EventService.Application.Features.Event.Commands.Delete;
using AfishaVoenmeh.EventService.Application.Features.Event.Commands.Update;
using AfishaVoenmeh.EventService.Application.Features.Event.Queries.GetById;
using AfishaVoenmeh.EventService.Contracts.Requests;
using AfishaVoenmeh.EventService.Contracts.Responses;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AfishaVoenmeh.EventService.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EventsController : ControllerBase
{
    private readonly ISender _sender;
    private readonly IMapper _mapper;

    public EventsController(ISender sender, IMapper mapper)
    {
        _sender = sender;
        _mapper = mapper;
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetEventByIdAsync([FromRoute] Guid id, CancellationToken ct)
    {
        var query = new GetEventByIdQuery(id);

        var result = await _sender.Send(query, ct);
        
        return result.Match<IActionResult>(
            eventDto => Ok(_mapper.Map<EventResponse>(eventDto)),
            errors => BadRequest(errors));
    }

    [HttpPost]
    public async Task<IActionResult> CreateEventAsync([FromBody] CreateEventRequest request, CancellationToken ct)
    {
        var command = _mapper.Map<CreateEventCommand>(request);

        var result = await _sender.Send(command, ct);

        return result.Match<IActionResult>(
            eventDto => Created(HttpContext.Request.Path, _mapper.Map<EventResponse>(eventDto)),
            errors => BadRequest(errors));
    }

    [HttpPut]
    public async Task<IActionResult> UpdateEventAsync([FromBody] UpdateEventRequest request, CancellationToken ct)
    {
        var command = _mapper.Map<UpdateEventCommand>(request);

        var result = await _sender.Send(command, ct);

        return result.Match<IActionResult>(
            eventDto => Created(HttpContext.Request.Path, _mapper.Map<EventResponse>(eventDto)),
            errors => BadRequest(errors));
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteEventAsync([FromRoute] Guid id, CancellationToken ct)
    {
        var command = new DeleteEventCommand(id);

        var result = await _sender.Send(command, ct);

        return result.Match<IActionResult>(
            success => NoContent(),
            errors => BadRequest(errors));
    }

    [HttpPost("Archive/{id:guid}")]
    public async Task<IActionResult> ArchiveEventAsync([FromRoute] Guid id, CancellationToken ct)
    {
        var command = new ArchiveEventCommand(id);

        var result = await _sender.Send(command, ct);

        return result.Match<IActionResult>(
            success => NoContent(),
            errors => BadRequest(errors));
    }
}
