using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineExam.Domain.Implementation;
using OnlineExam.Domain.Interfaces;

namespace OnlineExam.Domain.Entities
{
    public class AggregateRoot<TId> : Entity<TId>, IAggregateRoot
    {
        private readonly List<IDomainEvent> _events = new List<IDomainEvent>();
        public IReadOnlyList<IDomainEvent> Events => _events;

        protected void RaiseDomainEvents(IDomainEvent domainEvent)
        {
            _events.Add(domainEvent);
        }
        public void ClearEvents()
        {
            _events.Clear();
        }

        
    }
}