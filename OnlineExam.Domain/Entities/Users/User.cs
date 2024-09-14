using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using OnlineExam.Domain.Entities.Users;
using OnlineExam.Domain.Entities.Users.Teacher;
using OnlineExam.Domain.Values;

namespace OnlineExam.Domain.Entities
{
    public class User : AggregateRoot<Guid>
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public Email Email { get; set; }
        public string Password { get; set; }
        public ICollection<Role> Roles { get; set; } = new List<Role>();

        public User(){
        }
        public User(Guid id, string username, Email email, string password)
        {
            Id = id;
            Username = username;
            Email = email;
            Password = password;
        }
        

        public static User CreateUser(string username, Email email, string password)
        {
            password = new PasswordHasher<User>().HashPassword(null, password);
            return new User(Guid.NewGuid(), username, email, password);
        }
        public bool VerifyPassword(string password)
        {
            var passwordHasher = new PasswordHasher<User>();
            return passwordHasher.VerifyHashedPassword(this, Password, password) == PasswordVerificationResult.Success;
        }
        public void ChangeEmail(Email email)
        {
            Email = email;
        }

        public void AssignRole(Role role)
        {
            if (!Roles.Contains(role)) Roles.Add(role);
            else return;
            var strategy = RoleStrategyFactory.GetStrategy(role);
            strategy.HandleRole(this);
            RaiseRoleAssignedEvent(role.Name);
            return;
        }

        public void RaiseRoleAssignedEvent(string role)
        {
            var roleAssignedData = new RoleAssignedData(Id, role);
            var roleAssignedEvent = new RoleAssignedEvent(Id, roleAssignedData);
            RaiseDomainEvents(roleAssignedEvent); 
        }

        public List<string> GetRoles()
        {
            return Roles.Select(r => r.Name).ToList();
        }


    }

   
}