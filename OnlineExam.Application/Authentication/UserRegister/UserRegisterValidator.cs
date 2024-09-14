using System;
using FluentValidation;
using OnlineExam.Application.Commands.Authentication;

namespace OnlineExam.Application.Authentication.UserRegister;

public class UserRegisterValidator : AbstractValidator<UserRegisterCommand>
{
    public UserRegisterValidator()
    {
        RuleFor(x => x.Email).NotEmpty().EmailAddress();
        RuleFor(x => x.Password).NotEmpty().MinimumLength(6);
       
    }

}
