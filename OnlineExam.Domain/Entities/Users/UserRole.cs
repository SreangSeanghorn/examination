using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineExam.Domain.Entities.Users
{
    public class UserRole : Entity<Guid>
    {
        private Guid _userRoleId;
        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }
        
    }
}