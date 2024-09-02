using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineExam.Domain.Implementation;

namespace OnlineExam.Domain.Events
{
    public class ExamCreatedEvent : DomainEvent<ExamCreateEventData>
    {
        public ExamCreatedEvent(Guid entityId, ExamCreateEventData content) : base(entityId, content)
        {
        }

    }
}