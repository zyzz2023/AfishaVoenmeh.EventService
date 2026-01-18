using AfishaVoenmeh.EventService.Application.Features.Event.Commands.Create;
using AfishaVoenmeh.EventService.Application.Features.Event.Queries.GetById;
using AfishaVoenmeh.EventService.Contracts.Requests;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
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
        if (result.IsError)
            return BadRequest(result.FirstError); // Исправить путем добаления общей обработки ошибок

        return Ok(result.Value);
    }

    [HttpPost]
    public async Task<IActionResult> CreateEventAsync([FromBody] CreateEventRequest request, CancellationToken ct)
    {
        var command = _mapper.Map<CreateEventCommand>(request);

        var result = await _sender.Send(command, ct);
        if (result.IsError)
            return BadRequest(result.FirstError);

        return Created(HttpContext.Request.Path.Value, result.Value);
    }
}
