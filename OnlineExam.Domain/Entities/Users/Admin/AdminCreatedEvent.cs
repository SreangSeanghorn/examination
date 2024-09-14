using System;
using OnlineExam.Domain.Implementation;

namespace OnlineExam.Domain.Entities.Users.Admin;

public class AdminCreatedEvent : DomainEvent<AdminCreatedEventData>
{
    public AdminCreatedEvent(Guid entityId, AdminCreatedEventData content) : base(entityId, content)
    {
    }
}
