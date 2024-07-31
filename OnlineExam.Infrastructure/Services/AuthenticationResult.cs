using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineExam.Domain.Entities;
namespace OnlineExam.Infrastructure.Services
{
    public record AuthenticationResult(
       User user,string Token
    );
}