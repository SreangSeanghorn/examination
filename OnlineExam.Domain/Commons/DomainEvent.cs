using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineExam.Domain.Interfaces;

namespace OnlineExam.Domain.Implementation
{
    public abstract class DomainEvent<T> : IDomainEvent
    {
        public DateTime OccurredOn { get; private set; }
        public Guid EntityId { get; private set; }
        public T Content { get; private set; }
        protected DomainEvent(Guid entityId, T content)
        {
            OccurredOn = DateTime.Now;
            EntityId = entityId;
            Content = content;
        }
    }
}