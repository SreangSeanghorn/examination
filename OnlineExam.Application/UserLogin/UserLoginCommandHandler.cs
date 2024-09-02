using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using OnlineExam.Application.CommandHandler;
using OnlineExam.Domain.Entities;
using OnlineExam.Domain.Repositories;
using OnlineExam.Infrastructure;

namespace OnlineExam.Application.UserLogin
{
    public class UserLoginCommandHandler : ICommandHandler<UserLoginCommand, UserLoginResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly IJwtTokenGenerator _tokenService;
        public UserLoginCommandHandler(IUserRepository userRepository, IPasswordHasher<User> passwordHasher, IJwtTokenGenerator tokenService)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _tokenService = tokenService;
        }
        public async Task<UserLoginResponse> Handle(UserLoginCommand command, CancellationToken cancellationToken)
        {
            var user = _userRepository.GetUserByUsernameAsync(command.Username).Result;
            if (user == null)
            {
                return new UserLoginResponse
                {
                    message = "Invalid Username or Password",
                    Token = null

                };
            }
            var result = _passwordHasher.VerifyHashedPassword(user, user.Password, command.Password);
            if (result == PasswordVerificationResult.Failed)
            {
                return new UserLoginResponse
                {
                    message = "Invalid Username or Password",
                    Token = null
                };
            }
            var token = _tokenService.GenerateToken(user.Id, user.Username);
            return new UserLoginResponse
            {
                message = "Login Successful",
                Token = token
            };
        }
    }
}