using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace OnlineExam.Domain.Interfaces
{
    public interface IDomainEvent
    {
        DateTime OccurredOn { get; }
        Guid EntityId { get; }
    }


}