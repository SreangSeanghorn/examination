using System;
using Microsoft.AspNetCore.Identity;
using OnlineExam.Application.CommandHandler;
using OnlineExam.Application.Common;
using OnlineExam.Domain.Entities;
using OnlineExam.Domain.Repositories;
using OnlineExam.Domain.Services;
using OnlineExam.Infrastructure;

namespace OnlineExam.Application.Authentication.UserLogin;

public class UserLoginCommandHandler : ICommandHandler<UserLoginCommand, BaseResponse<UserLoginResponse>>
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher<User> _passwordHasher;
    private readonly IJwtTokenGenerator _tokenService;
    private readonly IUserService userService;

    public UserLoginCommandHandler(IUserRepository userRepository, IPasswordHasher<User> passwordHasher, IJwtTokenGenerator tokenService, IUserService userService)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
        _tokenService = tokenService;
        this.userService = userService;
    }
    
    public async Task<BaseResponse<UserLoginResponse>> Handle(UserLoginCommand command, CancellationToken cancellationToken)
    {
        
        var user = await userService.LoginUserAsync(command.Email, command.Password);
        if (user == null)
        {
            return new BaseResponse<UserLoginResponse>(false, "Invalid email or password", null);
        }
        var roles = user.Roles.Select(r => r.Name).ToList();
        var token = _tokenService.GenerateToken(user.Id, user.Username);
        var response = new UserLoginResponse(token, roles);
        var result = new BaseResponse<UserLoginResponse>(true, "Login successful", response);
        return await Task.FromResult(result);
    }
}
