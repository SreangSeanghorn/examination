using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineExam.Domain.Entities
{
    public class Role : Entity<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<User> Users { get; set; } = new List<User>();

        public static Role CreateRole(string name, string description)
        {
            return new Role
            {
                Id = Guid.NewGuid(),
                Name = name,
                Description = description
            };
        }
        public static Role GetRole(string name)
        {
            return new Role
            {
                Name = name,
            };
        }
        
    }
}