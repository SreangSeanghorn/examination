using Microsoft.AspNetCore.Mvc;
using OnlineExam.Infrastructure.Resolver;

namespace OnlineExam.Application;

[ApiController]
[Route("api/users")]
public class UserController : ControllerBase
{
    private readonly ICommandResolver _commandResolver;
    private readonly IQueryResolver _queryResolver;

    [HttpGet("{email}")]
    public async Task<IActionResult> GetUserByEmail(string email)
    {
        var query = new GetUserByEmailQuery(email);
        var result = await _queryResolver.ResolveHandler<GetUserByEmailQuery, GetUserInfoByEmailResponseDTO>(query);
        if (result == null)
        {
            return NotFound();
        }
        return Ok(result);
    }
    

}
