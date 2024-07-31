using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineExam.Contracts.Authentication
{
    public record RegisterRequest(
        string Username, string Email, string Password);
}