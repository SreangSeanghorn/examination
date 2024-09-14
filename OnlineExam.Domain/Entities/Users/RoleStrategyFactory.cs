using System;
using OnlineExam.Domain.Entities.Roles;
using OnlineExam.Domain.Entities.Users.Admin;
using OnlineExam.Domain.Entities.Users.Defaults;
using OnlineExam.Domain.Entities.Users.Students;
using OnlineExam.Domain.Entities.Users.Teacher;

namespace OnlineExam.Domain.Entities.Users;

public static class RoleStrategyFactory
{
    private static readonly Dictionary<string, IRoleStrategy> _strategies = new Dictionary<string, IRoleStrategy>
    {
        {Role.Admin.Name, new AdminRoleStrategy()},
        {Role.Teacher.Name, new TeacherRoleStrategy()},
        {Role.Student.Name, new StudentRoleStrategy()},
        {Role.Defaults.Name, new DefaultRoleStrategy()}
    };

    public static IRoleStrategy GetStrategy(Role role)
    {
        if(_strategies.ContainsKey(role.Name))
        {
            return _strategies[role.Name];
        }
        throw new ArgumentException("No strategy found for the given role");
    }
}

