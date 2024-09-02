using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineExam.Domain.Entities;

namespace OnlineExam.Application.DTO.Authentication
{
    public class AuthenticationResultResponse 
    {
        User user ;
        string Token;

        public AuthenticationResultResponse(User user, string token)
        {
            this.user = user;
            Token = token;
        }
    }
}