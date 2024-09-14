using OnlineExam.Domain.Implementation;

namespace OnlineExam.Domain.Entities.Users.Teacher;

public class RoleAssignedEvent : DomainEvent<RoleAssignedData>
{
    public RoleAssignedEvent(Guid entityId, RoleAssignedData content) : base(entityId, content)
    {
    }
}
