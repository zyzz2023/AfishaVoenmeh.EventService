using ErrorOr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AfishaVoenmeh.EventService.Domain.Common.Errors;

public static class DomainErrors
{
    // ------------------ PERIOD ERRORS (VO) ------------------
    public static Error LongPeriod =>
        Error.Validation("Period_TooLong", "Event duration cannot exceed 8 hours.");

    // ------------------ SEATSNUMBER ERRORS (VO) ------------------
    public static Error IncorrectSeatsNumber =>
        Error.Validation("SeatsNumber_Incorrect",
                "The number of seats cannot be less than or equal to zero");

    public static Error CurrentSeatsIncorrect =>
        Error.Validation("SeatsNumber_Current_Incorrect",
                "Current available seats cannot be larger than total seats.");

    // ------------------ RESERVE ERRORS ------------------

    public static Error NotEnoughSeats =>
        Error.Validation("SeatsNumber_NotEnough",
            "Not enough available seats for the reservation.");

    public static Error IncorrectRoleForEvent =>
        Error.NotFound("Incorrect_Role", 
            "Reservation is not possible because the user's role does not match the target audience of the event");

    public static Error DeadlineRegisterExpired =>
        Error.Validation("DeadlineRegister_Expired", 
            "The registration deadline for this event has expired.");

    public static Error EventStatusIncorrect =>
        Error.Validation("Event_Status_Incorrect",
            "The event is not in a state that allows this operation.");
}