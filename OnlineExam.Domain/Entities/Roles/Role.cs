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

        private static readonly Role _teacher = new Role("Teacher");
        private static readonly Role _admin = new Role("Admin");
        private static readonly Role _student = new Role("Student");
        private static readonly Role _default = new Role("Default");
        public Role()
        {
        }
        public Role(string name)
        {
            Name = name;
        }
        // assign static role

        public static Role Teacher => _teacher;
        public static Role Admin => _admin;
        public static Role Student => _student;
        public static Role Defaults => _default;
         public static Role CreateRole(string name, string description)
        {
            return new Role
            {
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

        public override bool Equals(object obj)
        {
            if (obj is Role role)
            {
                return Name == role.Name;
            }
            return false;
        }

        public new int GetHashCode()
        {
            return Name.GetHashCode();
        }


    }
}