using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineExam.Domain.Entities;
using OnlineExam.Domain.Values;
using OnlineExam.Domain.Repositories;
using OnlineExam.Infrastructure.Authentication;

namespace OnlineExam.Infrastructure.Services
{
    public class AuthenticationServiceImp : IAuthenticationService
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;
        public AuthenticationServiceImp(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }
        public async Task<AuthenticationResult> RegisterAsync(string username, string email, string password)
        { 
            var user =   await _userRepository.GetUserByEmailAsync(email);
            if(_userRepository.GetUserByEmailAsync(email) != null)
            {
               throw new Exception("User already exists");
            }
            user = new User(Guid.NewGuid(), username, Email.Create(email), password);
            var token = _jwtTokenGenerator.GenerateToken(user.Id, user.Username);
            _userRepository.AddAsync(user);
           return await Task.FromResult(new AuthenticationResult(user, token));
        }

        public Task<AuthenticationResult> LoginAsync(string username, string password)
        {
            var user = _userRepository.GetUserByUsernameAsync(username).Result;
            if(user == null || user.Password != password)
            {
                throw new Exception("Invalid username or password");
            }
            var token = _jwtTokenGenerator.GenerateToken(user.Id, username);
            return Task.FromResult(new AuthenticationResult(user, token));
        }   
    }

}