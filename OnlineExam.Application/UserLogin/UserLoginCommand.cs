

using OnlineExam.Application.Commands;

namespace OnlineExam.Application;

public class UserLoginCommand : ICommand<UserLoginResponse>
{
    public string Username {get;set;}
    public string Password {get;set;}
    public UserLoginCommand(string username, string password)
    {
        Username = username;
        Password = password;
    }
    
}
