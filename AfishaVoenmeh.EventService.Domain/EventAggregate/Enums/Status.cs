using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AfishaVoenmeh.EventService.Domain.EventAggregate.Enums;

public enum Status
{
    Created = 1,
    Started = 2,
    Finished = 3,
    Archived = 4,
    Cancelled = 5
}
