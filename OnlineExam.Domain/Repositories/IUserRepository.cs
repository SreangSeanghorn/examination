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
    }
}