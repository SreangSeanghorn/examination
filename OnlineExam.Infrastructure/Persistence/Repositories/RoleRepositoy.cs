using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineExam.Domain.Entities;
using OnlineExam.Domain.Repositories;
using OnlineExam.Infrastructure.Persistence.DBContext;

namespace OnlineExam.Infrastructure.Persistence.Repositories
{
    public class RoleRepositoy : GenericRepository<Role>, IRoleRepository
    {
        public RoleRepositoy(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<Role> GetRoleByNameAsync(string name)
        {
            return await _context.Set<Role>().FirstOrDefaultAsync(r => r.Name == name);
        }
    }
}