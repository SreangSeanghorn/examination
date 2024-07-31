using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineExam.Domain.Values;

namespace OnlineExam.Infrastructure.Services
{
    public interface IAuthenticationService
    {
         Task<AuthenticationResult> RegisterAsync(string username, string email, string password);
        Task<AuthenticationResult> LoginAsync(string username, string password);
        
    }
}