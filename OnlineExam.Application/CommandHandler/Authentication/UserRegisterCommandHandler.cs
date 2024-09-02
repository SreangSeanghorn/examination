using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineExam.Domain.Entities;
using OnlineExam.Domain.Values;
using OnlineExam.Domain.Repositories;
using OnlineExam.Application.DTO.Authentication;
using OnlineExam.Application.Commands.Authentication;
using Microsoft.AspNetCore.Identity;
using OnlineExam.Contracts.Authentication;
using OnlineExam.Infrastructure.Services;
using OnlineExam.Infrastructure.Authentication;
using OnlineExam.Infrastructure;


namespace OnlineExam.Application.CommandHandler.Authentication
{
    public class UserRegisterCommandHandler : ICommandHandler<UserRegisterCommand, AuthenticationResultResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly  IJwtTokenGenerator _tokenService;
        private readonly IRoleRepository _roleRepository;

        public UserRegisterCommandHandler(IUserRepository userRepository, IPasswordHasher<User> passwordHasher, IJwtTokenGenerator tokenService, IRoleRepository roleRepository)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _tokenService = tokenService;
            _roleRepository = roleRepository;
        }

        public Task<AuthenticationResultResponse> Handle(UserRegisterCommand command, CancellationToken cancellationToken)
        {
            var user = User.CreateUser(command.UserName,
            Email.Create(command.Email),
            command.Password);
            var role = _roleRepository.GetRoleByNameAsync("User").Result;
            user.AssignRole(role);
            _userRepository.AddAsync(user);
            _userRepository.SaveChangesAsync();

            var token = _tokenService.GenerateToken(user.Id, user.Username);
            var response = new AuthenticationResultResponse(user, token);
            return Task.FromResult(response);
        }
    }
}