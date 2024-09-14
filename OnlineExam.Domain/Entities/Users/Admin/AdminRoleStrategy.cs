using System;
using OnlineExam.Domain.Entities.Roles;

namespace OnlineExam.Domain.Entities.Users.Admin;

public class AdminRoleStrategy : IRoleStrategy
{
    public void HandleRole(User user)
    {
        user.AssignRole(new Role("Admin"));
        user.RaiseRoleAssignedEvent("Admin");
    }
}
