using System;

namespace OnlineExam.Application.Authentication.UserLogin;

public record UserLoginResponse(
    string Token,
    IEnumerable<string> Roles
)
{

}
