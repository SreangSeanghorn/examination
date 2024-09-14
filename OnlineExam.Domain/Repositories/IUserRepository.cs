using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineExam.Domain.Entities;

namespace OnlineExam.Domain.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        public  Task<User> GetUserByEmailAsync(string email);
        public Task<User> GetUserByUsernameAsync(string username);
        public Task<User> LoginUserAsync(string email, string password);

        public Task<User> GetUserByEmailWithRolesAsync(string email);
    }
}