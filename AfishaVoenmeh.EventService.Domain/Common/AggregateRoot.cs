using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AfishaVoenmeh.EventService.Domain.Common;

public class AggregateRoot<TId> : Entity<TId>
    where TId : notnull
{

}
