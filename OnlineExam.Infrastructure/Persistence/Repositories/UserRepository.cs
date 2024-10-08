using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineExam.Domain.Entities;
using OnlineExam.Domain.Repositories;
using OnlineExam.Infrastructure.Persistence.DBContext;


namespace OnlineExam.Infrastructure.Persistence
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _context.Set<User>().FirstOrDefaultAsync(u => u.Email.Value == email);
        }

        public async Task<User> GetUserByUsernameAsync(string username)
        {
            return await _context.Set<User>().FirstOrDefaultAsync(u => u.Username == username);
        }
        public async Task<User> GetUserAndUserRoleByEmail(string email)
        {
            return await _context.Set<User>().Include(u => u.Roles).FirstOrDefaultAsync(u => u.Email.Value == email);
        }

        public Task<User> LoginUserAsync(string email, string password)
        {
            return _context.Set<User>().FirstOrDefaultAsync(u => u.Email.Value == email && u.Password == password);
        }

        public Task<User> GetUserByEmailWithRolesAsync(string email)
        {
           return _context.Set<User>().Include(u => u.Roles).FirstOrDefaultAsync(u => u.Email.Value == email);
        }
    }
}