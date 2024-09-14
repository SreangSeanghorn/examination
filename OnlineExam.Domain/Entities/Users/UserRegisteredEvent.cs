using System;
using OnlineExam.Domain.Implementation;

namespace OnlineExam.Domain.Entities.Users

{
    public class UserRegisteredEvent : DomainEvent<UserRegisteredEventData>
    {
        public UserRegisteredEvent(Guid entityId, UserRegisteredEventData content) : base(entityId, content)
        {
        }
    }
}
