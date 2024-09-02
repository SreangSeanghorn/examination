using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineExam.Contracts.Authentication;
using OnlineExam.Application.Commands;
using OnlineExam.Application.Commands.Authentication;
using OnlineExam.Application.DTO.Authentication;
using  OnlineExam.Domain.Repositories;
using OnlineExam.Infrastructure.Resolver;
using OnlineExam.Infrastructure.Services;

namespace OnlineExam.Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly ICommandResolver _commandResolver;
        public AuthenticationController(IAuthenticationService authenticationService, ICommandResolver commandResolver)
        {
            _authenticationService = authenticationService;
            _commandResolver = commandResolver;
        }
  
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            var user = request.Username;
            if(request == null)
            {
                return BadRequest();
            }
            var command = new UserRegisterCommand(request.Username, request.Email, request.Password);
            var result = await _commandResolver.ResolveHandler<UserRegisterCommand, AuthenticationResultResponse>(command);
            return Ok();
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginCommand request)
        {
            if(request == null)
            {
                return BadRequest();
            }
            var result = await _commandResolver.ResolveHandler<UserLoginCommand, UserLoginResponse>(request);
            return Ok(result);
        }

    }
}