using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineExam.Contracts.Authentication
{
    public record LoginRequest(
        string Username, string Password
    );
}