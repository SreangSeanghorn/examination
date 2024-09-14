using OnlineExam.Domain.Entities;
using OnlineExam.Domain.Entities.Users;

namespace OnlineExam.Domain.Services
{
    public interface IUserService
    {
        public Task<User> RegisterUserAsync(string name, string email, string password);
        public Task<User> GetUserByEmailAsync(string email);

        public Task<User> LoginUserAsync(string email, string password);
        public Task AssignRoleAsync(Guid userId, Role role);
    }
}