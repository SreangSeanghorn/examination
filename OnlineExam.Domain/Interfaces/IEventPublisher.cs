using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineExam.Domain.Interfaces
{
    public interface IEventPublisher
    {
        Task Publish<T>(T @event) where T : IDomainEvent;
    }
}