using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AfishaVoenmeh.EventService.Application.Features.Event.Common;

public record LocationDto(
    string City,
    string Street,
    int? Number);