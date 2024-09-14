using Microsoft.AspNetCore.Mvc;
using OnlineExam.Contracts.Authentication;
using OnlineExam.Application.Commands.Authentication;
using OnlineExam.Application.DTO.Authentication;
using OnlineExam.Infrastructure.Resolver;
using OnlineExam.Infrastructure.Services;
using OnlineExam.Application.Common;
using OnlineExam.Application.Authentication.UserLogin;

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
        public async Task<IActionResult> Login(UserLoginCommand command)
        {
            var result = await _commandResolver.ResolveHandler<UserLoginCommand, BaseResponse<UserLoginResponse>>(command);
            return Ok(result);
        }
        

    }
}