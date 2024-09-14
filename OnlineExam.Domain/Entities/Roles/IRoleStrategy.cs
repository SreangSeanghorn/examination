using System;

namespace OnlineExam.Domain.Entities.Roles;

public interface IRoleStrategy
{
    void HandleRole(User user);
}
