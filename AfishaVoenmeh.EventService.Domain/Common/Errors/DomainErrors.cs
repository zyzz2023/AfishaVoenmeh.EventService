using ErrorOr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AfishaVoenmeh.EventService.Domain.Common.Errors;

public static class DomainErrors
{
    // ------------------ URL ERRORS (VO) ------------------
    public static Error EmptyUrl =>
        Error.Validation("Url_Null", "The url cannot be empty");

    public static Error BadUrl =>
        Error.Validation("Url_Incorrect", "Invalid url format");

    // ------------------ ADDRESS ERRORS (VO) ------------------
    public static Error EmptyAddress =>
        Error.Validation("Address_Field_Null", "Address fields cannot be empty");

    public static Error IncorrectAddressNumber =>
        Error.Validation("Number_Incorrect", "The address number must be greater than zero");

    // ------------------ PERIOD ERRORS (VO) ------------------
    public static Error InvalidPeriod =>
        Error.Validation("Period_Invalid", "Start time must be earlier than end time.");

    public static Error PeriodInPast =>
        Error.Validation("Period_InPast", "Start time cannot be in the past.");

    public static Error LongPeriod =>
        Error.Validation("Period_TooLong", "Event duration cannot exceed 8 hours.");

    // ------------------ SEATSNUMBER ERRORS (VO) ------------------
    public static Error IncorrectSeatsNumber =>
        Error.Validation("SeatsNumber_Incorrect",
                "The number of seats cannot be less than or equal to zero");

    public static Error OverLimitSeatsNumber =>
        Error.Validation("SeatsNumber_Limit",
                "The number of seats must be less than or equal to 200.");

    public static Error CurrentSeatsIncorrect =>
        Error.Validation("SeatsNumber_Current_Incorrect",
                "Current available seats cannot be larger than total seats.");

    // ------------------ EVENT ERRORS (Aggregate) ------------------
    public static Error EmptyTitle =>
        Error.Validation("Title_Null", "Title cannot be empty");

    public static Error EmptyDescription =>
        Error.Validation("Description_Null", "Description cannot be empty");
}