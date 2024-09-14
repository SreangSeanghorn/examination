using System;
using OnlineExam.Domain.Implementation;
using static OnlineExam.Domain.Entities.Users.Teacher.TeacherCreatedEvent;

namespace OnlineExam.Domain.Entities.Users.Teacher;

public partial class TeacherCreatedEvent : DomainEvent<TeacherCreatedEventData>
{
    public TeacherCreatedEvent(Guid entityId, TeacherCreatedEventData content) : base(entityId, content)
    {
    }
}

