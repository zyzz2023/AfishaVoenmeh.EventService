using AfishaVoenmeh.EventService.Application.Features.Event.Commands.ReleaseSeat;
using AfishaVoenmeh.EventService.Application.Features.Event.Commands.ReserveSeat;
using AfishaVoenmeh.EventService.Domain.EventAggregate.Enums;
using AfishaVoenmeh.EventService.Grpc;
using AfishaVoenmeh.Shared.Contracts.Protos.Event;
using Grpc.Core;
using MediatR;

namespace AfishaVoenmeh.EventService.Grpc.Services;

public class EventCapacityGrpcService : EventCapacityService.EventCapacityServiceBase
{
    private readonly ISender _sender;
    private readonly ILogger<EventCapacityGrpcService> _logger;
    
    public EventCapacityGrpcService(
        ILogger<EventCapacityGrpcService> logger,
        ISender sender)
    {
        _logger = logger;
        _sender = sender;
    }

    public override async Task<ReserveSeatResponse> ReserveSeat(ReserveSeatRequest request, ServerCallContext context)
    { 
        var eventId = Guid.Parse(request.EventId);
        var userRole = Enum.Parse<Target>(request.UserRole, true);

        var command = new ReserveSeatCommand(eventId, userRole);

        var result = await _sender.Send(command);

        return result.Match(
            success => new ReserveSeatResponse
            {
                Success = success,
                Message = "Seat reserved successfully."
            },
            errors => new ReserveSeatResponse
            {
                Success = false,
                Message = $"Failed to reserve seat: {string.Join(", ", errors.Select(e => e.Description))}"
            });
    }

    public override async Task<ReleaseSeatResponse> ReleaseSeat(ReleaseSeatRequest request, ServerCallContext context)
    {
        var eventId = Guid.Parse(request.EventId);

        var command = new ReleaseSeatCommand(eventId);

        var result = await _sender.Send(command);

        return result.Match(
            success => new ReleaseSeatResponse
            {
                Success = success,
                Message = "Seat released successfully."
            },
            errors => new ReleaseSeatResponse
            {
                Success = false,
                Message = $"Failed to release seat: {string.Join(", ", errors.Select(e => e.Description))}"
            });
    }
}
