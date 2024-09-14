using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineExam.Application.DTO.Authentication;


namespace OnlineExam.Application.Commands.Authentication
{
    public class UserRegisterCommand : ICommand<AuthenticationResultResponse>
    {
        public UserRegisterCommand(string userName, string email, string password)
        {
            this.UserName = userName;
            this.Email = email;
            this.Password = password;

        }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }



}