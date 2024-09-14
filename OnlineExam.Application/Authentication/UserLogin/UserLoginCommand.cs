using System;
using OnlineExam.Application.Commands;
using OnlineExam.Application.Common;
using OnlineExam.Domain.Entities;

namespace OnlineExam.Application.Authentication.UserLogin;

public record UserLoginCommand(
    string Email,
    string Password
) : ICommand<BaseResponse<UserLoginResponse>>
{

}
