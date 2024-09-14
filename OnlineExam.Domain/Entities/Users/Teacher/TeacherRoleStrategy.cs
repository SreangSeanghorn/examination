using System;
using OnlineExam.Domain.Entities.Roles;

namespace OnlineExam.Domain.Entities.Users.Teacher;

public class TeacherRoleStrategy : IRoleStrategy
{
    public void HandleRole(User user)
    {
        user.AssignRole(new Role("Teacher"));
        user.RaiseRoleAssignedEvent("Teacher");  
    }


}
