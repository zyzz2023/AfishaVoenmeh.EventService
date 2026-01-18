using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AfishaVoenmeh.EventService.Contracts.Requests;

public record CreateEventRequest(
    string Title,
    string Description,
    DateTime StartsAt,
    DateTime EndsAt,
    int TotalSeats,
    string ImageUrl,
    string City,
    string Street,
    int Number,
    string Status,
    string Target);