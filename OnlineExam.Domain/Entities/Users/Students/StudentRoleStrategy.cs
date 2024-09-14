using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineExam.Domain.Entities.Roles;

namespace OnlineExam.Domain.Entities.Users.Students
{
    public class StudentRoleStrategy : IRoleStrategy
    {
        public void HandleRole(User user)
        {
            user.AssignRole(new Role("Student"));
            user.RaiseRoleAssignedEvent("Student");
        }
    }

}