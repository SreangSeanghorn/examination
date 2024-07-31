using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineExam.Contracts.Authentication
{
    public record AuthenticationResponse(
        Guid Id, string Username, string Email, string Token
    );
}