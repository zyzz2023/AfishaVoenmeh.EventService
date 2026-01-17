using AfishaVoenmeh.EventService.Domain.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AfishaVoenmeh.EventService.Domain.Common.Abstract;

public class AggregateRoot<TId> : Entity<TId>
    where TId : notnull
{

}
